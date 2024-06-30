using Business.Services;
using Data.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _dal;
        public ProductManager(IProductDAL dal)
        {
            _dal = dal;
        }
        public async Task Create(Product entity)
        {
           await  _dal.Create(entity);
        }

        public async Task<IQueryable<Product>> DeactiveProducts()
        {
            return await _dal.DeactiveProducts();
        }

        public async Task Delete(Product entity)
        {
            await _dal.Delete(entity);
        }

        public async  Task<IQueryable<Product>> GetAll()
        {
            return await _dal.GetAll();
        }

        public async Task<IQueryable<Product>> GetAllProducts()
        {
            return  await _dal.GetAllProducts();
        }

        public  Product GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task<IQueryable<Product>> IsSaleProductList()
        {
            return  await _dal.IsSaleProductList();
        }

        public async Task<IQueryable<Product>> ProductListByCategory(int categoryId)
        {
            return await _dal.ProductListByCategory(categoryId);
        }

        public async Task Update(Product entity)
        {
            await _dal.Update(entity);
        }
    }
}
