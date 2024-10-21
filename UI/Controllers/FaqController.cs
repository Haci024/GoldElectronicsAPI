using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CurrentCulture=GetCurrentCulture();
            return View();
        }
        private string GetCurrentCulture()
        {

            return HttpContext.Session.GetString("CurrentCulture") ?? "az-AZ";
        }
        
    }
}
