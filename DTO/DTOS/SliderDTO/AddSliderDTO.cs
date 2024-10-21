using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.SliderDTO
{
    public class AddSliderDTO
    {
        //public string Title { get; set; }

        //public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string SavedFileUrl { get; set; }

       // public decimal Price { get; set; }

        public IFormFile Image { get;set; }

        public bool Status { get; set; }
    }
}
