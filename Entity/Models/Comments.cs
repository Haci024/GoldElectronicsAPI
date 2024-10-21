using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Comments
    {
        public Comments()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public AppUser  AppUser { get; set; }

        public Guid AppUserId { get; set; }

        public Product Product { get; set; }

        public Guid ProductId { get; set; }

        public DateTime MessageDate { get; set; }

        public string Content { get; set; }

        public int Rate { get; set; }

        
    }
}
