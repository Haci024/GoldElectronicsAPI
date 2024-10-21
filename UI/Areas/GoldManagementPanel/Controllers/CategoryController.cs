using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Main;
using UI.Areas.GoldManagementPanel.DTOS.DashboardDTO;
using UI.Areas.GoldManagementPanel.DTOS.ProductDTO;
using UI.Areas.GoldManagementPanel.ValidationRule.CategoryValidator.Child;
using UI.Areas.GoldManagementPanel.ValidationRule.ProductValidator;

using static System.Net.WebRequestMethods;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _client;
        public CategoryController(IHttpClientFactory client)
        {
            _client = client;
        }
        [HttpGet]
        public async Task<IActionResult> MainCategoryList()
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Category/MainCategoryList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ICollection<MainCategoryListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ChildCategoryList()
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Category/ChildCategoryList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ICollection<ChildCategoryListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ThirdLevelCategoryList()
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Category/ThirdLevelCategoryList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ICollection<ThirdLevelCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> ChildCategoryListByMain(Guid mainCategoryId)
        {
          HttpClient client= _client.CreateClient();
           
                var responseMessage = await client.GetAsync($"https://localhost:7290/api/Category/ChildCategoryListByMain/{mainCategoryId}");
                var responseforCategory = await client.GetAsync($"https://localhost:7290/api/Category/GetById/{mainCategoryId}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var jsondata2 = await responseforCategory.Content.ReadAsStringAsync();

                  
                        var values = JsonConvert.DeserializeObject<IEnumerable<ChildCategoryListByMainDTO>>(jsonData);
                        var category = JsonConvert.DeserializeObject<CategoryNameDTO>(jsondata2);

                        ViewBag.CategoryName = category.Name;
                        return View(values);
                    
                 
                }
                return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> DeactiveCategoryList()
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Category/MainCategoryList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ICollection<DeactiveCategoryListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> NewChildCategory()
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Category/MainCategoryList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                NewChildCategoryDTO dto = new();
                dto.MainCategoryList = JsonConvert.DeserializeObject<ICollection<MainCategoryListDTO>>(jsonData);
               

                return View(dto);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewChildCategory(NewChildCategoryDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:7290/api/Category/NewChildCategory", content);
            if (response.IsSuccessStatusCode)
            {


                return RedirectToAction("ChildCategoryList");
            }
            else
            {
                var validationRule = new NewChildCategoryValidator();
                var validation = validationRule.Validate(dto);
                if (!validation.IsValid)
                {
                    foreach (var item in validation.Errors)
                    {
                        ModelState.AddModelError("", item.ErrorMessage);
                    }
                  
                }
                return View(dto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> NewProductCategory()
        {
            NewThirdLevelCategoryDTO dto = new();
            var client = _client.CreateClient();
            var response = await client.GetAsync("https://localhost:7290/api/Category/ChildCategoryList");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<ICollection<ChildCategoryListDTO>>(jsonData);
                dto.ChildCategoryList = value;
                return View(dto);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewProductCategory(NewChildCategoryDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:7290/api/Category/NewThirdCategory", content);
            if (response.IsSuccessStatusCode)
            {


                return RedirectToAction("ThirdLevelCategoryList");
            }
            else
            {
                var validationRule = new NewChildCategoryValidator();
                var validation = validationRule.Validate(dto);
                if (!validation.IsValid)
                {
                    foreach (var item in validation.Errors)
                    {
                        ModelState.AddModelError("", item.ErrorMessage);
                    }

                }
                return View(dto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateChildCategory(Guid Id)
        {
            var client = _client.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Category/GetById/{Id}");
            var responseForMainList = await client.GetAsync("https://localhost:7290/api/Category/MainCategoryList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var jsonDataforMainList = await responseForMainList.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateChildCategoryDTO>(jsonData);
                values.MainCategoryList = JsonConvert.DeserializeObject<ICollection<MainCategoryListDTO>>(jsonDataforMainList);
                return View(values);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateChildCategory(Guid Id, UpdateChildCategoryDTO dto)
        {
            var client = _client.CreateClient();
            var responseForMainList = await client.GetAsync("https://localhost:7290/api/Category/MainCategoryList");
            var mainCategoryList = await responseForMainList.Content.ReadAsStringAsync();
            dto.MainCategoryList = JsonConvert.DeserializeObject<ICollection<MainCategoryListDTO>>(mainCategoryList);

            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7290/api/Category/UpdateChildCategory/{Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ChildCategoryList");
            }
            else
            {
                return View();
            }
           
        }
        
        public async Task<IActionResult> DeleteChildCategory(Guid Id)
        {
            var client = _client.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7290/api/Category/DeleteMainCategory/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ChildCategoryList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddMainCategory()
        {
            NewMainCategoryDTO dto = new();
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMainCategory(NewMainCategoryDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:7290/api/Category/NewMainCategory", content);
            if (response.IsSuccessStatusCode)
            {


                return RedirectToAction("MainCategoryList");
            }
            else
            {

                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("", "Kateqoriya əlavə edin!");


                //}
                return View(dto);
            }
            
           
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMainCategory(Guid Id)
        {
            var client = _client.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Category/GetById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
               
                var values = JsonConvert.DeserializeObject<UpdateMainCategoryDTO>(jsonData);
               
                return View(values);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMainCategory(Guid Id,UpdateMainCategoryDTO dto)
        {
            var client = _client.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7290/api/Category/UpdateMainCategory/{Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MainCategoryList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateThirdCategory(Guid Id)
        {
            var client = _client.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Category/GetById/{Id}");
            var responseForMainList = await client.GetAsync("https://localhost:7290/api/Category/ChildCategoryList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var jsonDataforMainList = await responseForMainList.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateThirdCategoryDTO>(jsonData);
                values.ChildCategories = JsonConvert.DeserializeObject<ICollection<ChildCategoryListDTO>>(jsonDataforMainList);
                return View(values);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateThirdCategory(Guid Id, UpdateThirdCategoryDTO dto)
        {
            var client = _client.CreateClient();
            var responseForMainList = await client.GetAsync("https://localhost:7290/api/Category/ChildCategoryList");
            var mainCategoryList = await responseForMainList.Content.ReadAsStringAsync();
            dto.ChildCategories = JsonConvert.DeserializeObject<ICollection<ChildCategoryListDTO>>(mainCategoryList);

            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7290/api/Category/UpdateThirdCategory/{Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ChildCategoryList");
            }
            else
            {
                return View();
            }

        }






    }
}
