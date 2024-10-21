using Business.Services;
using Data.Connection;
using DTO.DTOS.BasketDTO;
using DTO.DTOS.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Business.Manager;
using Entity.Models;



namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly GoldElectronicsDb _db;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BasketController(GoldElectronicsDb db, IBasketService basket, IProductService productService, Microsoft.AspNetCore.Identity.UserManager<AppUser> user, IHttpContextAccessor accessor)
        {
            _db = db;
            _basketService = basket;
            _productService = productService;
            _userManager = user;
            _httpContextAccessor = accessor;
        }
        [HttpPost("addToBasket/{productId}")]
        public async Task<IActionResult> AddToCart(Guid productId)
        {
         
              await  _basketService.AddToBasket(productId);
                return Ok("Səbətə əlavə edildi!");
        

        }

        [HttpGet("BasketList")]
        public IActionResult BasketList()
        {
            var baskets = _basketService.ViewBasket();
            return Ok(baskets);
        }
        [HttpGet("BasketView")]
        public async Task<IActionResult> BasketView()
        {

            return Ok(await _basketService.BasketView());
        }
        [HttpGet("BasketContent")]
        public  IActionResult BasketContent()
        {
           
            return Ok(_basketService.BasketContent());
        }




    }
}
    

