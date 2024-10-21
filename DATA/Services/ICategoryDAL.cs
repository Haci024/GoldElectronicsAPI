using Data.Repositories;
using DTO.DTOS.CategoryDTO.Child;
using DTO.DTOS.CategoryDTO.Main;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ICategoryDAL:IGenericDAL<Category>
    {
        Task<IQueryable<MainCategoryListDTO>> MainCategoryList();

        Task<IQueryable<ThirdLevelCategoryDTO>> ThirdLevelCategoryList();

        Task<IQueryable<ChildCategoryListByMainDTO>> ChildCategoryListByMain(Guid mainCategoryId);

        

        Task<int> ActiveCategroyCount();

        Task<IQueryable<ChildCategoryListDTO>> ChildCategoryList();

        Task<IQueryable<NavbarCategoryListDTO>> NavbarCategoryList();

        Task<int> TotalCategoryCount();
        Task<int> TotalChildCategoryCount();
        Task<int> TotalMainCategoryCount();
        Task<int> TotalDeactiveCategoryCount();
        Task<int> TotalProductCategoryCount();
        Task<string> MainCategoryName(Guid Id);
        Task<string> ChildCategoryName(Guid Id);

    }
}
