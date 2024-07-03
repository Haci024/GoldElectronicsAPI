using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Comments
    {
        public int Id { get; set; }

        public AppUser  AppUser { get; set; }

        public Guid AppUserId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public Comments MainComment { get; set; }

        public int?  MainCommentId { get; set; }

        public DateTime MessageDate { get; set; }

        public string Content { get; set; }

        public ICollection<Comments> ReplyComments { get; set; }

        
    }
}
