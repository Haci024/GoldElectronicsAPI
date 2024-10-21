using AutoMapper;
using DTO.DTOS.ContactUsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class ContactUsMapper:Profile
    {
        public ContactUsMapper()
        {
            CreateMap<ContactUs,ContactUsListDTO>();
            CreateMap<ContactUsListDTO, ContactUs>();

            CreateMap<ContactUs,NewContactUsDTO>();
            CreateMap<NewContactUsDTO,ContactUs>();

            CreateMap<ContactUs, ReadMessageDTO>();
            CreateMap<ReadMessageDTO, ContactUs>();
        }
    }
}
