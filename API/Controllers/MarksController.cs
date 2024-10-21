using AutoMapper;
using Business.Services;
using DTO.DTOS.ProductImagesDTO;
using DTO.DTOS.MarksDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _marksService;
        private readonly IMapper _mapper;
        public MarksController(IMapper mapper,IMarkService markService)
        {
            _mapper = mapper;
            _marksService = markService;
        }
        [HttpGet("ReadMarks/{Id}")]
        public async Task<IActionResult> ReadMarks(int Id)
        {
            

            return Ok(_mapper.Map<ReadMarksDTO>(_marksService.GetById(Id)));
        }
      
        [HttpPost("NewMarks")]
        public async Task<IActionResult> NewMarks(AddMarkDTO dto)
        {
            Marks entity = new();

            _mapper.Map(dto, entity);
            await _marksService.Create(entity);

            return Ok(dto.Name + "adlı rəng uğurla yaradıldı");
        }
        [HttpPut("UpdateMark/{marksId}")]
        public async Task<IActionResult> UpdateMarks(int marksId,UpdateMarkDTO dto)
        {
            Marks entity = _marksService.GetById(marksId);
            _mapper.Map(dto, entity);
            _marksService.Update(entity);


            return Ok(entity);
        }
        [HttpDelete("DeleteMark/{marksId}")]
        public async Task<IActionResult> DeleteMark(int marksId)
        {
            Marks entity = _marksService.GetById(marksId);
          
            await _marksService.Delete(entity);

            return Ok(entity.Name + "uğurla silindi!");
        }
        [HttpGet("ActiveMarkList")]
        public async Task<IActionResult> ActiveMarkList()
        {

            return Ok(await _marksService.ActiveMarkList());
        }
        [HttpGet("DeactiveMarkList")]
        public async Task<IActionResult> DeactiveMarkList()
        {

            return Ok(await _marksService.DeactiveMarkList());
        }
    }
}
