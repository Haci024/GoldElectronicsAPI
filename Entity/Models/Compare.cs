using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Compare
    {
        public int Id { get; set; }

        public Guid ProductId { get;set; }

        public Product Product { get; set; }

        public AppUser AppUser { get; set; }

        public Guid AppUserId { get; set; }
    }
}
