using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public string  Description { get; set; }

        public ICollection<ImageList> ProductImages { get; set; }

        public bool Status { get; set; }

        public decimal  Price { get; set; }

        public ICollection<ColorList> Colors { get; set; }

        public bool IsSale { get; set; }

        public decimal  SalesPrice { get; set; }

        public ICollection<Comments> Comments { get; set; }


    }
   
}
