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
    public class MarksManager : IMarkService
    {
        private readonly IMarksDAL _dal;
        public MarksManager(IMarksDAL dal)
        {
            _dal = dal;
        }
        public async Task Create(Marks entity)
        {
            await _dal.Create(entity);  
        }

        public async Task Delete(Marks entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Marks>> GetAll()
        {
            return await  _dal.GetAll();
        }

        public Marks GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(Marks entity)
        {
            await _dal.Update(entity);
        }
    }
}
