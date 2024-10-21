using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Basket
    {
        public Basket()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public Product Products { get; set; }
        public Guid  ProductId { get; set; }
    }
}
