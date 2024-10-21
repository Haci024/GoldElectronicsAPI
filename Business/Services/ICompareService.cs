using DTO.DTOS.CompareDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICompareService:IGenericService<Compare>
    {
        void AddToCompare(AddCompareDTO dto);

        Task<int> ViewCompareCount();

    }
}
