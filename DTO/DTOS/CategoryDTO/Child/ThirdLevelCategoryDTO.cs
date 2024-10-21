using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CategoryDTO.Child
{
    public class ThirdLevelCategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string MainCategoryName { get; set; }

        public Guid? MainCategoryId { get; set; }

        public bool Status { get; set; }

        public int ProductCount { get;set; }    



    }
}
