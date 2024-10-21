using DTO.DTOS.NotficationsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface INotficationService:IGenericService<Notfications>
    {
        Task<IEnumerable<NotficationListDTO>> UnViewNotficationList();

        Task<int> NotficationCount();

        Task AddNotficationByAction(int statusId, Guid pageId);
    }
}
