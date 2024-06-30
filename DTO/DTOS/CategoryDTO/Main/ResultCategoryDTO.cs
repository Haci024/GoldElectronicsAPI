using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CategoryDTO.Main
{
    public class ResultCategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? MainCategoryId { get; set; }

        public bool Status { get; set; }
    }
}
