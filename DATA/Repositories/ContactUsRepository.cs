using Data.Connection;
using Data.Services;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactUsRepository:GenericRepository<ContactUs>,IContactUsDAL
    {
        private readonly GoldElectronicsDb _db;
        public ContactUsRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }

        public async Task<int> ReadMessageCount()
        {
            return await  _db.ContactUs.Where(x => x.IsView == true).CountAsync();
        }

        public async Task<IQueryable<ContactUs>> ReadMessageList()
        {
            return  _db.ContactUs.Where(x => x.IsView == true);
        }

        public async Task<int> UnReadMessageCount()
        {
            return await  _db.ContactUs.Where(x => x.IsView == false).CountAsync();
        }

        public async Task<IQueryable<ContactUs>> UnReadMessageList()
        {
            return  _db.ContactUs.Where(x=>x.IsView == false); 
        }
     

     
    }
}
