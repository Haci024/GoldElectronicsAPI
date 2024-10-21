using Data.Repositories;
using DTO.DTOS.WishListDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IWishlistDAL : IGenericDAL<WishList>
    {
        Task<IQueryable<WishList>> CustomerWishList(Guid appUserId);
        Task<int> WishListProductCount();
        Task<List<WishListDetailDTO>> WishListProductsContent();
    }
}
