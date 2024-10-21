using DTO.DTOS.CommentDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICommentService:IGenericService<Comments>
    {
        Task<IQueryable<Comments>> CommentListByProduct(Guid ProductId);

        Task<CommentRatedPercentDTO> GetCommentRatedPercent(Guid ProductId);
    }
}
