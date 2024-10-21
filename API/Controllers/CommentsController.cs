using AutoMapper;
using Business.Manager;
using Business.Services;
using DTO.DTOS.CommentDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public CommentsController(ICommentService commentService,IMapper mapper,UserManager<AppUser> userManager)
        {
            _commentService= commentService;
            _userManager= userManager;
            _mapper = mapper;
        }
        [HttpGet("CommentListByProduct/{productId}")]
        public async Task<IActionResult> CommentList(Guid productId)
        {

            return Ok( _mapper.Map<IEnumerable<CommentListDTO>>(await _commentService.CommentListByProduct(productId)));
        }
        [HttpPost("NewComment")]
        public async Task<IActionResult> AddComment(NewCommentDTO dto)
        {
            //AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            Comments entity = new();
            entity.ProductId=dto.ProductId;
            _mapper.Map(dto, entity);
            entity.AppUserId = Guid.Parse("b892a018-0741-4bff-9e46-b8b666584a86");
            await _commentService.Create(entity);
         
            return  Ok(entity);
        }
        [HttpPost("ReplyComment")]
        public async Task<IActionResult> ReplyComment(ReplyCommentDTO dto)
        {
            Comments entity = new();
            _mapper.Map(dto, entity);
            await _commentService.Create(entity);

            return Ok(entity);
        }
        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment(DeleteCommentDTO dto)
        {
         
            Comments comments=_commentService.GetById(dto.CommentId);
            
           await  _commentService.Delete(comments);
            
            return Ok("Komment silindi!");
        }
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO dto)
        {
       
            Comments comments = _commentService.GetById(dto.CommentId);
            _mapper.Map(dto, comments);
            await _commentService.Update(comments);

            return Ok("Komment yeniləndi!");
        }
        [HttpGet("CommentRatesStatistics/{productId}")]
        public async Task<IActionResult> CommentRatesStatistics(Guid productId)
        {

            return Ok( await _commentService.GetCommentRatedPercent(productId));
        }

    }
}
