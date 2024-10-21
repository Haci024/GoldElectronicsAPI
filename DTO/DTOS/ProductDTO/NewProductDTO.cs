using DTO.DTOS.CategoryDTO.Child;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ProductDTO
{
    public class NewProductDTO
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public Guid MarksId { get; set; }
    
        public IFormFile[] ProductImages { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public DateTime LastDateForIsSale { get; set; }




   
    }
}
