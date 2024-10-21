using Data.Repositories;
using DTO.DTOS.MarksDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IMarksDAL:IGenericDAL<Marks>
    {
        Task<IQueryable<MarkListDTO>> DeactiveMarkList();
        Task<IQueryable<MarkListDTO>> ActiveMarkList();

    }
}
