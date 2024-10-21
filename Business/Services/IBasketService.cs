using DTO.DTOS.BasketDTO;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IBasketService:IGenericService<Basket>
    {
       Task<IEnumerable<AllProductsDTO>> GetProductsByIds(List<Guid> productIDs);

        IEnumerable<BasketContentDTO> BasketContent();

       Task  AddToBasket(Guid  productId);

        

        Task<BasketViewDTO> BasketView();

        List<AddBasketDTO> ViewBasket();
    }
}
