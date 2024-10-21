using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Smartphones
{
    public class SmartphonesViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _client;
        public SmartphonesViewComponent(IHttpClientFactory client)
        {

            _client = client;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _client.CreateClient();

            return View();
        }
    }
}
