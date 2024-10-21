using Data.Connection;
using Data.Services;
using DTO.DTOS.WishListDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class WishListRepository:GenericRepository<WishList>,IWishlistDAL
    {
        private readonly GoldElectronicsDb _db;
        private readonly IHttpContextAccessor _httpContextAccessory;
        public WishListRepository(GoldElectronicsDb db, IHttpContextAccessor httpContextAccessory) : base(db)
        {
            _db = db;
            _httpContextAccessory = httpContextAccessory;

        }

        public async Task<IQueryable<WishList>> CustomerWishList(Guid appUserId)
        {
            return  _db.WishLists.Include(x => x.AppUser).Include(x => x.Products).Where(x => x.AppUserId == appUserId);
        }

        public async Task<int> WishListProductCount() {

            var cartCookie = _httpContextAccessory.HttpContext.Request.Cookies["WishListCookie"];
            if (cartCookie!=null)
            {
                var cartItems = JsonSerializer.Deserialize<List<WishListDTO>>(cartCookie);
                int totalQuantity = cartItems.Count();
                
                return   totalQuantity;
            }
            else
            {
                return 0;
            }

         
        }
        public async Task<List<WishListDetailDTO>> WishListProductsContent()
        {
            var cartCookie = _httpContextAccessory.HttpContext.Request.Cookies["WishListCookie"];

            if (cartCookie != null)
            {
                try
                {
                    var cartItems = JsonSerializer.Deserialize<IEnumerable<WishListDTO>>(cartCookie);

                    if (cartItems != null && cartItems.Any())
                    {
                        var productIDs = cartItems.Select(x => x.ProductId).ToList();

                        // Fetching products from the database
                        var products = await _db.Products
                            .Where(x => productIDs.Contains(x.Id))
                            .Select(x => new WishListDetailDTO
                            {
                                Id = x.Id,
                                ProductName = x.Name,
                                Price = x.Price
                            })
                            .ToListAsync();

                        return products;
                    }
                }
                catch (JsonException ex)
                {
                
                }
            }

            
            return new List<WishListDetailDTO>();
        }

    }
}
