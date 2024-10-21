using AutoMapper;
using Business.Services;
using DTO.DTOS.ContactUsDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _service;
        private readonly INotficationService _notifications;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public ContactUsController(IContactUsService service,INotficationService notfications,IMapper mapper, IEmailService emailService)
        {
            _mapper = mapper;
            _service = service;
            _emailService = emailService;
            _notifications = notfications;

        }
        [HttpGet("UnReadMessageList")]
        public async Task<IActionResult> UnreadMessageList()
        {

            return Ok(_mapper.Map<IEnumerable<ContactUsListDTO>>(await _service.UnReadMessageList()));
        }

        [HttpGet("ReadMessageList")]
        public async Task<IActionResult> ReadMessageList()
        {

            return Ok(_mapper.Map<IEnumerable<ContactUsListDTO>>(await _service.ReadMessageList()));
        }
        [HttpPost("SendNewMessage")]
        public async Task<IActionResult> SendNewMessage(NewContactUsDTO  dto)
        {
            //var validator = new NewContactUsValidator();
            //var validationResult=validator.Validate(dto);
            //if (!validationResult.IsValid)
            //{
            //    foreach (var item in validationResult.Errors)
            //    {
            //        return Ok(item.ErrorMessage);
            //    }
            //} 
            ContactUs contact = new();
            _mapper.Map(dto,contact);
            contact.SendingDate = DateTime.UtcNow;
            _emailService.AutoMessageForContactUs(dto);
            await _service.Create(contact);
             _notifications.AddNotficationByAction(3,contact.Id);
            return Ok(contact);
        }
        //[HttpPost("ReplyToMessage")]
        //public async Task<IActionResult> ReplyToMessage(ReplyMessageDTO dto)
        //{

        //    _emailService.ContactUsReplyMessage(dto);
        //    await _service.Create(contact);
        //    return Ok(contact);
        //}
        [HttpGet("ReadMessage/{Id}")]
        public async Task<IActionResult> ReadMessage(int Id)
        {
            

            return Ok(_mapper.Map<ReadMessageDTO>(_service.GetById(Id)));
        }
        [HttpPut("ViewMessage/{Id}")]
        public async Task<IActionResult> ViewMessage(int Id, ReadMessageDTO dto)
        {
            var entity = _service.GetById(Id);
            _mapper.Map(dto, entity);
            _service.Update(entity);
            return Ok("Mesaj oxundu!");
        }
        [HttpGet("MessageCount")]
        public async Task<IActionResult> MessageCount()
        {
            MessageCountDTO dto = new();
            dto.ReadMessaageCount = await _service.ReadMessageCount();
            dto.UnReadMessageCount =await _service.UnReadReadMessageCount();
            return Ok(dto);
        }
    }
}
