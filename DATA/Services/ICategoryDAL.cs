using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ICategoryDAL:IGenericDAL<Category>
    {
        Task<IQueryable<Category>> MainCategoryList();

        Task<IQueryable<Category>> ChildCategoryList();

        Task<IQueryable<Category>> ChildCategoryListByMain(int mainCategoryId);
    }
}
