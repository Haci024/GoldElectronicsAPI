using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.GoldManagementPanel.ViewComponents.Product
{
    public class ProductListByCategoryViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductListByCategoryViewComponent(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();       
                }
    }
}
