using Business.Services;
using DTO.DTOS.NotficationsDTO;
using Entity.Models;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly  IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IContactUsService _contactUsService;
        private readonly ISubscriberService _subscriberService;
        private readonly INotficationService _notificationService;
        private readonly ICommentService _commentService;

        public SignalRHub(IProductService productService, ICategoryService categoryService,ICommentService commentService, IContactUsService contactUsService, ISubscriberService subscriberService, INotficationService notificationService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _contactUsService = contactUsService;
            _subscriberService = subscriberService;
            _notificationService = notificationService;
            _commentService = commentService;
        }
        public static int clientCount { get; set; } = 0;
       
        public async Task Statistics()
        {
            int categoryCount =await _categoryService.TotalCategoryCount();
            await Clients.All.SendAsync("TotalCategoryCount", categoryCount);

            int productCount =await _productService.TotalProductCount();
            await Clients.All.SendAsync("TotalProductCount", productCount);

            int unReadMessageCount =await _contactUsService.UnReadReadMessageCount();
            await Clients.All.SendAsync("UnReadMessageCount", unReadMessageCount);
           
            int subscriberCount =await _subscriberService.DailySubscriberCount();
            await Clients.All.SendAsync("DailySubscriberCount", subscriberCount);

            int allSubscribersCount = await _subscriberService.TotalSubscriberCount();
            await Clients.All.SendAsync("AllSubscribersCount", allSubscribersCount);

        }
        public  async Task MessageStatistic()
        {
            int unReadMessageCount = await _contactUsService.UnReadReadMessageCount();
            await Clients.All.SendAsync("UnReadMessages", unReadMessageCount);
        }

        public async Task NotficationStatistics()
        {
            int notficationCount = await _notificationService.NotficationCount();
            await Clients.All.SendAsync("NotficationsCount", notficationCount);

            var notfications=await _notificationService.UnViewNotficationList();
            await Clients.All.SendAsync("NotficationList",notfications);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
        public async Task CommentStatistic(Guid productId)
        {
            var commentStatistics = await _commentService.GetCommentRatedPercent(productId);
            await Clients.All.SendAsync("CommentStatistics", commentStatistics);
        }


    }
}
