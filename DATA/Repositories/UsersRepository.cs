using Data.Connection;
using Data.Services;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UsersRepository:GenericRepository<AppUser>,IUsersDAL
    {
        private readonly GoldElectronicsDb _db;
        private readonly UserManager<AppUser> _userManager;
      
        public UsersRepository(GoldElectronicsDb db, UserManager<AppUser> userManager) : base(db)
        {
            _db = db;
            _userManager = userManager;
            

        }

        public async Task<int> AdminCount()
        {
            return (await _userManager.GetUsersInRoleAsync("Admin")).Count();  
        }

        public async Task<int> UserCount()
        {
           
            return (await _userManager.GetUsersInRoleAsync("User")).Count();
        }
    }
}
