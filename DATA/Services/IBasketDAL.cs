using Data.Repositories;
using DTO.DTOS.BasketDTO;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IBasketDAL : IGenericDAL<Basket>
    {
        Task<IEnumerable<AllProductsDTO>> GetProductsByIds(List<Guid> productIDs);

        IEnumerable<BasketContentDTO> BasketContent();
        
        Task<BasketViewDTO> ViewBasket();

        Task  AddtoBasket(Guid  productId);
    }
}
