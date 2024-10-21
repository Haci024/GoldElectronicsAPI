using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Areas.GoldManagementPanel.DTOS.ProductDTO;

namespace UI.Areas.GoldManagementPanel.ViewComponents.Product
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _client;
        public ProductViewComponent(IHttpClientFactory client)
        {
            _client = client;   
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = _client.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Product/ProductCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductCountDTO>(jsonData);
                return View(values);
            }
           
            return View();
        }
    }
}
