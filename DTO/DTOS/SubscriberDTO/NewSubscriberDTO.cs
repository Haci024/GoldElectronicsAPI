using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.SubscriberDTO
{
    public class NewSubscriberDTO
    {
        public NewSubscriberDTO()
        {

            SubscribeDate = DateTime.Now;

        }
        public DateTime SubscribeDate { get; set; }

        public string Email { get; set; }
    }
}
