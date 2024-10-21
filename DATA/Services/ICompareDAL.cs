using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ICompareDAL:IGenericDAL<Compare>
    {
         Task<int> ViewCompareCount();
    }
}
