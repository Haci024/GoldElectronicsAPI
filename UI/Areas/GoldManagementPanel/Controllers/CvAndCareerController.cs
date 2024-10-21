using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using UI.Areas.GoldManagementPanel.DTOS.CvAndCareerDTO;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class CvAndCareerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CvAndCareerController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        [HttpGet]
        public async Task<IActionResult> ViewedCvList()
        {
            var client=_httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/CVandCareer/ViewedCvList");
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<CvListDTO>>(jsonData);

                return View(value);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> UnViewedCvList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/CVandCareer/UnViewedCvList");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<CvListDTO>>(jsonData);

                return View(value);
            }
            else
            {
                return NotFound();
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> ViewCv()
        {

            return View();
        }

    }
}
