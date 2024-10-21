using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ISubscriberDAL:IGenericDAL<Subscriber>
    {
        Task<Subscriber> GetByEmail(string email);

        Task<int> DailySubscriberCount();

        Task<int> TotalSubscriberCount();



    }
}
