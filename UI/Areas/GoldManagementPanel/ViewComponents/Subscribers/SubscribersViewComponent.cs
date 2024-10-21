using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.GoldManagementPanel.ViewComponents.Subscribers
{
    public class SubscribersViewComponent:ViewComponent
    {
    
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
