using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CategoryDTO.Child
{
    public class NewChildCategoryDTO
    {
        public NewChildCategoryDTO()
        {
            ImageUrl= string.Empty;
            CategoryOrMarks = false;
        }
        public string Name { get; set; }

        public bool Status { get; set; }

        public bool CategoryOrMarks { get; set; }

        public string ImageUrl { get; set; }

        public Guid MainCategoryId { get; set; }
    }
}
