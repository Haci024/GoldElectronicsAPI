using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.SubscriberDTO
{
    public class SubscriberListDTO
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public DateTime SubscribeDate { get; set; } 
    }
}
