using Business.Services;
using Data.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDAL _dal;
        public CompanyManager(ICompanyDAL dal)
        {
            _dal = dal; 
        }
        public async Task Create(Company entity)
        {
          await _dal.Create(entity); 
        }

        public async Task Delete(Company entity)
        {
            await _dal.Delete(entity);  
        }

        public async Task<IQueryable<Company>> GetAll()
        {
            return await _dal.GetAll();
        }

        public Company GetById(int id)
        {
            return _dal.GetById(id);
        }

        public Company GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(Company entity)
        {
            await _dal.Update(entity);
        }
    }
}
