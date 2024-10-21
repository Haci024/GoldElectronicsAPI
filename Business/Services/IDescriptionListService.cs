using DTO.DTOS.DescriptionListDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IDescriptionListService:IGenericService<DescriptionList>
    {
        Task<IEnumerable<DescriptionListByProductDTO>> GetDescriptionList(Guid productId);
    }
}
