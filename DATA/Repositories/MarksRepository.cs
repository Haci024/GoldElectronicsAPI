using Data.Connection;
using Data.Services;
using DTO.DTOS.MarksDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MarksRepository:GenericRepository<Marks>,IMarksDAL
    {
        private readonly GoldElectronicsDb _db;
        public MarksRepository(GoldElectronicsDb db):base(db)
        {
            _db = db;
        }
        public async Task<IQueryable<MarkListDTO>> DeactiveMarkList()
        {
            var query = _db.Marks.Where(x => x.Status == false).Select(x => new MarkListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                
            });
            return query;
        }
        public async Task<IQueryable<MarkListDTO>> ActiveMarkList()
        {
            var query = _db.Marks.Include(x=>x.Products).Where(x => x.Status == true).Select(x => new MarkListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                ProductCount=x.Products.Count()

            });
            return query;

        }

      
     
    }
}
