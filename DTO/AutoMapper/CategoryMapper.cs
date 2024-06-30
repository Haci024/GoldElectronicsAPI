using AutoMapper;
using DTO.DTOS.CategoryDTO.Child;
using DTO.DTOS.CategoryDTO.Main;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, NewMainCategoryDTO>();        
            CreateMap<NewMainCategoryDTO, Category>();
            CreateMap<Category, ResultCategoryDTO>();
            CreateMap<ResultCategoryDTO, Category>();
            CreateMap<Category, NewChildCategoryDTO>();
            CreateMap<NewChildCategoryDTO, Category>();
            CreateMap<Category, UpdateMainCategoryDTO>();
            CreateMap<UpdateMainCategoryDTO, Category>();
            CreateMap<Category, UpdateChildCategoryDTO>();
            CreateMap<UpdateChildCategoryDTO, Category>();

        }
    }
}
