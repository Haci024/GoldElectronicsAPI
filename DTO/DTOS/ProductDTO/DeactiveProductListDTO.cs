using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ProductDTO
{
    public class DeactiveProductListDTO
    {
        public Guid Id { get; set; }

      public string CategoryName { get; set; }

        public string  MarksName { get; set; }

        public string MainCategoryName { get; set; }

        public Guid MarksId { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public DateTime AddingDate { get; set; }




    }
}
