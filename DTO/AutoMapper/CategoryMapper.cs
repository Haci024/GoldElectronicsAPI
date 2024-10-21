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
            CreateMap<Category, NavbarCategoryListDTO>();
            CreateMap<NavbarCategoryListDTO, Category>();
            CreateMap<Category, MainCategoryListDTO>();
            CreateMap<MainCategoryListDTO, Category>();
            CreateMap<Category, NewChildCategoryDTO>();
            CreateMap<NewChildCategoryDTO, Category>();
            CreateMap<Category, UpdateMainCategoryDTO>();
            CreateMap<UpdateMainCategoryDTO, Category>();
            CreateMap<Category, UpdateChildCategoryDTO>();
            CreateMap<UpdateChildCategoryDTO, Category>();
            CreateMap<Category, UpdateThirdCategoryDTO>();
            CreateMap<UpdateThirdCategoryDTO, Category>();
            CreateMap<Category, NewThirdCategoryDTO>();
            CreateMap<NewThirdCategoryDTO, Category>();
            CreateMap<Category, ChildCategoryListDTO>()
           .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.MainCategory.Name));
           CreateMap<ChildCategoryListDTO, Category>();
            CreateMap<Category, ChildCategoryListByMainDTO>().ForMember(dest => dest.mainCategoryId, opt => opt.MapFrom(src => src.MainCategory.Id));
            CreateMap<ChildCategoryListByMainDTO, Category>();
            CreateMap<ChildCategoryListDTO, Category>();
            CreateMap<ReadChildCategoryDTO, Category>();
            CreateMap<Category, ReadChildCategoryDTO>();

           




        }
    }
}
