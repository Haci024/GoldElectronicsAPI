using Microsoft.AspNetCore.Mvc;
using UI.DTOS.SubscriberDTO;

namespace UI.ViewComponents.SubscribeViewComponent
{
    public class SubscribeViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AddSubscriberDTO dto= new AddSubscriberDTO();
            return View(dto);
        }
    }
}
