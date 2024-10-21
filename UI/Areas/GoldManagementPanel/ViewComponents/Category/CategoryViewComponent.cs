using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Main;

namespace UI.Areas.GoldManagementPanel.ViewComponents.CategoryComponent
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;
        public CategoryViewComponent(IHttpClientFactory clientFactory)
        {
            _httpClient= clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client=_httpClient.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Category/CategoriesCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CategoryCountDTO>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
