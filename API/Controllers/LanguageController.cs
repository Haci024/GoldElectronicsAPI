using Business.Services;
using Data.Connection;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _service;
        IProductService _productService;
        public LanguageController(ILanguageService service,IProductService productService)
        {
            _service= service;  
            _productService= productService;
        }
        [HttpGet("SetLanguage")]
        public IActionResult SetLanguage(string culture)
        {
            if (string.IsNullOrEmpty(culture))
            {
                return BadRequest("Culture is required");
            }

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            return Ok(new { message = "Language set successfully" });
        }
        [HttpGet("{key}")]
        public ActionResult<string> GetTranslation(string key)
        {
            var translation = _service.GetKey(key);
          

            return Ok(translation);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllProductsDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            
            var productDTOs = products.Select(product => new AllProductsDTO
            {
                Id = product.Id,
                Name = _service.GetKey(product.Name),
            
                
            }).ToList();

            return Ok(productDTOs);
        }

    }

}


