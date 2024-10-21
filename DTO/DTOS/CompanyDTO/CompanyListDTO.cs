using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CompanyDTO
{
    public class CompanytListDTO
    {
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; }

        public bool RangeOrCombo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }
    }
}
