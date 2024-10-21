using Data.Connection;
using Data.Services;
using DTO.DTOS.ColorDTO;
using DTO.DTOS.CommentDTO;
using DTO.DTOS.DescriptionListDTO;
using DTO.DTOS.ProductDTO;
using DTO.DTOS.ProductImagesDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductDAL
    {
        private readonly GoldElectronicsDb _db;
        public ProductRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }
        public async  Task<IQueryable<DeactiveProductListDTO>> DeactiveProducts()
        {
            IQueryable<DeactiveProductListDTO> query = _db.Products.Include(x => x.Category).ThenInclude(x=>x.MainCategory).ThenInclude(x=>x.ChildCategories).Include(x=>x.Marks).Where(x=>x.Status==false).Select(x => new DeactiveProductListDTO
            {
                CategoryName = x.Category.Name,
                MarksId = x.MarksId,
                MarksName=x.Marks.Name,
                Price = x.Price,
                Status = x.Status,
                Name = x.Name,
                Id= x.Id,
                
            });
            return query;
        }

        public async Task<int> SimpleProductCount()
        {
            return await _db.Products.Where(x=>x.Status==true && x.IsSale==false).CountAsync();
        }

        public async Task<IQueryable<AllProductsDTO>> GetAllProducts()
        {
            IQueryable<AllProductsDTO> query = _db.Products.Include(x => x.Marks).Where(x => x.Status == true && x.IsSale == false).Select(x => new AllProductsDTO
            {
                Id = x.Id,
                IsSale = x.IsSale,
                CategoryName = x.Category.Name,
                MarksId = x.MarksId,
                MarkName = x.Marks.Name,
                Price = x.Price,
                SalesPrice = x.SalesPrice,
                MainCategoryName = x.Category.MainCategory.Name,
                Status = x.Status,
                Name = x.Name,


            }); ;
            return  query;
        }

        public async Task<IQueryable<IsSaleProductListDTO>> IsSaleProductList()
        {
            IQueryable<IsSaleProductListDTO> query = _db.Products.Include(x => x.Marks).ThenInclude(x=>x.Products).Where(x=>x.IsSale==true  && x.Status==true).Select(x => new IsSaleProductListDTO
            {
                Id=x.Id,
                CategoryName = x.Category.Name,
                MainCategoryName = x.Category.MainCategory.Name,
                MarksName =x.Marks.Name,
                LastDateForIsSale = (DateTime)x.LastDateForIsSale,
                Price = x.Price,
                MarksId=x.MarksId,
                Status = x.Status,
                SalesPrice = x.SalesPrice,
                IsSale=x.IsSale,
                Name=x.Name,
            });
            return query;
        }

        public async Task<IQueryable<ProductListWithCategoryDTO>> ProductListWithCategory(Guid categoryId)
        {
            IQueryable<ProductListWithCategoryDTO> query = _db.Products.Include(x => x.Marks).Include(x => x.Category).Where(x => x.CategoryId == categoryId && x.Status == true).Select(y => new ProductListWithCategoryDTO
            {
                Id = y.Id,
                Name = y.Name,
                MarksName = y.Marks.Name,
                MainCategoryName = y.Category.MainCategory.Name,
                Status = y.Status,
                MarksId = y.MarksId,
                CategoryName = y.Category.Name,
                SalesPrice = y.SalesPrice,
                IsSale = y.IsSale,
                Price = y.Price,
                CategoryId = y.CategoryId,

            }); ;
            return query;
        }

        public async Task<int> TotalProductCount()
        {
            return await _db.Products.CountAsync();
        }

        public async Task<int> DeactiveProductCount()
        {
            return await _db.Products.Where(x=>x.Status==false).CountAsync();
        }

        public async Task<int> IsSaleProductCount()
        {
            return await _db.Products.Where(x=>x.IsSale==true).CountAsync();
        }

        public async Task<IQueryable<ProductListByMarksDTO>> ProductListByMarks(Guid marksId)
        {
            IQueryable<ProductListByMarksDTO> query = _db.Products.Include(x => x.Marks).Include(x => x.Category).ThenInclude(x=>x.MainCategory).Where(x =>x.Status == true && x.MarksId==marksId  && x.Marks.Status==true).Select(y => new ProductListByMarksDTO
            {
                Id = y.Id,
                Name = y.Name,
                MarkName = y.Marks.Name,
                Status = y.Status,
                MarksId = y.MarksId,
                CategoryName = y.Category.Name,
                MainCategoryName=y.Category.MainCategory.Name,
                SalesPrice = y.SalesPrice,
                AddingDate = y.AddingDate,
                IsSale = y.IsSale,
                Price = y.Price,
                CategoryId = y.CategoryId

            });
            return query;
        }
        
        public async Task<IQueryable<LastAddedProductsDTO>> LastAddedProductList()
        {
            IQueryable<LastAddedProductsDTO> query = _db.Products.Include(x => x.Marks).Include(x => x.Category).Select(x => new LastAddedProductsDTO
            {
                Id = x.Id,
                Name = x.Name,
                MarksId=x.MarksId,
                MarksName = x.Marks.Name,
                ImageUrl=x.ProductImages.First().ImageUrl,
                SavedFileUrl = x.ProductImages.First().SavedFileUrl,
                Price = x.Price,
                SalesPrice = x.SalesPrice,
                IsSale = x.IsSale,
                AddingDate = x.AddingDate,
                Status=x.Status,
                LastDateForIsSale = (DateTime)x.LastDateForIsSale,
                CategoryName=x.Category.Name,
                CategoryId=x.CategoryId,


            }).OrderBy(x=>x.AddingDate).Take(20);
            return query;
        }

        public async Task<ProductDetailDTO> ProductDetail(Guid productId)
        {
            var query = await _db.Products.Include(x => x.Marks).Include(x => x.Category).Include(x => x.DescriptionList).Include(x=>x.Comments).ThenInclude(x=>x.AppUser).Where(x => x.Id == productId).Select(x => new ProductDetailDTO
            {
                Id = x.Id,
                AddingDate = x.AddingDate,
                Status = x.Status,
                SalesPrice = x.SalesPrice,
                LastDateForIsSale=(DateTime)x.LastDateForIsSale,
                IsSale = x.IsSale,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Price = x.Price,
                ColorList = x.Colors.Where(x => x.ProductId == productId).Select(y => new ColorListDTO
                {
                   Id=x.Colors.Where(x=>x.ProductId==productId).Select(x=>x.Id).FirstOrDefault(),
                   Name = y.Name,
                   ProductId = x.Id,
                   Status=y.Status

                }).ToList(),
                DescriptionList = x.DescriptionList.Where(x => x.ProductId == productId).Select(d => new DescriptionListByProductDTO
                {
                    Id=d.Id,
                    ProductId=d.ProductId,
                    Description=d.Description,
                   SkillName=d.SkillName

                }).ToList(),
                ProductImages=x.ProductImages.Where(x=>x.ProductId==productId).Select(pi=> new ImageListDTO
                {
                    Id =pi.Id,
                    ProductId=pi.ProductId,
                    ImageUrl=pi.ImageUrl,
                    SavedFileUrl=pi.SavedFileUrl,
                    Status=pi.Status

                }).ToList(),
                CommentList=x.Comments.Where(x=>x.ProductId==productId).Select(c=>new CommentListByProductDTO
                {
                    productId=c.ProductId,
                    Content=c.Content,
                    MessageDate=c.MessageDate,
                    Rate=c.Rate,
                    FullName=c.AppUser.FullName

                }).OrderByDescending(x=>x.MessageDate).ToList(),
            }).FirstOrDefaultAsync();

           

            return query;
        }

        public async Task<IQueryable<ProductListWithCategoryDTO>> ProductDetailSliderList(Guid categoryId)
        {
            IQueryable<ProductListWithCategoryDTO> query = _db.Products.Include(x => x.Marks).Include(x => x.Category).Where(x=>x.CategoryId==categoryId).Select(x => new ProductListWithCategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                MarksId = x.MarksId,
                MarksName = x.Marks.Name,
                ImageUrl = x.ProductImages.First().ImageUrl,
                SavedFileUrl = x.ProductImages.First().SavedFileUrl,
                Price = x.Price,
                SalesPrice = x.SalesPrice,
                IsSale = x.IsSale,
               AddingDate = x.AddingDate,
                Status = x.Status,
               LastDateForIsSale = (DateTime)x.LastDateForIsSale,
                CategoryName = x.Category.Name,
                CategoryId = x.CategoryId,


            }).OrderBy(x => x.AddingDate).Take(20);
            return query;
        }
    }
}
