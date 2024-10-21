using DTO.DTOS.MarksDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IMarkService:IGenericService<Marks>
    {
        Task<IEnumerable<MarkListDTO>> DeactiveMarkList();
        Task<IEnumerable<MarkListDTO>> ActiveMarkList();

    }
}
