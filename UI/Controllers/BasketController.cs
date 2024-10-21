using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using UI.DTOS.BasketDTO;

namespace UI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7290/api/Basket/BasketList");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var basket = JsonConvert.DeserializeObject<IEnumerable<AddBasketDTO>>(json);
                  
                
                return View(basket);
                }
                else
                {      
                
                    return View();
                }
            }
          
        
    }
}
