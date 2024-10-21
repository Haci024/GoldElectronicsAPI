using FluentValidation;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Main;
using UI.Areas.GoldManagementPanel.DTOS.DescriptionListDTO;
using UI.Areas.GoldManagementPanel.DTOS.ImageListDTO;
using UI.Areas.GoldManagementPanel.DTOS.MarksDTO;
using UI.Areas.GoldManagementPanel.DTOS.ProductDTO;
using UI.Areas.GoldManagementPanel.ValidationRule.CategoryValidator.Child;
using UI.Areas.GoldManagementPanel.ValidationRule.ProductValidator;

namespace UI.Areas.GoldManagementPanel.Controllers
{
    [Area("GoldManagementPanel")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        
        public ProductController(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory;   
        }
        [HttpGet]
        public async Task<IActionResult> ProductListWithCategory(Guid categoryId)
        {
           HttpClient client=_httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/ProductListWithCategory/{categoryId}");
            var responseforCategory=await client.GetAsync($"https://localhost:7290/api/Category/GetById/{categoryId}");
            if (response.IsSuccessStatusCode && responseforCategory.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categoryJson = await responseforCategory.Content.ReadAsStringAsync() ;
                var values = JsonConvert.DeserializeObject<IEnumerable<ProductListWithCategoryDTO>>(jsonData);
                var categories = JsonConvert.DeserializeObject<CategoryNameDTO>(categoryJson);
                ViewBag.CategoryName = categories.Name;


                return View(values);
                
            }
            else
            {
                return NotFound();
            }
           

        }
        [HttpGet]
        public async Task<IActionResult> NewProduct()
        {
            NewProductDTO dto = new NewProductDTO();
            var client = _httpClient.CreateClient();
            var responseForCategory = await client.GetAsync("https://localhost:7290/api/Category/ThirdLevelCategoryList");
            var responseForMarks = await client.GetAsync("https://localhost:7290/api/Marks/ActiveMarkList");
            if (responseForCategory.IsSuccessStatusCode && responseForMarks.IsSuccessStatusCode)
            {
                var categoryJson = await responseForCategory.Content.ReadAsStringAsync();
                var categorlist = JsonConvert.DeserializeObject<ICollection<ThirdLevelCategoryDTO>>(categoryJson);
                dto.ThirdLevelCategories = categorlist;
                var marksJson = await responseForMarks.Content.ReadAsStringAsync();
                var markLists = JsonConvert.DeserializeObject<ICollection<MarkListDTO>>(marksJson);
                dto.MarkList = markLists;

                return View(dto);   
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewProduct(NewProductDTO dto)
        {
            var client = _httpClient.CreateClient();
            var responseForCategory = await client.GetAsync("https://localhost:7290/api/Category/ThirdLevelCategoryLis");
            var responseForMarks = await client.GetAsync("https://localhost:7290/api/Marks/ActiveMarkList");
            if (responseForCategory.IsSuccessStatusCode)
            {
                var categoryJson = await responseForCategory.Content.ReadAsStringAsync();
                var categorlist = JsonConvert.DeserializeObject<ICollection<ThirdLevelCategoryDTO>>(categoryJson);
                dto.ThirdLevelCategories = categorlist;
                var marksJson = await responseForMarks.Content.ReadAsStringAsync();
                var markLists = JsonConvert.DeserializeObject<ICollection<MarkListDTO>>(marksJson);
                dto.MarkList = markLists;
            }

            var validationRule = new NewProductValidator(dto);
            var validation = validationRule.Validate(dto);
            if (!validation.IsValid)
            {
                foreach (var item in validation.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
                return View(dto);
            }
            var content = new MultipartFormDataContent();
            
                foreach (var image in dto.ProductImages)
                {
                    var fileContent = new StreamContent(image.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType);
                    content.Add(fileContent, "ProductImages", image.FileName);
                }
                content.Add(new StringContent(dto.Name.ToString()), "Name");
                content.Add(new StringContent(dto.CategoryId.ToString()), "CategoryId");
                content.Add(new StringContent(dto.Price.ToString()), "Price");
                content.Add(new StringContent(dto.SalesPrice.ToString()), "SalesPrice");
                content.Add(new StringContent(dto.Status.ToString()), "Status");
                content.Add(new StringContent(dto.IsSale.ToString()), "IsSale");
            content.Add(new StringContent(dto.MarksId.ToString()), "MarksId");
            content.Add(new StringContent(dto.LastDateForIsSale.ToString()), "LastDateForIsSale");
                var jsonData = JsonConvert.SerializeObject(dto);
                var response = await client.PostAsync("https://localhost:7290/api/Product/NewProduct", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();

                    ModelState.AddModelError("", "Error from API: " + errorContent);
                    return View(dto);

                }
            
        }

        [HttpGet]
        public async Task<IActionResult> ImageList(Guid productId)
        {
            ViewBag.ProductId = productId;
            var client= _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/ImageList/ProductImageList/{productId}");
           
            if (response.IsSuccessStatusCode)
            {
                var JsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ImageListDTO>>(JsonData);
               
                return View(values);
            }
            else
            {
                return NotFound();
            }

           
        }
        [HttpGet]
        public async Task<IActionResult> DeleteImage(Guid productId, Guid ImageId)
        {
            
            var client = _httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7290/api/ImageList/DeleteImage/{ImageId}");
            if (response.IsSuccessStatusCode)
            {
               

                return RedirectToAction("ImageList",new {productId=productId});
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddImage(Guid productId)
        {
            NewImageDTO dto = new();

            ViewBag.ProductId = productId;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(Guid productId, NewImageDTO dto)
        {
            if (dto.Image == null || dto.Image.Length == 0)
            {
                ModelState.AddModelError("Image", "Please select an image file.");
                return View();
            }

            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent = new StreamContent(dto.Image.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(dto.Image.ContentType);
                    content.Add(fileContent, "Image", dto.Image.FileName);
                    content.Add(new StringContent(dto.Status.ToString()), "Status");
                    

                    var response = await client.PostAsync($"https://localhost:7290/api/ImageList/NewImage/{productId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                    
                        return RedirectToAction("ImageList", new {productId=productId});
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, $"API'den Hata: {errorResponse}");
                        return View(dto);
                    }
                }
            }

            
        }


        [HttpGet]
        public async Task<IActionResult> DeactiveProductList()
        {
            HttpClient client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/DeactiveProductList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<IEnumerable<DeactiveProductListDTO>>(jsonData);

                return View(values);

            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            HttpClient client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/AllProducts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<AllProductsDTO>>(jsonData);

                return View(values);

            }
            else
            {
                return NotFound();
            }
        }
   
       
        [HttpGet]
        public async Task<IActionResult> ProductDetail(Guid productId)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/ProductDetail/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                var dto = JsonConvert.DeserializeObject<ReadProductDTO>(jsonData);
                return View(dto);
            }
            else
            {
                return NotFound();
            }

        }
        #region Discount
        [HttpGet]
        public async Task<IActionResult> IsSaleProductList()
        {
            HttpClient client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/IsSaleProductList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<IEnumerable<IsSaleProductsDTO>>(jsonData);

                return View(values);

            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        public async Task<IActionResult> MakeIsSale(Guid productId)
        {
            HttpClient client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/ReadMakeIsSale/{productId}");
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();

                var dto = JsonConvert.DeserializeObject<MakeIsSaleDTO>(jsonData);
                
               
                return View(dto);
            }
            else
            {
                return NotFound();
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeIsSale(Guid productId,MakeIsSaleDTO dto)
        {
            HttpClient client = _httpClient.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7290/api/Product/MakeIsSale/{productId}",content);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("IsSaleProductList");
            }
            else
            {
                return NotFound();
            }
           
        }
        #endregion
        

        #region Colors
        [HttpGet]
        public async Task<IActionResult> ColorList(Guid productId)
        {
           
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> NewColor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewColor(Guid productId)
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateColor(Guid colorId)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Color/GetById/{colorId}");
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateColor(Guid colorId,string s)
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteColor(Guid colorId)
        {
            var client = _httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7290/api/Color/DeleteColor/{colorId}");
            if (response.IsSuccessStatusCode)
            {
                
                return View("Index","Dashboard");
            }
            else
            {
                return NotFound();
            }
            
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid productId)
        {
            var client= _httpClient.CreateClient();
            UpdateProductDTO dto = new();
            var responseForCategory = await client.GetAsync("https://localhost:7290/api/Category/ThirdLevelCategoryList");
            var response = await client.GetAsync($"https://localhost:7290/api/Product/ProductDetail/{productId}");
            if (responseForCategory.IsSuccessStatusCode && response.IsSuccessStatusCode)
            {
                var markListJson = await responseForCategory.Content.ReadAsStringAsync();
                var markList = JsonConvert.DeserializeObject<ICollection<ThirdLevelCategoryDTO>>(markListJson);
                var jsondata = await response.Content.ReadAsStringAsync();
                dto = JsonConvert.DeserializeObject<UpdateProductDTO>(jsondata);
                dto.ThirdLevelCategories = markList;
                return View(dto);
            }
            else
            {

                return NotFound();
            }
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(Guid productId,UpdateProductDTO dto)
        {
            var client = _httpClient.CreateClient();
            var responseForCategory = await client.GetAsync("https://localhost:7290/api/Category/ThirdLevelCategoryList");
            if (responseForCategory.IsSuccessStatusCode)
            {
                var categoryJson = await responseForCategory.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<ICollection<ThirdLevelCategoryDTO>>(categoryJson);
                dto.ThirdLevelCategories = categories;
            }
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            
            var response = await client.PutAsync($"https://localhost:7290/api/Product/UpdateProduct/{productId}", content);
            if (response.IsSuccessStatusCode)
            {

              
                return RedirectToAction("AllProducts","Product");
            }
            else
            {
                return View(dto);
            }

           
        }
        [HttpGet]
        public async Task<IActionResult> DescriptionList(Guid productId)
        {
            ViewBag.ProductId = productId;
            HttpClient client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/DescriptionList/DescriptionListByProduct/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<DescriptionListByProductDTO>>(jsonData);

                return View(values);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddDescription(Guid productId)
        {
            AddDescriptionDTO dto = new();
            ViewBag.ProductId = productId;

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDescription(Guid productId,AddDescriptionDTO dto)
        {
            ViewBag.ProductId = productId;
            HttpClient client = _httpClient.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://localhost:7290/api/DescriptionList/AddDescription/{productId}",content);
            if (response.IsSuccessStatusCode)
            {
                return View("DescriptionList", new {productId=productId});
            }
            else
            {
                ModelState.AddModelError("", "Qeyd boş ola bilməz!");
                return View(dto);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDescription(Guid descriptionId,Guid productId)
        {
            ViewBag.ProductId = productId;
            HttpClient client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/DescriptionList/GetById/{descriptionId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDescriptionDTO>(jsonData);
                

                return View(values);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDescription(Guid descriptionId,Guid productId ,UpdateDescriptionDTO dto)
        {
            ViewBag.ProductId = productId;
            HttpClient client = _httpClient.CreateClient();
            var jsondata=JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7290/api/DescriptionList/UpdateDescription/{descriptionId}",content);
            if (response.IsSuccessStatusCode) {

                return RedirectToAction("DescriptionList",new {productId=productId});
            }
            else
            {
                return View(dto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDescription(Guid descriptionId,Guid productId)
        {
            HttpClient client = _httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7290/api/DescriptionList/DeleteDescription/{descriptionId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("DescriptionList",new {productId=productId });
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> ProductListByMarks(Guid marksId)
        {
            HttpClient client = _httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Product/ProductListByMarks/{marksId}");
            var marksResponse = await client.GetAsync($"https://localhost:7290/api/Marks/ReadMarks/{marksId}");
           
            if (response.IsSuccessStatusCode && marksResponse.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var marksData = await marksResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ProductListByMarksDTO>>(jsonData);
                var marksDTO = JsonConvert.DeserializeObject<ReadMarksDTO>(marksData);
                ViewBag.MarksName = marksDTO.Name;

                return View(values);

            }
            else
            {
                return NotFound();
            }


        }



    }
}
