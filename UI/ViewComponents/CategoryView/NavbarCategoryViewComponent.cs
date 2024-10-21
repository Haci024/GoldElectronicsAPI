using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.DTOS.CategoryDTO;

namespace UI.ViewComponents.NavbarCategoryViewComponent
{
    public class NavbarCategoryViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NavbarCategoryViewComponent(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var response =await client.GetAsync("https://localhost:7290/api/Category/NavbarCategoryList");
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();   
                IEnumerable<NavbarCategoryDTO> categories=JsonConvert.DeserializeObject<IEnumerable<NavbarCategoryDTO>>(jsonData);

                
                return View(categories);
            }
            return View();
        }
    }
}
