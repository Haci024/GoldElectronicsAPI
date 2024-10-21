using Business.Services;
using Data.Services;
using DTO.DTOS.BasketDTO;
using DTO.DTOS.WishListDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class WishListManager:IWishListService
    {
        private readonly IWishlistDAL _dal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WishListManager(IWishlistDAL dal,IHttpContextAccessor httpContextAccessor)
        {
            _dal = dal;
            _httpContextAccessor= httpContextAccessor;
        }

        public async Task Create(WishList entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(WishList entity)
        {
            await _dal.Delete(entity);  
        }

        public async Task<IQueryable<WishList>> GetAll()
        {
            return await _dal.GetAll();
        }

        public  WishList GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(WishList entity)
        {
           await _dal.Update(entity);
        }
        public void AddWishList(WishListDTO dto)
        {
            var wishcookie = _httpContextAccessor.HttpContext.Request.Cookies["WishListCookie"];
            List<WishListDTO> wishProducts;

            if (wishcookie != null)
            {
                wishProducts = JsonSerializer.Deserialize<List<WishListDTO>>(wishcookie);
            }
            else
            {
                wishProducts = new List<WishListDTO>();
            }


            var existingItem = wishProducts.FirstOrDefault(x => x.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                wishProducts.Remove(existingItem);
                wishProducts.Add(dto);
            }
            else
            {

                wishProducts.Add(dto);
            }


            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            };

            var updatedCart = JsonSerializer.Serialize(wishProducts);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("WishListCookie", updatedCart, options);
        }

        public async Task<int> WishListProductCount()
        {
            return await _dal.WishListProductCount();
        }

        public async Task<List<WishListDetailDTO>> WishListProductsContent()
        {
            return await  _dal.WishListProductsContent();
        }

        public WishList GetById(Guid id)
        {
            return _dal.GetById(id);
        }
    }
}
