using AutoMapper;
using DTO.DTOS.DescriptionListDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class DescriptionListMapper:Profile
    {
        public DescriptionListMapper()
        {
            CreateMap<AddDescriptionDTO, DescriptionList>();
            CreateMap<UpdateDescriptionDTO, DescriptionList>();
            CreateMap<DescriptionListByProductDTO, DescriptionList>();

        }
    }
}
