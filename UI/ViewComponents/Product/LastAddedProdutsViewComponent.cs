using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.DTOS.ProductDTO;

namespace UI.ViewComponents.LastAddedProductsViewComponent
{
    public class LastAddedProductsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LastAddedProductsViewComponent(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7290/api/Product/LastAddedProducts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<IEnumerable<LastAddedProductsDTO>>(jsonData);
                return View(value);
            }
            else
            {
                return View();
            }
            
        }
    }
}
