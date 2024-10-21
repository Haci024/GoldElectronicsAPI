using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        
        private string GetCurrentCulture()
        {
            
            return HttpContext.Session.GetString("CurrentCulture")?? "az-AZ";
        }

        [HttpGet]
        public IActionResult Index()
        {
          
            return View();
        }
        [HttpGet]
        public IActionResult Index2()
        {

            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            

            return Redirect(Request.Headers["Referer"].ToString());
        }

      
      

    }
}
