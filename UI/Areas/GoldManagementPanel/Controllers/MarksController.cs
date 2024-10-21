using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Main;
using UI.Areas.GoldManagementPanel.DTOS.MarksDTO;

namespace UI.Areas.GoldManagementPanel.Controllers
{

    [Area("GoldManagementPanel")]
    public class MarksController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public MarksController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> ActiveMarkList()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Marks/ActiveMarkList");
            
            if (response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<IEnumerable<MarkListDTO>>(jsonData);
                return View(value);
            }
            else
            {
                
                return NotFound();
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> DeactiveMarkList()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Marks/DeactiveMarkList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<MarkListDTO>>(jsonData);
                return View(value);
            }
            else
            {

                return NotFound();
            }

        }
        [HttpGet]
        public async Task<IActionResult> NewMarks()
        {
           AddMarksDTO markDTO = new();
            return View(markDTO); 
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewMarks(AddMarksDTO dto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7290/api/Marks/NewMarks", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ActiveMarkList");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                ModelState.AddModelError("", "Error from API: " + errorContent);
                return View(dto);

            }


        }

        [HttpGet]
        public async Task<IActionResult> UpdateMark(Guid marksId)
        {
            var client= _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Marks/ReadMarks/{marksId}");
         

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await  response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMarksDTO>(jsonData);
               
   
                return View(value);
            }
            else
            {
                return View("Error");
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMark(Guid marksId,UpdateMarksDTO dto)
        {
            var client = _clientFactory.CreateClient();
          
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7290/api/Marks/UpdateMarks/{marksId}", content);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("MarkListByCategory", "Marks", new { categoryId = dto.CategoryId });
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", "Error from API: " + errorContent);
                return View(dto);

            }


        }
    }
}
