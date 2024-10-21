using AutoMapper;
using Business.Services;
using Data.Services;
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
    public class UserManager:IUserService
    {  
        private readonly IUsersDAL _dal;
        private readonly IMapper _mapper;
        public UserManager( IMapper mapper,IUsersDAL dal)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public Task Create(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CustomerCount()
        {
            return await _dal.UserCount();
        }

        public Task Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AppUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int id)
        {
            return _dal.GetById(id);
        }

        public AppUser GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public Task Update(AppUser entity)
        {
           return _dal.Update(entity);
        }
    }

}
