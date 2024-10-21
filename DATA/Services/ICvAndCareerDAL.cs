using Data.Repositories;
using DTO.DTOS.CvAndCareerDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ICvAndCareerDAL:IGenericDAL<CvAndCareer>
    {
        Task<IQueryable<CVListDTO>> UnViewedCvList();

        Task<IQueryable<CVListDTO>> ViewedCvList();
    }
}
