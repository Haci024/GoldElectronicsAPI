using Business.Services;
using Data.Services;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDAL _dal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageManager(ILanguageDAL dal,IHttpContextAccessor accessor)
        {
            _dal = dal;
            _httpContextAccessor = accessor;
        }
        public async Task Create(Languages entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(Languages entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Languages>> GetAll()
        {
            return await _dal.GetAll();
        }

        public  Languages GetById(int id)
        {
            return  _dal.GetById(id);
        }

        public Languages GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string GetKey(string key)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Languages entity)
        {
            await _dal.Update(entity);
        }
      

    }
}
