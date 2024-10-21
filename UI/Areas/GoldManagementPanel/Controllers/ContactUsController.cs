using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.Areas.GoldManagementPanel.DTOS.ContactUsDTO;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class ContactUsController : Controller
    {
        private readonly IHttpClientFactory _clientfactory;
        public ContactUsController(IHttpClientFactory client)
        {
            _clientfactory = client;   
        }
        [HttpGet]
        public async Task<IActionResult> UnReadMessageList()
        {
            HttpClient client = _clientfactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/ContactUs/UnReadMessageList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                
                 var value = JsonConvert.DeserializeObject<ICollection<UnReadContactUsMessageDTO>>(jsonData);


                return View(value);
            }
            else
            {
                return NotFound();
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ReadMessageList()
        {
            HttpClient client = _clientfactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/ContactUs/ReadMessageList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ICollection<ReadContactUsMessageDTO>>(jsonData);


                return View(value);
            }
            else
            {
                return NotFound();
            }

          
        }
        [HttpGet]
        public async Task<IActionResult> ReadMessage(int Id)
        {
            HttpClient client=_clientfactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/ContactUs/ReadMessage/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<ReadContactUsMessageDTO>(jsonData);

                return View(value);
            }
            else
            {
                return NotFound();
            }
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReadMessage(int Id,ReadContactUsMessageDTO dto)
        {
            HttpClient client = _clientfactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7290/api/ContactUs/ViewMessage/{Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReadMessageList");
            }

           
          
            return View();
        }

    }
}
