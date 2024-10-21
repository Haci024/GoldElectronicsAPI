using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IContactUsDAL:IGenericDAL<ContactUs>
    {
        Task<IQueryable<ContactUs>> ReadMessageList();
        Task<IQueryable<ContactUs>> UnReadMessageList();

        Task<int> ReadMessageCount();
        Task<int> UnReadMessageCount();
    }
}
