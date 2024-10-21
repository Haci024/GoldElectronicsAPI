using Data.Connection;
using Data.Services;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Repositories
{
    public class SubscriberRepository:GenericRepository<Subscriber>,ISubscriberDAL
    {
        private readonly GoldElectronicsDb _db;
        public SubscriberRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }

        public async Task<int> DailySubscriberCount()
        {
            DateTime date= DateTime.Today;

            return await _db.Subscribers.Where(x=>x.SubscribeDate.Date==date).CountAsync();
        }

        public async Task<Subscriber> GetByEmail(string email)
        {

            return await _db.Subscribers.Where(x=>x.Email==email).FirstOrDefaultAsync();
        }

        public async Task<int> TotalSubscriberCount()
        {
            return await _db.Subscribers.CountAsync();
        }
    }
}
