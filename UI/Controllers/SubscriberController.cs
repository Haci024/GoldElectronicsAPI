using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UI.DTOS.SubscriberDTO;

namespace UI.Controllers
{

    public class SubscriberController : Controller
    {
        private readonly IHttpClientFactory _client;
        public SubscriberController(IHttpClientFactory httpClient)
        {

            _client = httpClient;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewSubscriber(AddSubscriberDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:7290/api/Subscriber/NewSubscriber", content);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.SuccesMessage = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.SuccMessage = false;
               
                return View("Error");
            }
            
        }
    }
}
