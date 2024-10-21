using AutoMapper;
using Business.Services;
using Data.Connection;
using DTO.DTOS.ProductImagesDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageListController : ControllerBase
    {
        private readonly ImageListService _imageList;
        private readonly IMapper _mapper;
        private readonly IProductService _product;
        private readonly IGoogleCloudStorageService _googleCloudStorageService;
        public ImageListController(ImageListService imageListService, IMapper mapper, IProductService product, IGoogleCloudStorageService googleCloudStorageService)
        {
            _mapper = mapper;
            _imageList = imageListService;
            _googleCloudStorageService = googleCloudStorageService;
            _product = product;

        }
        [HttpGet("ProductImageList/{productId}")]
        public async Task<IActionResult> ImageListPyProduct(Guid productId)
        {

            return Ok(await _imageList.ImageListByProduct(productId));
        }
        [HttpGet("Image/{imageId}")]
        public async Task<IActionResult> ImageById(Guid imageId)
        {
            return Ok(_mapper.Map<ImageListDTO>(_imageList.GetById(imageId)));
        }
        [HttpPost("NewImage/{productId}")]
        public async Task<IActionResult> AddImage(Guid productId,NewImageDTO dto)
        {
            ImageList entity = new();
            
            entity.ProductId = productId;
            entity.Status = dto.Status;
            entity.SavedFileUrl = GenerateFileNameToSave(dto.Image.FileName);
            entity.ImageUrl = await _googleCloudStorageService.UploadFile(dto.Image,entity.SavedFileUrl);
            
            await _imageList.Create(entity);
            return Ok(dto);
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

        [HttpDelete("DeleteImage/{imageId}")]
        public async Task<IActionResult> DeleteImage(Guid imageId)
        {
         
             var entity = _imageList.GetById(imageId);
          
               await _googleCloudStorageService.DeleteFile(entity.SavedFileUrl); 
               await _imageList.Delete(entity);
           
            return Ok("Rəsim silindi!");
        }
    }
}
