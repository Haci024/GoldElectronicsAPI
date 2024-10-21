using AutoMapper;
using Business.Services;
using Data.Services;
using DTO.DTOS.DescriptionListDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class DescriptionListManager : IDescriptionListService
    {
        private readonly IDescriptionListDAL _dal;
        private readonly IMapper _mapper;
        public DescriptionListManager(IDescriptionListDAL dal,IMapper mapper) {
             
            _dal = dal;
            _mapper = mapper;
        }
        public async Task Create(DescriptionList entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(DescriptionList entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<DescriptionList>> GetAll()
        {
            return await _dal.GetAll();
        }

        public DescriptionList GetById(int id)
        {
            return _dal.GetById(id);
        }

        public DescriptionList GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public async Task<IEnumerable<DescriptionListByProductDTO>> GetDescriptionList(Guid productId)
        {
            return _mapper.Map<IEnumerable<DescriptionListByProductDTO>>(await _dal.GetDescriptionList(productId));
        }

        public async Task Update(DescriptionList entity)
        {
           await _dal.Update(entity);
        }
    }
}
