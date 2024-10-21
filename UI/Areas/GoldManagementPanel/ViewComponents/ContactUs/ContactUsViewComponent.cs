using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Areas.GoldManagementPanel.DTOS.ContactUsDTO;

namespace UI.Areas.GoldManagementPanel.ViewComponents.ContactUs
{
    public class ContactUsViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public ContactUsViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;   
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client=_clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/ContactUs/MessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<MessageCountDTO>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
