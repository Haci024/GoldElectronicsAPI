﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CategoryDTO.Child
{
    public class UpdateChildCategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? MainCategoryId { get; set; }

        public bool Status { get; set; }


    }
}
