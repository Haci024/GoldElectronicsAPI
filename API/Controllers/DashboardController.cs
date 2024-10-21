using Business.Manager;
using Business.Services;

using DTO.DTOS.DashboardDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ICategoryService _category;
        private readonly IProductService _product;
        private readonly ISubscriberService _subscriber;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(ICategoryService category, IProductService product,UserManager<AppUser> user, ISubscriberService subscriber, IUserService userService)
        {
            _category = category;
            _product = product;
            _subscriber = subscriber;
            _userService = userService;
            _userManager = user;
        }
        [HttpGet("ItemsCount")]
        public async Task<IActionResult> ItemsCount()
        {
            ItemsCountDTO dto = new();
            dto.SubscriberCount =await _subscriber.DailySubscriberCount();
            dto.ProductCount=await _product.SimpleProductCount();
            dto.CategoryCount=await _category.ActiveCategroyCount();
            dto.CustomerCount = await _userService.CustomerCount();
            
            
            return Ok(dto);
        }
   
    }
}
