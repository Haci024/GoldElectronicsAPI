using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Category
    {
        public Category()
        {
            Id =Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Category MainCategory { get; set; }

        public ICollection<Category> ChildCategories { get; set;}

        public Guid? MainCategoryId { get; set; }

        public bool Status { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }

        public bool CategoryOrMarks {  get; set; }

       

    }
}
