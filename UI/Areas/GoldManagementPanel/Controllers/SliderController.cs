using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Areas.GoldManagementPanel.DTOS.SlidersDTO;

namespace UI.Areas.GoldManagementPanels
{
    [Area("GoldManagementPanel")]
    
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public SliderController(IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;

        }
        [HttpGet]
        public async Task<IActionResult> ActiveSliderList()
        {
            var client=_clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Slider/ActiveSliderList");
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<ActiveSliderListDTO>>(jsonData);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeactiveSliderList()
        {
            return View();
        }
    }
}
