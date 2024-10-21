using Business.Services;
using DTO.DTOS.BasketDTO;
using DTO.DTOS.WishListDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;
        private readonly IHttpContextAccessor _contextAccessor;

        public WishListController(IWishListService wishListService, IHttpContextAccessor contextAccessor)
        {
            _wishListService = wishListService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("AddWishList/{ProductId}")]
        public IActionResult AddWishList(Guid ProductId)
        {
            WishListDTO dto = new();
            dto.ProductId= ProductId;
            _wishListService.AddWishList(dto);
            return Ok("Favoritlərə əlavə edildi!");
        }
        [HttpGet("WishListView")]
        public async Task<IActionResult> WishListView() {
            

         return Ok(new WishListViewDTO { productQuantity =await _wishListService.WishListProductCount() });
         
        }
        [HttpGet("WishListProductDetail")]
        public async Task<IActionResult> WishListProductDetail()
        {

            return Ok(await _wishListService.WishListProductsContent());
        }
       
    }
}
