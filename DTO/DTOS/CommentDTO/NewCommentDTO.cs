using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CommentDTO
{
    public class NewCommentDTO
    {
        public Guid AppUserId { get; set; }

        public int ProductId { get; set; }

        public DateTime MessageDate { get; set; }

        public string Content { get; set; }
    }
}
