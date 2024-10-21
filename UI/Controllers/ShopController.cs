using UI.DTOS.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DTO.DTOS.WishListDTO;


namespace UI.Controllers
{
    
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory _client;
        public ShopController(IHttpClientFactory client)
        {

            _client = client;

        }
        private string GetCurrentCulture()
        {

            return HttpContext.Session.GetString("CurrentCulture") ?? "az-AZ";
        }

        [HttpGet]
        public IActionResult AllProducts()
        {
            ViewBag.CurrentCulture = GetCurrentCulture();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(int productId)
        {
            var client=_client.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/ProductDetail/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                ProductDetailDTO product = JsonConvert.DeserializeObject<ProductDetailDTO>(jsonData);
                return View(product);
            }
            else
            {

                return View();
            }
 
        }
        //[HttpGet]
        //public async Task<IActionResult> WishList()
        //{
        //    var client = _client.CreateClient();
        //    var response = await client.GetAsync($"https://localhost:7290/api/WishList/WishListProductDetail");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var products = JsonConvert.DeserializeObject<List<DTO.DTOS.WishListDTO.WishListDetailDTO>>(jsonData);

               
        //        var uiProducts = products.Select(p => new UI.DTOS.WishListDTO.WishListDetailDTO
        //        {
        //            Id = p.Id,
        //            ProductName = p.ProductName,
        //            Price = p.Price
        //        }).ToList();

        //        return View(uiProducts);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

    }
}
