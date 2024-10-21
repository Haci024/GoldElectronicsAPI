using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UI.Areas.GoldManagementPanel.DTOS.DashboardDTO;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Dashboard/ItemsCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GeneralInfoDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SetLanguage(string culture)
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Language/SetLanguage?culture={culture}");
            var responseString = await response.Content.ReadAsStringAsync();
            var translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);




            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

          
            return RedirectToAction(nameof(Index));
        }
    }
}
