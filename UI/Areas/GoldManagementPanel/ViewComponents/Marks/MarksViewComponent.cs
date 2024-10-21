using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.GoldManagementPanel.ViewComponents.Marks
{

    public class MarksViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _client;
        public MarksViewComponent(IHttpClientFactory client)
        {
            _client= client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        } 
        
    }
}
