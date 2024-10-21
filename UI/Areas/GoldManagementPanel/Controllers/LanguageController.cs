using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class LanguageController : Controller
    {
        public LanguageController()
        {
            
        }
       
        [HttpGet]
        public async Task<IActionResult> AzerbaijanLanguageFormat()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EnglishLanguageFormat()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RussianLanguageFormat()
        {

            return View();
        }
    }
}
