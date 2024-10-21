using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.DTOS.CommentsDTO;

namespace UI.ViewComponents.Product
{
    public class ReviewStatisticsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public ReviewStatisticsViewComponent(IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;

        }
        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7290/api/Comments/CommentRatesStatistics/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var JsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CommentRatedPercentDTO>(JsonData);
                value.productId = productId;
                return View(value);
            }
            else
            {
                return View("Error");
            }


        }


    }
}
