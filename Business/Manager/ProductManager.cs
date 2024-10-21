using AutoMapper;
using Business.Services;
using Data.Services;
using DTO.DTOS.ProductDTO;
using DTO.DTOS.ProductImagesDTO;
using Entity.Models;
using Humanizer;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _dal;
        private readonly IMapper _mapper;
        private readonly IGoogleCloudStorageService _googleService;
        public ProductManager(IProductDAL dal,IMapper mapper, IGoogleCloudStorageService googleCloudStorageService)
        {
            _dal = dal;
            _mapper = mapper;
            _googleService = googleCloudStorageService;

        }
        public async Task Create(Product entity)
        {
           await  _dal.Create(entity);
        }

        public async Task<int> DeactiveProductCount()
        {
            return await _dal.DeactiveProductCount();
        }

        public async Task<IEnumerable<DeactiveProductListDTO>> DeactiveProducts()
        {
            return _mapper.Map<IEnumerable<DeactiveProductListDTO>>(await _dal.DeactiveProducts());
        }

        public async Task Delete(Product entity)
        {
            await _dal.Delete(entity);
        }

        public async  Task<IQueryable<Product>> GetAll()
        {
            return await _dal.GetAll();
        }

        public async Task<IEnumerable<AllProductsDTO>> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<AllProductsDTO>>(await _dal.GetAllProducts());
        }

        public  Product GetById(int id)
        {
            return _dal.GetById(id);
        }

        public Task<int> IsSaleProductCount()
        {
           return _dal.IsSaleProductCount();
        }

        public async Task<IEnumerable<IsSaleProductListDTO>> IsSaleProductList()
        {
            return _mapper.Map<IEnumerable<IsSaleProductListDTO>>(await _dal.IsSaleProductList());
        }

        public async Task<IEnumerable<LastAddedProductsDTO>> LastAddedProductList()
        {
            var products =_mapper.Map<IEnumerable<LastAddedProductsDTO>>(await _dal.LastAddedProductList());
           
            foreach (var item in products)
            {
                await GenerateSignedUrl(item);
            }
            return products;
        }
        private async Task GenerateSignedUrl(LastAddedProductsDTO dto)
        {

            if (!string.IsNullOrWhiteSpace(dto.ImageUrl))
            {
                dto.ImageUrl = await _googleService.GetSignedUrl(dto.SavedFileUrl);
            }
        }


        public async Task<IEnumerable<ProductListByMarksDTO>> ProductListByMarks(Guid marksId)
        {

            return _mapper.Map<IEnumerable<ProductListByMarksDTO>>(await _dal.ProductListByMarks(marksId));
        }

        public async Task<IEnumerable<ProductListWithCategoryDTO>> ProductListWithCategory(Guid categoryId)
        {
            return _mapper.Map<IEnumerable<ProductListWithCategoryDTO>>(await _dal.ProductListWithCategory(categoryId));
        }

        public async Task<int> SimpleProductCount()
        {
            return await _dal.SimpleProductCount();
        }

        public async Task<int> TotalProductCount()
        {
            return await _dal.TotalProductCount();
        }

        public async Task Update(Product entity)
        {
            await _dal.Update(entity);
        }

        public async Task<ProductDetailDTO> ProductDetail(Guid productId)
        {
            var products = _mapper.Map<ProductDetailDTO>(await _dal.ProductDetail(productId));
            foreach(ImageListDTO images in products.ProductImages)
            {
                await GenerateSignedUrl(images);
            }
            return products;
        }
        private async Task GenerateSignedUrl(ImageListDTO images)
        {
            if (!string.IsNullOrWhiteSpace(images.ImageUrl))
            {
                images.ImageUrl = await _googleService.GetSignedUrl(images.SavedFileUrl);
            }

        }

        public async Task<IEnumerable<ProductListWithCategoryDTO>> ProductDetailSliderList(Guid categoryId)
        {
            var products = _mapper.Map<IEnumerable<ProductListWithCategoryDTO>>(await _dal.ProductDetailSliderList(categoryId));
            foreach (ProductListWithCategoryDTO images in products)
            {
                await GenerateImageForDetailUrl(images);
            }
            return products;
        }
        private async Task GenerateImageForDetailUrl(ProductListWithCategoryDTO images)
        {
            if (!string.IsNullOrWhiteSpace(images.ImageUrl))
            {
                images.ImageUrl = await _googleService.GetSignedUrl(images.SavedFileUrl);
            }

        }

        public Product GetById(Guid id)
        {
            return _dal.GetById(id);
        }
    }
}
