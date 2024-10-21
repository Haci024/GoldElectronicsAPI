using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IContactUsService:IGenericService<ContactUs>
    {
        Task<IQueryable<ContactUs>> UnReadMessageList();

        Task<IQueryable<ContactUs>> ReadMessageList();

        Task<int> ReadMessageCount();

        Task<int> UnReadReadMessageCount();
    }
}
