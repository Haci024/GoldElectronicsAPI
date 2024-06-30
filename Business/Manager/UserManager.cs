using AutoMapper;
using Business.Services;
using DTO.DTOS.UsersDTO.LoginDTO;
using DTO.DTOS.UsersDTO.RegisterDTO;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class UserManager : IUserService
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly IMapper _mapper;

        public UserManager(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;

            _mapper = mapper;
        }




        public async Task<IdentityResult> RegisterUser(NewUserDTO dto)
        {
            AppUser appUser = new();
            _mapper.Map(appUser, dto);
            return await _userManager.CreateAsync(appUser, dto.Password);
        }

    }

}
