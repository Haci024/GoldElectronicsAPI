﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AppRole:IdentityRole<Guid>
    {
        public AppRole()
        {
            Id = Guid.NewGuid();
        }
    }
}
