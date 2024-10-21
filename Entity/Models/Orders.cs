using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Orders
    {
        public Orders()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }
       
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
      
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
    }
}
