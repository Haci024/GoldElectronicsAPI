using Data.Connection;
using Data.Services;
using DTO.DTOS.CvAndCareerDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CvAndCareerRepository:GenericRepository<CvAndCareer>,ICvAndCareerDAL
    {
        private readonly GoldElectronicsDb _db;
        public CvAndCareerRepository(GoldElectronicsDb db):base(db) {
        
        _db = db;
        }

        public async Task<IQueryable<CVListDTO>> UnViewedCvList()
        {
            var query = _db.CvAndCareers.Where(x => x.IsView == false).Select(x => new CVListDTO
            {

                Id = x.Id,
                FileUrl = x.FileUrl,
                SavedFileUrl = x.SavedFileUrl,
                SendingDate = x.SendingDate,
                WorkType = x.WorkType,
                Email= x.Email, 

            });

            return query;
        }

        public async Task<IQueryable<CVListDTO>> ViewedCvList()
        {
           var query= _db.CvAndCareers.Where(x=>x.IsView==true).Select(x=> new CVListDTO{

               Id=x.Id,
               FileUrl=x.FileUrl,
               SavedFileUrl=x.SavedFileUrl,
               SendingDate=x.SendingDate,
               WorkType=x.WorkType,
               Email= x.Email,
               
            });

            return query;
        }
    }
}
