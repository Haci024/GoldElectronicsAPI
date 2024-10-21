using DTO.DTOS.CategoryDTO.Child;
using DTO.DTOS.CategoryDTO.Main;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<IEnumerable<ChildCategoryListByMainDTO>> ChildCategoryByMain(Guid mainCategoryId);

        Task<int> ActiveCategroyCount();

        Task<IEnumerable<MainCategoryListDTO>> MainCategoryList();

        Task<IEnumerable<ChildCategoryListDTO>> ChildCategoryList();

        Task<IEnumerable<NavbarCategoryListDTO>> NavbarCategoryList();

        Task<IEnumerable<ThirdLevelCategoryDTO>> ThirdLevelCategoryList();

        Task<int> TotalCategoryCount();
        Task<int> TotalChildCategoryCount();
        Task<int> TotalMainCategoryCount();
        Task<int> TotalDeactiveCategoryCount();
        Task<int> TotalProductCategoryCount();

        Task<string> MainCategoryName(Guid Id);
        Task<string> ChildCategoryName(Guid Id);


    }
}
