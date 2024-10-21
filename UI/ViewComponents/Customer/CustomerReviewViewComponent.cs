using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.CustomerReviewViewComponent
{
    public class CustomerReviewViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;
        public CustomerReviewViewComponent(IHttpClientFactory httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
          ViewBag.ProductId = productId;
            return View();
        }
    }
}
