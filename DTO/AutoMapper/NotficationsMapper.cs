using AutoMapper;
using DTO.DTOS.NotficationsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class NotficationsMapper:Profile
    {
        public NotficationsMapper()
        {
            CreateMap<NotficationListDTO, Notfications>();
            CreateMap<Notfications, NotficationListDTO>();
            CreateMap<AddNotficationDTO, Notfications>();
            CreateMap<Notfications, AddNotficationDTO>();
        }
    }
}
