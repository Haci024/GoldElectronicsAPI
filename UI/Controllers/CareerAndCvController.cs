using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using UI.DTOS.CvAndCareerDTO;

namespace UI.Controllers
{
    public class CareerAndCvController : Controller
    {
        private readonly IHttpClientFactory _client;
        public CareerAndCvController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            AddCvDTO dto = new();
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AddCvDTO dto)
        {
            var content = new MultipartFormDataContent();
            var client = _client.CreateClient();
            var fileContent = new StreamContent(dto.CvFile.OpenReadStream());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(dto.CvFile.ContentType);
            content.Add(fileContent, "CvFile", dto.CvFile.FileName);
            content.Add(new StringContent(dto.SendingDate.ToString()), "SendingDate");
            content.Add(new StringContent(dto.WorkType.ToString()), "WorkType");
            content.Add(new StringContent(dto.Email.ToString()), "Email");
            content.Add(new StringContent(dto.IsView.ToString()), "IsView");
            var response = await client.PostAsync($"https://localhost:7290/api/CVandCareer/SendCV", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccesMessage"] = true;
                return RedirectToAction("Index", "CareerAndCv");
            }
            else
            {
                TempData["SuccesMessage"] = false;

                return NotFound();
            }
        }

    }
}
