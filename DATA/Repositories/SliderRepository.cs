using Business.Services;
using Data.Connection;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SliderRepository:GenericRepository<Slider>,ISliderDAL
    {
        private readonly GoldElectronicsDb _db;
        public SliderRepository(GoldElectronicsDb db):base(db)
        {
            _db=db;
        }

        public async Task<IQueryable<Slider>> ActiveSliders()
        {
            return  _db.Sliders.Where(x=>x.Status==true);
        }

        public async Task<IQueryable<Slider>> DeactiveSliders()
        {
            return _db.Sliders.Where(x => x.Status == true);
        }
    }
}
