using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ProductDTO
{
    public class AllProductsDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid MarksId { get; set; }

        public string MarkName { get; set; }

        public string CategoryName { get; set; }

        public string MainCategoryName { get; set; }    

        public Guid CategoryId { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public DateTime AddingDate { get; set; }
    }
}
