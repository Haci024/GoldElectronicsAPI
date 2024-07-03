using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CommentDTO
{
    public class ReplyCommentDTO
    {
        public Guid AppUserId { get; set; }

        public int ProductId { get; set; }

        public int? MainCommentId { get; set; }

        public DateTime MessageDate { get; set; }

        public string Content { get; set; }
    }
}
