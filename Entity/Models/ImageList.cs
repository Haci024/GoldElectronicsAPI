using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ImageList
    {
        public ImageList()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

        public string SavedFileUrl { get; set; }    
      
        public bool Status {  get; set; }

        public Product Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
