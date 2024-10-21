using Data.Connection;
using Data.Services;
using DTO.DTOS.DescriptionListDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DescriptionListRepository:GenericRepository<DescriptionList>,IDescriptionListDAL
    {
        private readonly GoldElectronicsDb _db;
        public DescriptionListRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;   
        }

        public async Task<IQueryable<DescriptionListByProductDTO>> GetDescriptionList(Guid productId)
        {
            IQueryable<DescriptionListByProductDTO> query= _db.DescriptionList.Include(x => x.Product).Where(x=>x.ProductId==productId).Select(x => new DescriptionListByProductDTO { 

                Description=x.Description,
                ProductId=productId,
                Id=x.Id
            });

            return query;
        }
    }
}
