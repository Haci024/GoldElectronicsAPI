using AutoMapper;
using Business.Services;
using Data.Connection;
using DTO.DTOS.SubscriberDTO;
using Entity.Models;
using Google.Apis.Storage.v1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberService _service;
        private readonly IEmailService _emailService;
        private readonly INotficationService _notifications;
        private readonly IMapper _mapper;
        private readonly GoldElectronicsDb _db;

        public SubscriberController(IEmailService emailService,INotficationService notfications,ISubscriberService service,IMapper mapper,GoldElectronicsDb db)
        {
            _emailService = emailService;
            _notifications = notfications;
            _db=db;
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("AllSubscribers")]
        public async Task<IActionResult> GetList()
        {
           
            return Ok(_mapper.Map<IEnumerable<SubscriberListDTO>>(await _service.GetAll()));
        }
        [HttpPost("NewSubscriber")]
        public async Task<IActionResult> NewSubscriber(NewSubscriberDTO dto)
        {
            Subscriber entity = new();
            
            bool IsExist = _db.Subscribers.Any(x => x.Email == dto.Email);
            if (IsExist)
            {
                return BadRequest(dto.Email+"Bu elektron ünvan artıq abunə olub!");
            }
            else
            {
                _mapper.Map(dto, entity);
                await _service.Create(entity);
                await _notifications.AddNotficationByAction(1, entity.Id);
                return Ok(dto.Email + "adlı elektron ünvan abunə oldu!");
            }
        }
        [HttpDelete("RemoveSubscribe")]
        public async  Task<IActionResult> RemoveSubscribe(RemoveSubscriberDTO dto)
        {
            Subscriber entity =  await _service.GetByEmail(dto.Email);
            if (entity!=null)
            {
              _emailService.RemoveSubscriberMessage(dto);
              await  _service.Delete(entity);
                return Ok("Abunəlik dayandırıldı və mesaj göndərildi!");
            }
            else
            {
                return Ok("Elektron ünvan təyin edilməyib!");
            }
        }
       
        [HttpDelete("DeleteSubscriberForAdmin")]
        public async Task<IActionResult> DeleteSubscribeForAdmin(RemoveSubscriberDTO dto)
        {
            Subscriber entity = await _service.GetByEmail(dto.Email);
            if (entity != null)
            {
                await _service.Delete(entity);
                return Ok("Abunəlik dayandırıldı və mesaj göndərildi!");
            }
            else
            {
                return Ok("Elektron ünvan təyin edilməyib!");
            }
        }

    }
}
