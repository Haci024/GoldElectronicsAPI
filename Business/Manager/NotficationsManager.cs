using AutoMapper;
using Business.Services;
using Data.Services;
using DTO.DTOS.NotficationsDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class NotficationsManager : INotficationService
    {
        private readonly IMapper _mapper;
        private readonly INotficationsDAL _dal;
        public NotficationsManager(INotficationsDAL dal,IMapper mapper)
        {
            _dal= dal;
            _mapper=mapper;
        }

        public async Task AddNotficationByAction(int statusId, Guid pageId)
        {
           await  _dal.AddNotficationByAction(statusId, pageId);
        }

        public async Task Create(Notfications entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(Notfications entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Notfications>> GetAll()
        {
            return await  _dal.GetAll();
        }

        public Notfications GetById(int id)
        {
            return _dal.GetById(id);
        }

        public Notfications GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public Task<int> NotficationCount()
        {
            return _dal.NotficationCount();
        }

        public async Task<IEnumerable<NotficationListDTO>> UnViewNotficationList()
        {
            return _mapper.Map<IEnumerable<NotficationListDTO>>(await  _dal.UnViewNotficationList());
        }

        public async Task Update(Notfications entity)
        {
            await _dal.Update(entity);
        }
    }
}
