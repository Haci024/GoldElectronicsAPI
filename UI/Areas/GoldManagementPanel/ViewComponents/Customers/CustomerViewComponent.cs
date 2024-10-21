using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.GoldManagementPanel.ViewComponents.Customers
{
    public class CustomerViewComponent:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
