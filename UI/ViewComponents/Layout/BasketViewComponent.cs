using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class BasketViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
