using AutoMapper;
using Business.Services;
using DTO.DTOS.NotficationsDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotficationsController : ControllerBase
    {
        private readonly INotficationService _service;
        private readonly IMapper _mapper;
        public NotficationsController(INotficationService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("NotficationList")]
        public async Task<IActionResult> NotficationList()
        {

            return Ok(await _service.UnViewNotficationList());
        }
        [HttpPost("AddNotfication")]
        public async Task<IActionResult> AddNotfication(AddNotficationDTO dto)
        {
            Notfications entity = new();
            _mapper.Map(dto,entity);
            entity.SendingDate = DateTime.Now;
            _service.Create(entity);

            return Ok(entity);
        }
    }
}
