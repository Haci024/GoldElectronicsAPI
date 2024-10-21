using DTO.DTOS.MarksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CategoryDTO.Child
{
    public class NavbarCategoryListDTO
    {
        public Guid Id { get; set; }

        public Guid? MainCategoryId { get; set; }

        public string CategoryName { get; set; }    

        public bool Status { get; set; }

        public ICollection<ChildCategoryListDTO> ChildCategories { get; set; }

        public ICollection<MarkListDTO> MarksList { get; set; }

        public string ImageUrl { get; set; }

        
    }
}
