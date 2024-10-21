using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ColorList
    {
      
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public Product Product { get; set; }

        public Guid ProductId { get; set; }

    }
}
