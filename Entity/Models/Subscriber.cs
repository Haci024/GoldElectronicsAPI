using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Subscriber
    {
        public Subscriber()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public DateTime SubscribeDate { get; set; }



    }
}
