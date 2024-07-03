using AutoMapper;
using Business.Services;
using DTO.DTOS.CommentDTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentsController(ICommentService commentService,IMapper mapper)
        {
            _commentService= commentService;
            _mapper = mapper;
        }
        [HttpGet("CommentListByProduct/{productId}")]
        public async Task<IActionResult> CommentList(int productId)
        {

            return Ok( _mapper.Map<IEnumerable<CommentListDTO>>(await _commentService.CommentListByProduct(productId)));
        }
        [HttpPost("NewComment")]
        public async Task<IActionResult> AddComment(NewCommentDTO dto)
        {
            Comments entity = new();
            _mapper.Map(dto, entity);
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

    }
}
