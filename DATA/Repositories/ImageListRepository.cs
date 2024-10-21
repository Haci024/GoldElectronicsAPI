using Data.Connection;
using Data.Services;
using DTO.DTOS.ProductImagesDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ImageListRepository:GenericRepository<ImageList>,ImageListDAL
    {
        private readonly GoldElectronicsDb _db;
        public ImageListRepository(GoldElectronicsDb db):base(db)
        {
             _db = db;   
        }
        public async Task<IQueryable<ImageListDTO>> ImageListByProduct(Guid productId)
        {
            IQueryable<ImageListDTO> query = _db.ImageList.Include(x => x.Product).Where(x=>x.ProductId==productId).Select(x => new ImageListDTO 
            {
               Id= x.Id,
               Status=x.Status,
               ProductId=productId,
               ImageUrl=x.ImageUrl,
               SavedFileUrl =x.SavedFileUrl
               
        });
            return query;
        }
       
    }
}
