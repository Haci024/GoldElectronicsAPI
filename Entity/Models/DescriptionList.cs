using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class DescriptionList
    {
        public DescriptionList()
        {
          Id= Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string SkillName { get; set; }

        public string Description { get; set; }

      public Product Product { get; set; }

        public Guid ProductId { get; set; }  
    }
}
