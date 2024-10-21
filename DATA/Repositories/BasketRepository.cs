using Azure;
using Data.Connection;
using Data.Services;
using DTO.DTOS.BasketDTO;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketDAL
    {
        private readonly GoldElectronicsDb _db;
        private readonly IHttpContextAccessor _accessor;

        public BasketRepository(GoldElectronicsDb db, IHttpContextAccessor accessor) : base(db)
        {
            _db = db;
            _accessor = accessor;
        }
        public async Task AddtoBasket(Guid productId)
        {
            AddBasketDTO cartItem = new();
            cartItem.ProductId = productId;
            cartItem.Quantity = 1;

            var cartCookie = _accessor.HttpContext.Request.Cookies["OdisseyCookie"];
            List<AddBasketDTO> cartItems;

            if (!string.IsNullOrEmpty(cartCookie))
            {
                try
                {
                    cartItems = JsonSerializer.Deserialize<List<AddBasketDTO>>(cartCookie) ?? new List<AddBasketDTO>();
                }
                catch (JsonException ex)
                {
                    // JSON deserialization hatası
                    Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                    cartItems = new List<AddBasketDTO>(); // Hata durumunda boş liste oluştur
                }
            }
            else
            {
                cartItems = new List<AddBasketDTO>();
            }

            var existingItem = cartItems.FirstOrDefault(x => x.ProductId == cartItem.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            {
                cartItems.Add(cartItem);
            }

            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Domain = "localhost",
                Path = "/",
            };
            var updatedCart = JsonSerializer.Serialize(cartItems);
            _accessor.HttpContext.Response.Cookies.Append("OdisseyCookie", updatedCart, options);
        }
        public IEnumerable<BasketContentDTO> BasketContent()
            {
                var cartCookie = _accessor.HttpContext.Request.Cookies["OdisseyCookie"];
                     
                if (cartCookie != null)
                {
                    var cartItems = JsonSerializer.Deserialize<List<AddBasketDTO>>(cartCookie);
             
                    var productIds = cartItems.Select(x => x.ProductId).ToList();
                    var products =  _db.Products
                        .Include(p => p.ProductImages)
                        .Where(p => productIds.Contains(p.Id))
                        .ToList();
                IEnumerable<BasketContentDTO> content = cartItems.Select(x =>
                    {
                        var product = products.FirstOrDefault(p => p.Id == x.ProductId);
                        return new BasketContentDTO
                        {
                            ProductId = x.ProductId,
                            ProductName = product?.Name,
                            itemCount = x.Quantity,
                            Price = product?.Price ?? 0,
                            TotalPrice = x.Quantity * (product?.Price ?? 0),
                            ImageUrl = product?.ProductImages.FirstOrDefault()?.ImageUrl,
                            SavedImageUrl = product?.ProductImages.FirstOrDefault()?.SavedFileUrl,
                        };
                    }).ToList();

                    return  content;
                }
                else
                {

                IEnumerable<BasketContentDTO> content = new List<BasketContentDTO>();
                return  content;
                }
            }

        

        public async Task<IEnumerable<AllProductsDTO>> GetProductsByIds(List<Guid> productIDs)
        {
            var products = await _db.Products.Where(p => productIDs.Contains(p.Id)).Select(p => new AllProductsDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            }).ToListAsync();


            return products;
        }

        public async Task<BasketViewDTO> ViewBasket()
        {
            var cartCookie = _accessor.HttpContext.Request.Cookies["OdisseyCookie"];
            if (cartCookie != null)
            {
                var cartItems = JsonSerializer.Deserialize<List<AddBasketDTO>>(cartCookie);
                int totalQuantity = cartItems.Count();
                decimal totalPrice = CalculateCartTotalPrice(cartItems);

                return new BasketViewDTO { totalItemCount = totalQuantity, TotalPrice = totalPrice };
            }
            else
            {
                return new BasketViewDTO { totalItemCount = 0, TotalPrice = 0 };
            }
        }
        private decimal CalculateCartTotalPrice(List<AddBasketDTO> products)
        {
            decimal totalPrice = 0m;

            foreach (var item in products)
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product != null)
                {

                    decimal itemTotal = product.Price * item.Quantity;
                    totalPrice += itemTotal;
                }
            }

            return totalPrice;
        }
    }
}
