using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.DTOS;
using UI.DTOS.BasketDTO;
using UI.DTOS.CategoryDTO;

namespace UI.ViewComponents.BasketContent
{
    public class BasketContentViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;
        public BasketContentViewComponent(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client= _httpClient.CreateClient();
            HttpResponseMessage response =await client.GetAsync("https://localhost:7290/api/Basket/BasketContent");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ICollection<BasketContentDTO>>(jsonData);
               
                return View(values);
            }
            else
            {        
                return View();
            }
          
        }
    }
}
