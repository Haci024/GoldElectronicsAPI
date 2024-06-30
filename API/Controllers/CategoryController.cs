using AutoMapper;
using Business.Services;
using DTO.DTOS.CategoryDTO.Child;
using DTO.DTOS.CategoryDTO.Main;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper,ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }
        #region MainCategories
        [HttpGet("AllCategories")]
        public async Task<IActionResult> GetList()
        {

            return Ok(_mapper.Map<IEnumerable<ResultCategoryDTO>>(await _service.GetAll()));    
        }

        [HttpPost("NewMainCategory")]
        public async Task<IActionResult> AddMainCategory(NewMainCategoryDTO dto)
        {
            Category category = new();
            _mapper.Map(dto, category);
            await _service.Create(category);

            return Ok(dto);
        }
        [HttpPut("UpdateMainCategory")]
        public async Task<IActionResult> UpdateMainCategory(UpdateMainCategoryDTO dto)
        {
            Category entity = _service.GetById(dto.Id);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok(dto);
        }
        [HttpDelete("DeleteMainCategory")]
        public async Task<IActionResult> DeleteMainCategory(DeleteMainCategoryDTO dto)
        {
            Category entity = _service.GetById(dto.Id);
            await _service.Delete(entity);
            return Ok(dto);
        }
        #endregion
        #region ChildCategories
        

        [HttpPost("NewChildCategory")]
        public async Task<IActionResult> AddNewChildCategory(NewChildCategoryDTO dto)
        {
            Category entity = new();
            _mapper.Map(dto, entity);
            await _service.Create(entity);
            return Ok(dto);
        }
        [HttpPut("UpdateChildCategory")]
        public async Task<IActionResult> UpdateChildCategory(UpdateChildCategoryDTO dto)
        {
            Category entity = _service.GetById(dto.Id);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok();
        }
        #endregion
        #region OtherActions
        [HttpGet("ChildCategoryListByMain")]
        public async Task<IActionResult> ChildCategoryListByMain(ChildCategoryListByMainDTO dto)
        {
           
            return Ok(_mapper.Map<IEnumerable<ResultCategoryDTO>>(await _service.GetChildCategoryByMain(dto.MainCategoryId)));    
        }
        #endregion
    }
}
