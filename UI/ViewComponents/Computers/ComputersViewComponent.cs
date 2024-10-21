using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Computers
{
    public class ComputersViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _client;
        public ComputersViewComponent(IHttpClientFactory client)
        {

            _client = client;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _client.CreateClient();

            return View();
        }
    }
}