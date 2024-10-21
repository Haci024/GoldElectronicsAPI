using AutoMapper;
using Business.Services;
using DTO.DTOS.ColorDTO;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorListController : ControllerBase
    {
        private readonly IColorListService _colorListService;
        private readonly IMapper _mapper;
        public ColorListController(IColorListService colorList,IMapper mapper)
        {
            _colorListService = colorList;
            _mapper = mapper;   
        }
        [HttpPost("NewColor")]
        public IActionResult NewColor(NewColorDTO dto)
        {
            ColorList entity = new();
            _mapper.Map(dto,entity);
            _colorListService.Create(entity);
           
            return Ok(dto.Name +"adlı rəng uğurla yaradıldı");
        }
        [HttpGet("ColorList")]
        public async Task<IActionResult> ColorList()
        {
            return Ok(_mapper.Map<IEnumerable<ColorListDTO>>(await _colorListService.GetAll()));
        }
        [HttpPut("UpdateColor")]
        public async Task<IActionResult> UpdateColor(UpdateColorDTO dto)
        {
            ColorList entity = _colorListService.GetById(dto.Id);
            _mapper.Map(dto, entity);
            _colorListService.Update(entity);


            return Ok(entity);
        }
        [HttpDelete("DeleteColor")]
        public async Task<IActionResult> DeleteColor(DeleteColorDTO dto)
        {
            ColorList entity = _colorListService.GetById(dto.ColorId);
            _mapper.Map(dto, entity);
           await  _colorListService.Delete(entity);

            return Ok(entity.Name +"uğurla silindi!");
        }
    }
}
