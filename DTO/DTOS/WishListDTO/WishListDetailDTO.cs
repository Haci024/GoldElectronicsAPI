using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.WishListDTO
{
    public class WishListDetailDTO
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
