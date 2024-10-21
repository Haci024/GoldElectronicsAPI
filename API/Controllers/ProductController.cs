using AutoMapper;
using Business.Services;
using Data.Connection;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly IGoogleCloudStorageService _cloudStorageService;
        private readonly GoldElectronicsDb _db;

        public ProductController(IProductService service, IMapper mapper, GoldElectronicsDb db, IGoogleCloudStorageService cloudStorageService)
        {
            _db = db;
            _service = service;
            _mapper = mapper;
            _cloudStorageService = cloudStorageService;
        }
        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            return Ok(await _service.GetAllProducts());
        }
        [HttpGet("ProductListWithCategory/{categoryId}")]
        public async Task<IActionResult> ProductListWithCategory(Guid categoryId)
        {

            return Ok(await _service.ProductListWithCategory(categoryId));
        }
        [HttpGet("DeactiveProductList")]
        public async Task<IActionResult> DeactiveProductList()
        {

            return Ok(await _service.DeactiveProducts());
        }
        [HttpGet("IsSaleProductList")]
        public async Task<IActionResult> IsSaleProductList()
        {

            return Ok(await _service.IsSaleProductList());
        }
     
        [HttpGet("ReadMakeIsSale/{productId}")]
        public IActionResult ReadMakeIsSale(Guid productId)
        {
            var product = _service.GetById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadProductDTO>(product));
        }

        [HttpPost("NewProduct")]
        public async Task<IActionResult> Create(NewProductDTO dto)
        {
            Product entity = new();


            entity.AddingDate = DateTime.UtcNow;
            entity.Status = dto.Status;
            entity.CategoryId = dto.CategoryId;
            entity.Price = dto.Price;
            entity.Name = dto.Name;
            entity.MarksId = dto.MarksId;
            if (dto.IsSale)
            {
                entity.IsSale = true;
                entity.SalesPrice = dto.SalesPrice;
                entity.LastDateForIsSale = dto.LastDateForIsSale;
            }
            else
            {
                entity.IsSale = false;
                entity.SalesPrice = 0;
                entity.LastDateForIsSale = DateTime.Today.Date;
            }
            await _service.Create(entity);

            foreach (var dtoImage in dto.ProductImages)
            {
                ImageList images = new ImageList
                {
                    ProductId = entity.Id,
                    Status = true,
                    SavedFileUrl = GenerateFileNameToSave(dtoImage.FileName),
                    ImageUrl = await _cloudStorageService.UploadFile(dtoImage, GenerateFileNameToSave(dtoImage.FileName)),


                };
                await _db.ImageList.AddAsync(images);
                await _db.SaveChangesAsync();
            }
            return Ok(dto);
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }


        [HttpPut("UpdateProduct/{productId}")]
        public async Task<IActionResult> Update(Guid productId, UpdateProductDTO dto)
        {
            Product entity = _service.GetById(productId);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok(dto);
        }
        [HttpDelete("DeleteProduct/{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            Product entity = _service.GetById(productId);
            await _service.Delete(entity);
            return Ok("Mehsul silindi!");
        }
        [HttpPut("MakeIsSale/{productId}")]
        public async Task<IActionResult> MakeIsSale(Guid productId, MakeIsSaleProductDTO dto)
        {
            Product entity = _service.GetById(productId);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok(entity);
        }
        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            ProductCountDTO dto = new();
            dto.TotalProductCount = await _service.TotalProductCount();
            dto.IsSaleProductCount = await _service.IsSaleProductCount();
            dto.DeactiveProductCount = await _service.DeactiveProductCount();
            dto.SimpleProductCount = await _service.SimpleProductCount();

            return Ok(dto);
        }
        [HttpGet("ProductListByMarks/{marksId}")]
        public async Task<IActionResult> ProductListByMarks(Guid marksId)
        {

            return Ok(await _service.ProductListByMarks(marksId));
        }

        [HttpGet("LastAddedProducts")]
        public async Task<IActionResult> LastAddedProducts()
        {

            return Ok(await _service.LastAddedProductList());
        }
        [HttpGet("ProductDetail/{productId}")]
        public async Task<IActionResult> ProductDetail(Guid productId)
        {
            

            return Ok(await _service.ProductDetail(productId));
        }
        [HttpGet("ProductDetailSlider/{categoryId}")]
        public async Task<IActionResult> ProductDetailSlider(Guid categoryId)
        {

            return Ok(await _service.ProductDetailSliderList(categoryId));
        }

    }
}
