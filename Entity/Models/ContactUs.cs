using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ContactUs
    {
        public ContactUs()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public  bool IsView { get; set; }

        public DateTime SendingDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
