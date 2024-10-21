using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class AccountController : Controller
    {
        #region Login
        [HttpGet]   
        public async Task<IActionResult> Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(int Id)
        {
            return View();
        }
        #endregion
        #region Login
        [HttpGet]
        public async Task<IActionResult> Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(int Id)
        {
            return View();
        }
        #endregion
        #region ConfirmAccount
        [HttpGet]
        public async Task<IActionResult> ConfirmAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmAccount(string email)
        {
            return View();
        }
        #endregion
        #region
        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {

            return View();
        }
        #endregion
    }
}
