using AutoMapper;
using DTO.DTOS.MarksDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class MarksMapper:Profile
    {
        public MarksMapper()
        {
            CreateMap<AddMarkDTO, Marks>();
            CreateMap<Marks, AddMarkDTO>();
            CreateMap<ReadMarksDTO, Marks>();
            CreateMap<Marks, ReadMarksDTO>();
            CreateMap<Marks, UpdateMarkDTO>();
            CreateMap<UpdateMarkDTO, Marks>();
            CreateMap<Marks, MarkListDTO>();
            CreateMap<MarkListDTO, Marks>();
        }
    }
}
