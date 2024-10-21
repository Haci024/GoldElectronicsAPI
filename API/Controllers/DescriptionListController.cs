using AutoMapper;
using Business.Services;
using DTO.DTOS.DescriptionListDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionListController : ControllerBase
    {
        private readonly IDescriptionListService _service;
        private readonly IMapper _mapper;
        public DescriptionListController(IDescriptionListService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("DescriptionListByProduct/{productId}")]
        public async Task<IActionResult> DescriptionListByProduct(Guid productId)
        {

            return Ok(await _service.GetDescriptionList(productId));
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return  Ok(_service.GetById(Id));
        }
        [HttpPost("AddDescription/{productId}")]
        public async Task<IActionResult> AddDescription(Guid productId,AddDescriptionDTO dto)
        {
            DescriptionList entity = new();
            entity.ProductId = productId;
         
            _mapper.Map(dto, entity);
            
           await  _service.Create(entity);
            return Ok(dto);
        }
        [HttpPut("UpdateDescription/{descriptionId}")]
        public async Task<IActionResult> UpdateDescription(int descriptionId, UpdateDescriptionDTO dto)
        {
            DescriptionList entity = _service.GetById(descriptionId);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok(dto);
        }
        [HttpDelete("DeleteDescription/{Id}")]
        public async Task<IActionResult> DeleteDescription(int Id)
        {
            DescriptionList entity=_service.GetById(Id);
           await  _service.Delete(entity);
            return Ok("Açıqlama silindi!");
        }
    }
}
