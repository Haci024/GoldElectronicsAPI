using AutoMapper;
using Business.Services;
using DTO.DTOS.SliderDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IGoogleCloudStorageService _googleCloudStorageService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper,IGoogleCloudStorageService service)
        {
            _sliderService = sliderService;
          _googleCloudStorageService=service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddSlider(AddSliderDTO dto)
        {
            Slider entity = new();
            //entity.Price = dto.Price;
            //entity.Description = dto.Description;
            //entity.Title= dto.Title;
            entity.SavedFileUrl = GenerateFileNameToSave(dto.Image.FileName);
            entity.ImageUrl = await _googleCloudStorageService.UploadFile(dto.Image, entity.SavedFileUrl);
           await _sliderService.Create(entity);
            return Ok(dto);
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

        [HttpGet("ActiveSliderList")]
        public async Task<IActionResult> ActiveSliderList() {


            return Ok(_mapper.Map<IEnumerable<SliderListDTO>>(await _sliderService.DeactiveSliders()));
        }

        [HttpGet("DeactiveSliderList")]
        public async Task<IActionResult> DeactiveSliderList() {
            

            return Ok(_mapper.Map<IEnumerable<DeactiveSliderListDTO>>(await _sliderService.DeactiveSliders()));
        }
    }
}
