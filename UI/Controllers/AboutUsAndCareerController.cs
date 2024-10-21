using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AboutUsAndCareerController : Controller
    {
        private readonly IHttpClientFactory _client;
        public AboutUsAndCareerController(IHttpClientFactory client)
        {

            _client = client;

        }
        [HttpGet]
        public IActionResult Index()
        {


            return View();
        }
    }
}
