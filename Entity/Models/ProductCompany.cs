using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ProductCompany
    {

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
     
        public Guid ProductsId { get; set; }
        public Product Products { get; set; }
      
    }
}
