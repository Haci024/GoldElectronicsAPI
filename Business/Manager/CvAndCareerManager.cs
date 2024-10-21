using AutoMapper;
using Business.Services;
using Data.Services;
using DTO.DTOS.CvAndCareerDTO;
using Entity.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class CvAndCareerManager : ICvAndCareerService
    {
        private readonly ICvAndCareerDAL _dal;
        private readonly IGoogleCloudStorageService _googleService;
        private readonly IMapper _mapper;

        public CvAndCareerManager(ICvAndCareerDAL dal, IGoogleCloudStorageService googleService,IMapper mapper)
        {
            _dal = dal;
            _googleService = googleService;
            _mapper=mapper;

        }
        public async Task Create(CvAndCareer entity)
        {
           await _dal.Create(entity);
        }

        public async Task Delete(CvAndCareer entity)
        {
           await  _dal.Delete(entity);
        }

        public async Task<IQueryable<CvAndCareer>> GetAll()
        {
           return await _dal.GetAll();
        }

        public  CvAndCareer GetById(int id)
        {
            return  _dal.GetById(id);
        }

        public CvAndCareer GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public async  Task<IEnumerable<CVListDTO>> UnViewedCvList()
        {
            var files = _mapper.Map<IEnumerable<CVListDTO>>(await _dal.UnViewedCvList());
            foreach (var item in files)
            {
                await GenerateSignedUrl(item);
            }
            return files;
        }

        public async Task Update(CvAndCareer entity)
        {
           await  _dal.Update(entity);
        }

        public async Task<IEnumerable<CVListDTO>> ViewedCvList()
        {
            var files = _mapper.Map<IEnumerable<CVListDTO>>(await _dal.ViewedCvList());
            foreach (var item in files)
            {
                await GenerateSignedUrl(item);
            }
            return files;
        }

        private async Task GenerateSignedUrl(CVListDTO dto)
        {

            if (!string.IsNullOrWhiteSpace(dto.SavedFileUrl))
            {
                dto.FileUrl = await _googleService.GetSignedUrl(dto.SavedFileUrl);
            }
        }
    }
}
