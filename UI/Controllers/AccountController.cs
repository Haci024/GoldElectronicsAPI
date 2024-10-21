using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using UI.DTOS.UsersDTO;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _client;
        public AccountController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory;   
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginDTO dto = new();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            // API'den token'ı al
            var response = await client.PostAsync("https://localhost:7290/api/Account/Login", content);

            if (response.IsSuccessStatusCode)
            {
                // Token'ı al
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<string>(responseContent); // API'nin yanıtı nasıl formatlıyorsa ona göre düzenleyin

                // Token'ı sakla (cookie)
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, dto.EmailOrUserName),
            new Claim("Token", token) 
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(10) 
                };

                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // HTTPS üzerinden güvenli bir şekilde gönderin
                    Expires = DateTimeOffset.UtcNow.AddMinutes(30) // Token'ın süresini ayarlayın
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Giriş başarısız olduğunda
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            return RedirectToAction("Index","Home");
        }
        #region
        [HttpGet]
        public IActionResult Register()
        {
            RegisterDTO dto=new();
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:7290/api/Account/Register", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ConfirmAccount", "Account",new {email=dto.Email});
            }
            else
            {


                return View(dto);
            }

        }
        [HttpGet]
        public async Task<IActionResult> ConfirmAccount()
        {
            

            return View();
        }
        #endregion
    }
}
