using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ProductDTO
{
    public class ReadProductDTO
    {
        public Guid Id {  get; set; }

        public string Name { get; set; }

        public Guid MarksId { get; set; }

        public string MarksName { get; set; }

        public string CategoryName { get; set; }

        public string MainCategoryName { get; set; }

        public bool Status { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal Price { get; set; }

        public bool IsSale { get; set; }

        public DateTime LastDateForIsSale { get; set; }

        public DateTime AddingDate { get; set; }
    }
}
