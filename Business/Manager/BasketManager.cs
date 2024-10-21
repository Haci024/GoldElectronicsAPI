using Business.Services;
using Data.Connection;
using Data.Services;
using DTO.DTOS.BasketDTO;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDAL _basketDAL;
        private readonly IGoogleCloudStorageService _googleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GoldElectronicsDb _db;
        public BasketManager(IBasketDAL basketDAL,IHttpContextAccessor contextAccessor,IGoogleCloudStorageService googleService, GoldElectronicsDb productService)
        {
            _basketDAL = basketDAL;
            _httpContextAccessor = contextAccessor;
            _googleService = googleService;
            _db = productService;
        }
       
        public  List<AddBasketDTO> ViewBasket()
        {
            var cartCookie = _httpContextAccessor.HttpContext.Request.Cookies["OdisseyCookie"];

            if (cartCookie != null)
            {
                
                var productsInCookie = JsonSerializer.Deserialize<List<AddBasketDTO>>(cartCookie);

                
                var productIds = productsInCookie.Select(p => p.ProductId).ToList();

                
                var dbProducts = _db.Products.Include(x=>x.ProductImages).Where(x => productIds.Contains(x.Id)).ToList();

                var content = productsInCookie.Select(x =>
                {
                    var product = dbProducts.FirstOrDefault(p => p.Id == x.ProductId);
                    return new AddBasketDTO
                    {
                        ProductId = x.ProductId,        
                        Quantity = x.Quantity,
                    };
                }).ToList();




                return content;
            }

            return new List<AddBasketDTO>(); 
        }

        public async Task Create(Basket entity)
        {
            await _basketDAL.Create(entity);
        }

        public async Task Delete(Basket entity)
        {
            await _basketDAL.Delete(entity);
        }

        public async Task<IQueryable<Basket>> GetAll()
        {
            return await _basketDAL.GetAll();
        }

        public  Basket GetById(int id)
        {
            return   _basketDAL.GetById(id);
        }

        public async Task<IEnumerable<AllProductsDTO>> GetProductsByIds(List<Guid> productIDs)
        {
            return await _basketDAL.GetProductsByIds(productIDs);
        }

        public async Task Update(Basket entity)
        {
            await _basketDAL.Update(entity);
        }

        public IEnumerable<BasketContentDTO> BasketContent()
        {
            IEnumerable<BasketContentDTO> basketContent= _basketDAL.BasketContent();

            foreach (var item in basketContent)
            {
                GenerateSignedUrl(item);
            }
            
            return basketContent;
        }
        private async Task GenerateSignedUrl(BasketContentDTO dto)
        {

            if (!string.IsNullOrWhiteSpace(dto.ImageUrl))
            {
                dto.ImageUrl = await _googleService.GetSignedUrl(dto.SavedImageUrl);
            }
        }

        public async Task<BasketViewDTO> BasketView()
        {

            return await _basketDAL.ViewBasket();
        }

        public async Task AddToBasket(Guid productId)
        {
          await  _basketDAL.AddtoBasket(productId);
        }

        public Basket GetById(Guid id)
        {
            return _basketDAL.GetById(id);
        }
    }
}
