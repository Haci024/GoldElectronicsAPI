using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductService:IGenericService<Product>
    {
        Task<IQueryable<Product>> GetAllProducts();
        Task<IQueryable<Product>> DeactiveProducts();
        Task<IQueryable<Product>> ProductListByCategory(int categoryId);
        Task<IQueryable<Product>> IsSaleProductList();
    }
}
