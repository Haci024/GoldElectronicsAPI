using AutoMapper;
using Business.Services;
using DTO.DTOS.ProductDTO;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("ActiveProductList")]
        public async Task<IActionResult> GetAllProducts()
        {

            return Ok(_mapper.Map<IEnumerable<ProductListDTO>>(await _service.GetAllProducts()));
        }
        [HttpGet("ProductListByCategory")]
        public async Task<IActionResult> ProductListByCategory(ProductCategoryDTO dto)
        {

            return Ok(_mapper.Map<IEnumerable<ProductListDTO>>(await _service.ProductListByCategory(dto.CategoryId)));
        }
        [HttpGet("DeactiveProductList")]
        public async Task<IActionResult> DeactiveProductList()
        {

            return Ok(_mapper.Map<IEnumerable<ProductListDTO>>(await _service.DeactiveProducts()));
        }
        [HttpGet("IsSaleProductList")]
        public async Task<IActionResult> IsSaleProductList()
        {

            return Ok(_mapper.Map<IEnumerable<ProductListDTO>>(await _service.IsSaleProductList()));
        }
        [HttpGet("ProductDetail")]
        public IActionResult GetById([FromQuery] int categoryId)
        {
            var product = _service.GetById(categoryId);
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
            _mapper.Map(dto, entity);
           await  _service.Create(entity);
            return Ok(dto);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update(UpdateProductDTO dto)
        {
            Product entity =_service.GetById(dto.Id);
            _mapper.Map(dto, entity);
           await  _service.Update(entity);
            return Ok(dto);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(DeleteProductDTO dto)
        {
            Product entity = _service.GetById(dto.Id);
           await  _service.Delete(entity);
            return Ok(dto);
        }
    }
}
