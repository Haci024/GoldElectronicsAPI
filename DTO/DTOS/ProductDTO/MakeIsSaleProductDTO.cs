using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ProductDTO
{
    public  class MakeIsSaleProductDTO
    {
        public decimal SalesPrice { get; set; }

        public DateTime LastDateForIsSale { get; set; }

        public bool IsSale { get; set; }

    }
}
