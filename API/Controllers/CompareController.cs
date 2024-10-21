using Business.Services;
using DTO.DTOS.CompareDTO;
using DTO.DTOS.WishListDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompareController : ControllerBase
    {
       private readonly ICompareService _compareService;
       
        public CompareController(ICompareService compare)
        {
            _compareService = compare;
        }
        [HttpPost("AddToCompare/{productId}")]
        public async Task<IActionResult> AddToCompare(Guid productId)
        {
            AddCompareDTO dto = new();
            dto.ProductId = productId;
             _compareService.AddToCompare(dto);
            return Ok("Müqayisə edilənlərə əlavə edildi!");
           
        }
        [HttpGet("ViewCompare")]
        public async Task<IActionResult> ViewCompare()
        {
            return Ok(new CompareProductCountDTO { productCount= await _compareService.ViewCompareCount() });
        }
        [HttpGet("CompareProductList")]
        public async Task<IActionResult> CompareProductList()
        {
            return Ok(new CompareProductCountDTO { productCount = await _compareService.ViewCompareCount() });
        }
    }
}
