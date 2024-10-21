using DTO.DTOS.WishListDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IWishListService:IGenericService<WishList>
    {
        void AddWishList(WishListDTO dto);
        Task<int> WishListProductCount();
        Task<List<WishListDetailDTO>> WishListProductsContent();

    }
}
