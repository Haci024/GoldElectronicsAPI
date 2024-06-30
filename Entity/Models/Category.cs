using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category MainCategory { get; set; }

        public ICollection<Category> ChildCategories { get; set;}

        public int? MainCategoryId { get; set; }

        public bool Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
