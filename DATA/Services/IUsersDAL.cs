using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IUsersDAL:IGenericDAL<AppUser>
    {
        Task<int> UserCount();

        Task<int> AdminCount();
    }
}
