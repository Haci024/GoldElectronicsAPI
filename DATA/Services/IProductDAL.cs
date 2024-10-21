using Data.Repositories;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{

    public interface IProductDAL:IGenericDAL<Product>
    {
        #region AdminPanelAndUIPanel   
        #region Lists
        Task<IQueryable<AllProductsDTO>> GetAllProducts();
        Task<IQueryable<IsSaleProductListDTO>> IsSaleProductList();
        #endregion
        #endregion
        #region AdminPanel
        #region Lists
        Task<IQueryable<DeactiveProductListDTO>> DeactiveProducts();
                 Task<IQueryable<ProductListByMarksDTO>> ProductListByMarks(Guid marksId);
                 Task<IQueryable<ProductListWithCategoryDTO>> ProductListWithCategory(Guid categoryId);
                 Task<IQueryable<LastAddedProductsDTO>> LastAddedProductList();
        #endregion
        #region Statistics
                   Task<int> SimpleProductCount();
                   Task<int> TotalProductCount();
                   Task<int> DeactiveProductCount();
                   Task<int> IsSaleProductCount();
                  #endregion
        #endregion
        #region ProductDetail
        Task<IQueryable<ProductListWithCategoryDTO>> ProductDetailSliderList(Guid categoryId);
        Task<ProductDetailDTO> ProductDetail(Guid productId);
        #endregion
    }
}
