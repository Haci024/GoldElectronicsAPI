using Data.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ISliderService:IGenericService<Slider>
    {
        Task<IQueryable<Slider>> ActiveSliders();

        Task<IQueryable<Slider>> DeactiveSliders();

    }
}
