using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.MarksDTO
{
    public class MarkListDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public string CategoryName { get; set; }

        public int ProductCount { get; set; }
    }
}
