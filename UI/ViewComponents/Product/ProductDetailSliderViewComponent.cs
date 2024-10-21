using UI.DTOS.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Newtonsoft.Json;

namespace UI.ViewComponents.Product
{
    public class ProductDetailSliderViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductDetailSliderViewComponent(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
            
        }
        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/ProductDetailSlider/{categoryId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<ProductListWithCategoryDTO>>(jsonData);
                return View(value);
            }
            else
            {
                return View();
            }
        }
    }
}
