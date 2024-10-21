using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.GoldManagementPanel.ViewComponents.TopBar
{
    public class TopBarViewComponent:ViewComponent
    {
       public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
