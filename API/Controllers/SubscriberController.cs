using AutoMapper;
using Business.Services;
using DTO.DTOS.SubscriberDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberService _service;
        private readonly IMapper _mapper;
      
        [HttpGet("AllSubscribers")]
        public async Task<IActionResult> GetList()
        {
           
            return Ok(_mapper.Map<IEnumerable<SubscriberListDTO>>(await _service.GetAll()));
        }
    }
}
