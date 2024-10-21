using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AppUser:IdentityUser<Guid>
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
        }
        public string FullName { get; set; }

        public int ForgetPasswordCode { get; set; }

        public int ConfirmCode { get; set; }
        public ICollection<Comments> Comments { get; set; }

       // public ICollection<Basket> Baskets { get; set; }


       // public ICollection<Orders> Orders { get; set; }
    }

}
