﻿using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ColorDTO
{
    public class NewColorDTO
    {
        public string Name { get; set; }

        public bool Status { get; set; }

        public int ProductId { get; set; }
    }
}
