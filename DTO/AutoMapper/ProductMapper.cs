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

            CreateMap<Product, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>();

            CreateMap<Product, ReadProductDTO>();
            CreateMap<ReadProductDTO, Product>();

            CreateMap<Product, ProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, Product>();

        }
    }
}
