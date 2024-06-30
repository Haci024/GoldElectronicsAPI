using Business.Services;
using Data.Services;
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
        public CategoryManager(ICategoryDAL dal)
        {
            _dal = dal;   
        }
        public async Task Create(Category entity)
        {
           await  _dal.Create(entity);
        }

        public async Task Delete(Category entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Category>> GetAll()
        {
            return await _dal.GetAll();
        }

        public  Category GetById(int Id)
        {
           return  _dal.GetById(Id);
        }

        public async Task<IQueryable<Category>> GetChildCategoryByMain(int mainCategoryId)
        {
            return await  _dal.ChildCategoryListByMain(mainCategoryId);
        }

        public async Task Update(Category entity)
        {
            await  _dal.Update(entity);
        }
    }
}
