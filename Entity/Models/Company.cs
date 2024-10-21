using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Company
    {
        public Company()
        {
            CompanyId = Guid.NewGuid();
        }
        public Guid CompanyId { get; set; }

        public string  CompanyName { get; set; }

        public bool RangeOrCombo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        

        public bool Status { get; set; }

        public ICollection<ProductCompany> ProductCompanies { get; set; }


    }
}
