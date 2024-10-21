using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ProductImagesDTO
{
    public class NewImageDTO
    {
        public bool Status { get; set; }

        public IFormFile Image { get; set; }
    }
}
