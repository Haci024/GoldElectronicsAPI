using DTO.DTOS.ProductDTO;
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
        Task<IEnumerable<AllProductsDTO>> GetAllProducts();
        Task<IEnumerable<DeactiveProductListDTO>> DeactiveProducts();
        Task<IEnumerable<ProductListWithCategoryDTO>> ProductListWithCategory(Guid categoryId);
        Task<IEnumerable<IsSaleProductListDTO>> IsSaleProductList();
        Task<IEnumerable<ProductListByMarksDTO>> ProductListByMarks(Guid marksId);
        Task<IEnumerable<LastAddedProductsDTO>> LastAddedProductList();
        Task<IEnumerable<ProductListWithCategoryDTO>> ProductDetailSliderList(Guid categoryId);
        Task<int> SimpleProductCount();
        Task<int> TotalProductCount();
        Task<int> DeactiveProductCount();
        Task<int> IsSaleProductCount();
        Task<ProductDetailDTO> ProductDetail(Guid productId);
    }
}
