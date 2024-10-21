using Data.Connection;
using Data.Services;
using DTO.DTOS.NotficationsDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NotficationsRepository:GenericRepository<Notfications>,INotficationsDAL
    {
        private readonly GoldElectronicsDb _db;
        public NotficationsRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }

        public async Task AddNotficationByAction(int actionId,Guid pageId)
        {
            Notfications notfications = new();
            switch (actionId)
            {
                case 1:
                    notfications.Icon = "mdi mdi-account-plus";
                    notfications.SendingDate = DateTime.Now;
                    notfications.Color = "bg-success";
                    notfications.Title= "Yeni Abunə!";
                    notfications.Description= "Bir nəfər abunə oldu!";
                    notfications.IsView = false;
                    notfications.Url = $"https://localhost:7267/GoldManagementPanel/Subscribers/AllSubscribers/{pageId}";
                    break;
                case 2:
                    notfications.Icon = "mdi mdi-basket-plus";
                    notfications.SendingDate = DateTime.Now;
                    notfications.Color = "bg-danger";
                    notfications.Title = "Yeni Sifariş!";
                    notfications.Description = "Yeni bir sifarişiniz var!";
                    notfications.IsView = false;
                    notfications.Url = $"https://localhost:7267/GoldManagementPanel/Orders/OrderDetail/{pageId}";
                    break;
                case 3:
                    notfications.Icon = "mdi mdi-email";
                    notfications.SendingDate = DateTime.Now;
                    notfications.Color = "bg-warning";
                    notfications.Title = "Bizimlə əlaqə!";
                    notfications.Description = "Yeni bir mesajınız var!";
                    notfications.IsView = false;
                    notfications.Url = $"https://localhost:7267/GoldManagementPanel/ContactUs/ReadMessage/{pageId}";
                    break;
                case 4:
                    notfications.Icon = "mdi mdi-briefcase";
                    notfications.SendingDate = DateTime.Now;
                    notfications.Color = "bg-info";
                    notfications.Title = "Yeni iş müraciəti!";
                    notfications.Description = "Vakansiya üzrə bir nəfər müraciət edib!";
                    notfications.IsView = false;
                    notfications.Url = $"https://localhost:7267/GoldManagementPanel/CvAndCareer/unViewedCvList";
                    break;
                case 5:
                    notfications.Icon = "mdi mdi-lock-alert-outline";
                    notfications.SendingDate = DateTime.Now;
                    notfications.Color = "bg-secondary";
                    notfications.Title = "Şübhəli hərəkətlər!";
                    notfications.Description = "Bir hesab bloklandı!";
                    notfications.IsView = false;
                    notfications.Url = $"https://localhost:7267/GoldManagementPanel/Users/BlockCustomer/{pageId}";
                    break;
                case 6:
                    notfications.Icon = "mdi mdi-hammer-wrench";
                    notfications.SendingDate = DateTime.Now;
                    notfications.Color = "bg-light";
                    notfications.Title = "Texniki dəstək!";
                    notfications.Description = "Texniki dəstək bölməsindən mesajınız var!";
                    notfications.IsView = false;
                    notfications.Url = $"https://localhost:7267/GoldManagementPanel/ContactUs/ReadMessage/{pageId}";
                    break;
                    default:

                    break;
            }
          await   _db.Notfications.AddAsync(notfications);
           await _db.SaveChangesAsync();
        }
        public async Task<int> NotficationCount()
        {
            return await _db.Notfications.Where(x=>x.IsView==false).CountAsync();
        }

        public async Task<IQueryable<NotficationListDTO>> UnViewNotficationList()
        {
            var query = _db.Notfications.Where(x => x.IsView == false).Select(x => new NotficationListDTO { 

           Id=x.Id,
           SendingDate=x.SendingDate,
           IsView=x.IsView,
           Description=x.Description,
           Icon=x.Icon,
           Title=x.Title,
           Url=x.Url,
           Color=x.Color,
            }).OrderByDescending(x=>x.SendingDate);
            return query;
        }
    }
}
