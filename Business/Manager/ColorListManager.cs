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
    public class ColorListManager:IColorListService
    {
        private readonly IColorListDAL _dal;
        public ColorListManager(IColorListDAL dal)
        {
            _dal = dal; 
        }

        public async Task Create(ColorList entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(ColorList entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<ColorList>> GetAll()
        {
            return await _dal.GetAll();
        }

        public ColorList GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(ColorList entity)
        {
            await _dal.Update(entity);
        }
    }
}
