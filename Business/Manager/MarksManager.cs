using AutoMapper;
using Business.Services;
using Data.Services;
using DTO.DTOS.MarksDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class MarksManager : IMarkService
    {
        private readonly IMarksDAL _dal;
        private readonly IMapper _mapper;
        public MarksManager(IMarksDAL dal,IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }
        public async Task Create(Marks entity)
        {
            await _dal.Create(entity);  
        }

        public async Task Delete(Marks entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<Marks>> GetAll()
        {
            return await  _dal.GetAll();
        }

        public Marks GetById(int id)
        {
            return _dal.GetById(id);
        }

       
        public async Task<IEnumerable<MarkListDTO>> DeactiveMarkList()
        {
            return _mapper.Map<IEnumerable<MarkListDTO>>(await _dal.DeactiveMarkList());
        }
        public async Task<IEnumerable<MarkListDTO>> ActiveMarkList()
        {
            return _mapper.Map<IEnumerable<MarkListDTO>>(await _dal.ActiveMarkList());
        }

        public async Task Update(Marks entity)
        {
            await _dal.Update(entity);
        }

        public Marks GetById(Guid id)
        {
            return _dal.GetById(id);
        }
    }
}
