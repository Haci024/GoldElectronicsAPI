using AutoMapper;
using DTO.DTOS.ProductImagesDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class ImageListMapper:Profile
    {
        public ImageListMapper()
        {
            CreateMap<ImageListDTO, ImageList>();
            CreateMap<ImageList,ImageListDTO>();
            CreateMap<NewImageDTO, ImageList>();
            CreateMap<ImageList,NewImageDTO>();

        }
    }
}
