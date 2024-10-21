using Data.Repositories;
using DTO.DTOS.DescriptionListDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IDescriptionListDAL:IGenericDAL<DescriptionList>
    {
        Task<IQueryable<DescriptionListByProductDTO>> GetDescriptionList(Guid productId);
    }
}
