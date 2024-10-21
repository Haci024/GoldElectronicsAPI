using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ColorDTO
{
    public class UpdateColorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public Guid ProductId { get; set; }
    }
}
