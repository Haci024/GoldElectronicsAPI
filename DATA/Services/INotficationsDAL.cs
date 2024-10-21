using Data.Repositories;
using DTO.DTOS.NotficationsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface INotficationsDAL:IGenericDAL<Notfications>
    {
        Task<IQueryable<NotficationListDTO>> UnViewNotficationList();

        Task<int> NotficationCount();

        Task AddNotficationByAction(int statusId,Guid pageId);


    }
}
