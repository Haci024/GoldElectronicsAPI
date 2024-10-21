using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Marks Marks { get; set; }

        public Guid MarksId { get; set; }

        public ICollection<ImageList> ProductImages { get; set; }

        public bool Status { get; set; }

        public decimal  Price { get; set; }

        public ICollection<ColorList> Colors { get; set; }

        public bool IsSale { get; set; }

        public decimal  SalesPrice { get; set; }

        public ICollection<Comments> Comments { get; set; }

        public ICollection<WishList> WishList { get; set; }

        public ICollection<Compare> Compare { get; set; }

        public ICollection<ProductCompany> ProductCompanies { get; set; }
     
        public ICollection<DescriptionList> DescriptionList { get; set; }

        public DateTime? LastDateForIsSale { get; set; }

        public DateTime AddingDate { get; set; }

        public Category Category { get; set; }

        public Guid CategoryId { get; set; }

        public Stock Stock { get; set; }


    }
   
}
