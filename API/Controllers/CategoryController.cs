using AutoMapper;
using Business.Services;
using Data.Connection;
using DTO.DTOS.CategoryDTO.Child;
using DTO.DTOS.CategoryDTO.Main;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return Ok(_mapper.Map<IEnumerable<MainCategoryListDTO>>(await _service.GetAll()));    
        }
        [HttpGet("MainCategoryList")]
        public async Task<IActionResult> MainCategoryList()
        {

            return Ok(await _service.MainCategoryList());
        }
        [HttpGet("ChildCategoryList")]
        public async  Task<IActionResult> ChildCategoryList()
        {
            
            return Ok(await _service.ChildCategoryList());
        }
        [HttpGet("ThirdLevelCategoryList")]
        public async Task<IActionResult> ThirdLevelCategories()
        {

            return Ok(await _service.ThirdLevelCategoryList());
        }

        [HttpPost("NewMainCategory")]
        public async Task<IActionResult> AddMainCategory(NewMainCategoryDTO dto)
        {
            Category category = new();
            _mapper.Map(dto, category);
            await _service.Create(category);

            return Ok(dto);
        }
        [HttpPut("UpdateMainCategory/{Id}")]
        public async Task<IActionResult> UpdateMainCategory(int Id,UpdateMainCategoryDTO dto)
        {
            Category entity = _service.GetById(Id);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok(dto);
        }
        [HttpDelete("DeleteMainCategory/{Id}")]
        public async Task<IActionResult> DeleteMainCategory(int Id)
        {
            Category entity = _service.GetById(Id);
            await _service.Delete(entity);
            return Ok("Mehsul silindi");
        }
        #endregion
        #region ChildCategories

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {

            return Ok(_mapper.Map<ReadChildCategoryDTO>(_service.GetById(Id)));
        }
        [HttpPost("NewChildCategory")]
        public async Task<IActionResult> AddNewChildCategory(NewChildCategoryDTO dto)
        {
            Category entity = new();
            _mapper.Map(dto, entity);
            await _service.Create(entity);
            return Ok(dto);
        }
        [HttpPost("NewThirdCategory")]
        public async Task<IActionResult> NewThirdCategory(NewThirdCategoryDTO dto)
        {
            Category entity = new();
            _mapper.Map(dto, entity);
            await _service.Create(entity);
            return Ok(dto);
        }
        [HttpPut("UpdateThirdCategory/{Id}")]
        public async Task<IActionResult> UpdateChildCategory(int Id, UpdateThirdCategoryDTO dto)
        {
            Category entity = _service.GetById(Id);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok(dto);
        }
        [HttpPut("UpdateChildCategory/{Id}")]
        public async Task<IActionResult> UpdateChildCategory(int Id,UpdateChildCategoryDTO dto)
        {
            Category entity = _service.GetById(Id);
            _mapper.Map(dto, entity);
            await _service.Update(entity);
            return Ok(dto);
        }
        #endregion
        #region OtherActions
        [HttpGet("ChildCategoryListByMain/{mainCategoryId}")]
        public async Task<IActionResult> ChildCategoryListByMain(Guid mainCategoryId)
        {
           
            return Ok(await _service.ChildCategoryByMain(mainCategoryId));    
        }
        [HttpGet("CategoriesCount")]
        public async Task<IActionResult> CategoriesCount()
        {
            CategoryCountDTO dto = new();
            dto.MainCategoryCount = await _service.TotalMainCategoryCount();
            dto.ChildCategoryCount= await _service.TotalChildCategoryCount();
            dto.DeactiveCategoryCount = await _service.TotalDeactiveCategoryCount();
            dto.TotalCategoryCount = await _service.TotalCategoryCount();
            dto.ProductCategoryCount=await _service.TotalProductCategoryCount();
            return Ok(dto);
        }
        [HttpGet("MainCategoryName/{mainCategoryId}")]
        public async Task<IActionResult> MainCategoryName(Guid mainCategoryId)
        {
            

            return Ok(await _service.MainCategoryName(mainCategoryId));
        }
        [HttpGet("ChildCategoryName/{childCategoryId}")]
        public async Task<IActionResult> ChildCategoryName(Guid mainCategoryId)
        {
           

            return Ok(await _service.ChildCategoryName(mainCategoryId));
        }
        [HttpGet("NavbarCategoryList")]
        public async Task<IActionResult> NavbarCategoryList()
        {


            return Ok(await _service.NavbarCategoryList());
        }
        #endregion
    }
}
