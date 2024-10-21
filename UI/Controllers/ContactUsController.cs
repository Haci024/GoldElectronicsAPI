using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.DTOS.ContactUsDTO;

namespace UI.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IHttpClientFactory _client;
        public ContactUsController(IHttpClientFactory client)
        {

            _client = client;

        }
        public IActionResult Index()
        {

            NewMessageDTO dto = new NewMessageDTO();
            TempData["SuccesMessage"] = true;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NewMessageDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:7290/api/ContactUs/SendNewMessage", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccesMessage"] = true; 
                return RedirectToAction("Index", "ContactUs");
            }
            else
            {
                TempData["SuccesMessage"] = false;

                return View("Error");
            }
        }
    }
}
