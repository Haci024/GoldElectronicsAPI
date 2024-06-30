using AutoMapper;
using DTO.DTOS.SubscriberDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class SubscriberMapper:Profile
    {
        public SubscriberMapper()
        {
            CreateMap<NewSubscriberDTO, Subscriber>();
            CreateMap<Subscriber, Subscriber>();
            CreateMap<SubscriberListDTO, Subscriber>();
            CreateMap<Subscriber, SubscriberListDTO>();
            CreateMap<RemoveSubscriberDTO, Subscriber>();
            CreateMap<Subscriber, RemoveSubscriberDTO>();
        }
    }
}
