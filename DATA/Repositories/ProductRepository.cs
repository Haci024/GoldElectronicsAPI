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
    public class ProductRepository : GenericRepository<Product>, IProductDAL
    {
        private readonly GoldElectronicsDb _db;
        public ProductRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }
        public async  Task<IQueryable<Product>> DeactiveProducts()
        {
            return  _db.Products.Where(x=>x.Status==false);
        }

        public async Task<IQueryable<Product>> GetAllProducts()
        {
            return  _db.Products.Where(x =>x.Status==true);
        }

        public async Task<IQueryable<Product>> IsSaleProductList()
        {
            return _db.Products.Where(x=>x.IsSale==true  && x.Status==true);
        }

        public  async Task<IQueryable<Product>> ProductListByCategory(int categoryId)
        {
            return _db.Products.Include(x => x.Category).Where(x => x.CategoryId == categoryId && x.Status == true);
        }
    }
}
