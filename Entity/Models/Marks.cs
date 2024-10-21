using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Marks
    {
        public Marks()
        {
            Id= Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
