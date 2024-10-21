using AutoMapper;
using Business.Services;
using Data.Services;
using DTO.DTOS.ProductImagesDTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class ImageListManager : ImageListService
    {
        private readonly ImageListDAL _dal;
        private readonly IGoogleCloudStorageService _googleService;
        private readonly IMapper _mapper;
        public ImageListManager(ImageListDAL dal,IMapper mapper, IGoogleCloudStorageService googleService)
        {
            _dal = dal;
            _mapper = mapper;
            _googleService = googleService;

        }
        public async Task Create(ImageList entity)
        {
           await  _dal.Create(entity);
        }

        public async Task Delete(ImageList entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<IQueryable<ImageList>> GetAll()
        {
            return await _dal.GetAll(); 
        }

        public ImageList GetById(int id)
        {
            return _dal.GetById(id);
        }

        public async Task<IEnumerable<ImageListDTO>> ImageListByProduct(Guid productId)
        {
            var images = _mapper.Map<IEnumerable<ImageListDTO>>(await _dal.ImageListByProduct(productId));
            foreach (var item in images)
            {
                await GenerateSignedUrl(item);
            }
            return images;
        }
        private async Task GenerateSignedUrl(ImageListDTO dto)
        {
           
            if (!string.IsNullOrWhiteSpace(dto.SavedFileUrl))
            {
                dto.ImageUrl = await _googleService.GetSignedUrl(dto.SavedFileUrl);
            }
        }
     
        public async Task Update(ImageList entity)
        {
            await _dal.Update(entity);
        }

        public ImageList GetById(Guid id)
        {
            return _dal.GetById(id);
        }
    }
}
