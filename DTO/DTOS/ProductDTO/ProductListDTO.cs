using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ProductDTO
{
    public class ProductListDTO
    {
        public string Name { get; set; }

        public Guid MarksIdId { get; set; }

        public string MarksName { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public bool IsSale { get; set; }

        public DateTime AddingDate { get; set; }

        public decimal SalesPrice { get; set; }
    }
}
