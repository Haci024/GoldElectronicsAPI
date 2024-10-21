using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CommentDTO
{
    public class CommentListByProductDTO
    {
        public Guid productId { get; set; }

        public int Rate { get; set; }

        public DateTime MessageDate { get; set; }

        public string Content { get; set; }

        public string FullName { get; set; }
    }
}
