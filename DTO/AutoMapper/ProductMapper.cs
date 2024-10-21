using AutoMapper;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<Product,NewProductDTO>();
            CreateMap<NewProductDTO, Product>();

            CreateMap<Product, ProductListDTO>();
            CreateMap<ProductListDTO, Product>();

            CreateMap<Product, ProductListDTO>();
            CreateMap<ProductListDTO, Product>();

            CreateMap<Product, ProductListByMarksDTO>();
            CreateMap<ProductListByMarksDTO, Product>();

            CreateMap<Product, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>();

            CreateMap<Product, ReadProductDTO>();
            CreateMap<ReadProductDTO, Product>();

            CreateMap<Product, ProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, Product>();

          

            CreateMap<Product, IsSaleProductListDTO>();
            CreateMap<IsSaleProductListDTO, Product>();

            CreateMap<Product, MakeIsSaleProductDTO>();
            CreateMap<MakeIsSaleProductDTO, Product>();

            CreateMap<Product, AllProductsDTO>();
            CreateMap<AllProductsDTO, Product>();

            CreateMap<Product, DeactiveProductListDTO>();
            CreateMap<DeactiveProductListDTO, Product>();

            CreateMap<Product, LastAddedProductsDTO>();
            CreateMap<LastAddedProductsDTO, Product>();

            CreateMap<Product, ProductDetailDTO>();
            CreateMap<ProductDetailDTO, Product>();
        }
    }
}
