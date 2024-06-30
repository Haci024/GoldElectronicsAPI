using AutoMapper;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        [HttpGet("ActiveSliderList")]
        public async Task<IActionResult> GetList() {

            return Ok();
        }
        [HttpGet("DeactiveSliderList")]
        public async  Task<IActionResult> DeactiveSliderList() {
            

            return Ok();
        }
    }
}
