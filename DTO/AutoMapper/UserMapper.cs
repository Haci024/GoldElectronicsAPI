using AutoMapper;
using DTO.DTOS.UsersDTO.LoginDTO;
using DTO.DTOS.UsersDTO.RegisterDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AutoMapper
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<LoginUserDTO, AppUser>();
            CreateMap<AppUser,LoginUserDTO>();
            CreateMap<NewUserDTO, AppUser>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.ConfirmCode, opt => opt.MapFrom(src => GenerateConfirmCode())); 
            CreateMap<AppUser, NewUserDTO>();
        }
        private int GenerateConfirmCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
