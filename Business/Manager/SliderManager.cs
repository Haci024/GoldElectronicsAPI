using Business.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class SliderManager:ISliderService
    {
        private readonly ISliderDAL _dal;
        public SliderManager(ISliderDAL dal)
        {

            _dal = dal;

        }

        public async Task<IQueryable<Slider>> ActiveSliders()
        {
           return await  _dal.ActiveSliders();
        }

        public async Task Create(Slider entity)
        {
            await _dal.Create(entity);
        }

        public async Task<IQueryable<Slider>> DeactiveSliders()
        {
          return  await _dal.DeactiveSliders();
        }

        public async Task Delete(Slider entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Slider>> GetAll()
        {
            return await _dal.GetAll();
        }

        public Slider GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task Update(Slider entity)
        {
           await _dal.Update(entity);
        }
    }
}
