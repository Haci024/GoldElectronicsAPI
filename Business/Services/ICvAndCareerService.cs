﻿using DTO.DTOS.CvAndCareerDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICvAndCareerService:IGenericService<CvAndCareer>
    {
        Task<IEnumerable<CVListDTO>> UnViewedCvList();

        Task<IEnumerable<CVListDTO>> ViewedCvList();


    }
}
