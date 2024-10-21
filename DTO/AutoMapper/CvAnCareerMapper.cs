using AutoMapper;
using DTO.DTOS.CvAndCareerDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class CvAnCareerMapper:Profile
    {
        public CvAnCareerMapper()
        {
            CreateMap<AddCvDTO,CvAndCareer>();
            CreateMap<CvAndCareer, AddCvDTO>();
            CreateMap<CVListDTO, CvAndCareer>();
            CreateMap<CvAndCareer, CVListDTO>();
         

        }
    }
}
