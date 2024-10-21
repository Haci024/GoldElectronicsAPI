using AutoMapper;
using Business.Services;
using Data.Repositories;
using Data.Services;
using DTO.DTOS.CategoryDTO.Child;
using DTO.DTOS.CategoryDTO.Main;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _dal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDAL dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<int> ActiveCategroyCount()
        {
            return await _dal.ActiveCategroyCount();
        }

        public async Task Create(Category entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(Category entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Category>> GetAll()
        {
            return await _dal.GetAll();
        }

        public Category GetById(int Id)
        {
            return _dal.GetById(Id);
        }

        public async Task<IEnumerable<ChildCategoryListByMainDTO>> ChildCategoryByMain(Guid mainCategoryId)
        {
            return _mapper.Map<IEnumerable<ChildCategoryListByMainDTO>>(await _dal.ChildCategoryListByMain(mainCategoryId));
        }

        public async Task Update(Category entity)
        {
            await _dal.Update(entity);
        }

        public async Task<IEnumerable<MainCategoryListDTO>> MainCategoryList()
        {

            return _mapper.Map<IEnumerable<MainCategoryListDTO>>(await _dal.MainCategoryList());
        }

        public async Task<IEnumerable<ChildCategoryListDTO>> ChildCategoryList()
        {

            
            return _mapper.Map<IEnumerable<ChildCategoryListDTO>>(await _dal.ChildCategoryList());
        }

        public Task<int> TotalCategoryCount()
        {
            return _dal.TotalCategoryCount();
        }

        public Task<int> TotalChildCategoryCount()
        {
            return _dal.TotalChildCategoryCount();
        }

        public Task<int> TotalMainCategoryCount()
        {
           return _dal.TotalMainCategoryCount();
        }

        public Task<int> TotalDeactiveCategoryCount()
        {
            return _dal.TotalDeactiveCategoryCount();    
        }

        public Task<string> MainCategoryName(Guid Id)
        {
            return _dal.MainCategoryName(Id);
        }

        public async Task<string> ChildCategoryName(Guid Id)
        {
            return await _dal.ChildCategoryName(Id);
        }

        public async Task<IEnumerable<NavbarCategoryListDTO>> NavbarCategoryList()
        {
            return  _mapper.Map<IEnumerable<NavbarCategoryListDTO>>(await _dal.NavbarCategoryList());
        }

        public async Task<IEnumerable<ThirdLevelCategoryDTO>> ThirdLevelCategoryList()
        {
            return _mapper.Map<IEnumerable<ThirdLevelCategoryDTO>>(await _dal.ThirdLevelCategoryList());
        }

        public async Task<int> TotalProductCategoryCount()
        {
            return await _dal.TotalProductCategoryCount();
        }

        public Category GetById(Guid id)
        {
            return _dal.GetById(id);
        }
    }
}
