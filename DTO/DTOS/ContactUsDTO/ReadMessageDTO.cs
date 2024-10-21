using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ContactUsDTO
{
    public class ReadMessageDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public bool IsView { get; set; } = true;

        public DateTime SendingDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
