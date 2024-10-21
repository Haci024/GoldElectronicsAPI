using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Stock
    {
        public Stock()
        {
            Count = 0;
        }
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Count { get ; set; }
    }
}
