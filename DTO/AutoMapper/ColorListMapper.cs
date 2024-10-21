using AutoMapper;
using DTO.DTOS.ColorDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class ColorListMapper:Profile
    {
        public ColorListMapper()
        {
            CreateMap<ColorList, NewColorDTO>();
            CreateMap<NewColorDTO, ColorList>();

             
            CreateMap<DeleteColorDTO , ColorList>();
            CreateMap<ColorList, DeleteColorDTO>();
           
            CreateMap<ColorList,UpdateColorDTO>();
            CreateMap<UpdateColorDTO, ColorList>();

            CreateMap<ColorList, ColorListDTO>();
            CreateMap<ColorListDTO, ColorList>();
        }
    }
}
