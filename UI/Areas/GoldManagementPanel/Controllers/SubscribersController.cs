using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Areas.GoldManagementPanel.DTOS.SubscribersDTO;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class SubscribersController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public SubscribersController(IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;

        }
        [HttpGet]   
        public async Task<IActionResult> AllSubscribers()
        {
            var client=_clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7290/api/Subscriber/AllSubscribers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<SubscriberListDTO>>(jsonData);
                return View(value);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> SendMessageAll() {




            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveSubscriber()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveSubscriber(Guid Id)
        {

            return View();
        }
    }
}
