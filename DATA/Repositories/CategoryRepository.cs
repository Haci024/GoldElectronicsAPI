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
    public class CategoryRepository : GenericRepository<Category>, ICategoryDAL
    {
        private readonly GoldElectronicsDb _db;
        public CategoryRepository(GoldElectronicsDb db):base(db) 
        {
            _db = db;
        }
        public async Task<IQueryable<Category>> ChildCategoryList()
        {
            return  _db.Categories.Where(x=>x.MainCategoryId!=null  && x.Status==true);
        }

        public async Task<IQueryable<Category>> ChildCategoryListByMain(int mainCategoryId)
        {
            return _db.Categories.Include(x=>x.ChildCategories).Where(x=>x.MainCategoryId==mainCategoryId && x.Status==true);
        }

        public async Task<IQueryable<Category>> MainCategoryList()
        {
            return _db.Categories.Where(x => x.MainCategoryId == null  && x.Status==true);
        }
    }
}
