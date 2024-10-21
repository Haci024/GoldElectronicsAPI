using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class EmployeeCareer
    {
        public EmployeeCareer()
        {
            Id =Guid.NewGuid();
        }
        public Guid Id { get; set; } 

        public string WorkTitle { get; set; }

        public string CvUrl { get; set; }
    }
}
