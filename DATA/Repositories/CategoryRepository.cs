using AutoMapper;
using Data.Connection;
using Data.Services;
using DTO.DTOS.CategoryDTO.Child;
using DTO.DTOS.CategoryDTO.Main;
using DTO.DTOS.MarksDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryDAL
    {
        private readonly GoldElectronicsDb _db;
          
        
        public CategoryRepository(GoldElectronicsDb db):base(db) 
        {
            _db = db;
           
        }

        public async  Task<int> ActiveCategroyCount()
        {
            return await _db.Categories.Where(x=>x.Status==true && x.MainCategoryId!=null).CountAsync();
        }

       

        public async Task<IQueryable<ChildCategoryListByMainDTO>> ChildCategoryListByMain(Guid mainCategoryId)
        {
            IQueryable<ChildCategoryListByMainDTO> query = _db.Categories.Include(x => x.MainCategory).Where(x => x.MainCategoryId ==mainCategoryId && x.Status==true).Select(y => new ChildCategoryListByMainDTO
            {
                Id = y.Id,
                Name = y.Name,
                Status = y.Status,
                mainCategoryId=(Guid)y.MainCategory.Id
            });
            return query;
        }

        public async Task<IQueryable<MainCategoryListDTO>> MainCategoryList()
        {
            IQueryable<MainCategoryListDTO> query = _db.Categories.Include(x => x.MainCategory).Where(x => x.MainCategoryId == null  || x.MainCategory.MainCategoryId!=null).Select(y => new MainCategoryListDTO
            {
                Id = y.Id,
                Name = y.Name,
                Status = y.Status,
            });
            return query;
        }
        public async Task<IQueryable<ChildCategoryListDTO>> ChildCategoryList()
        {
            IQueryable<ChildCategoryListDTO> query = _db.Categories.Where(x=>x.MainCategoryId.HasValue  && _db.Categories.Any(pc => pc.Id == x.MainCategoryId && pc.MainCategoryId == null)).Select(y => new ChildCategoryListDTO
            {
                Id = y.Id,
                Name = y.Name,
                MainCategoryId = y.MainCategoryId,
                Status = y.Status,
                MainCategoryName= y.MainCategory.Name,
            });


            return query;
        }

        public  async Task<int> TotalCategoryCount()
        {
            return await _db.Categories.Where(x => x.Status == true).CountAsync();
        }

        public async Task<int> TotalChildCategoryCount()
        {
            return await _db.Categories.Where(x => x.MainCategoryId.HasValue && _db.Categories.Any(pc => pc.Id == x.MainCategoryId && pc.MainCategoryId == null)).CountAsync();
        }

        public async Task<int> TotalMainCategoryCount()
        {
            return await _db.Categories.Where(x=>x.Status==true && x.MainCategoryId==null).CountAsync();
        }

        public async Task<int> TotalDeactiveCategoryCount()
        {
            return await _db.Categories.Include(x=>x.MainCategory).Where(x => x.Status == false).CountAsync();
        }

        public async Task<string> MainCategoryName(Guid Id)
        {
            return await _db.Categories.Where(x => x.Id == Id).Select(x => x.Name).FirstOrDefaultAsync();

        }
        public async Task<string> ChildCategoryName(Guid Id)
        {
            return await _db.Categories.Where(x => x.Id == Id).Select(x => x.Name).FirstOrDefaultAsync();

        }

        public async Task<IQueryable<NavbarCategoryListDTO>> NavbarCategoryList()
        {
            IQueryable<NavbarCategoryListDTO> query = _db.Categories.Include(x => x.MainCategory).Include(x=>x.ChildCategories).Include(x=>x.Products).Where(x =>x.Status==true).Select(mc => new NavbarCategoryListDTO
            {
                Id= mc.Id,
                CategoryName=mc.Name,
                ImageUrl=mc.ImageUrl,
                MainCategoryId=mc.MainCategoryId,

                ChildCategories = mc.ChildCategories.Select(cc => new ChildCategoryListDTO
                {
                    Id = cc.Id,
                    Name = cc.Name,
                    MainCategoryId = cc.MainCategoryId,
                    Status=cc.Status,
                    CategoryOrMarks=cc.CategoryOrMarks,
                    ThirdLevelCategory = cc.ChildCategories.Where(x => x.Status == true).Select(ml => new ThirdLevelCategoryDTO
                    {
                        Id = ml.Id,
                        MainCategoryId =cc.MainCategoryId,
                        Name = ml.Name,
                        MainCategoryName = cc.MainCategory.Name,
                        Status = ml.Status,
                        ProductCount = ml.Products.Where(x => x.Status == true).Count(),


                    }).OrderBy(x => x.Name).ToList(),
                    MarkList=_db.Marks.Include(m=>m.Products).Where(m=>m.Products.Any(m=>m.CategoryId==cc.Id)).Select(m=>new MarkListDTO
                    {
                        Id=m.Id,
                        Name=m.Name,
                        ProductCount=m.Products.Count(),

                    }).OrderBy(x=>x.Name).ToList(),
                    
                }).OrderBy(x=>x.Name).ToList(),

            }).OrderBy(x=>x.Id);
         return query;
        }

        public async Task<IQueryable<ThirdLevelCategoryDTO>> ThirdLevelCategoryList()
        {
            var query = _db.Categories.Include(x => x.MainCategory).ThenInclude(x => x.ChildCategories).Include(x=>x.Products).Where(x=>x.MainCategory.MainCategoryId!=null).Select(x => new ThirdLevelCategoryDTO { 

                Id=x.Id,
                MainCategoryId=x.MainCategoryId,
                MainCategoryName=x.MainCategory.Name,
                Name=x.Name,
                Status=x.Status,
                ProductCount=x.Products.Count()


            });

            return query;
        }

        public async Task<int> TotalProductCategoryCount()
        {
            return await  _db.Categories.Where(x => x.MainCategory.MainCategoryId != null).CountAsync();
        }
    }
}
