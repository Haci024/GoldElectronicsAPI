using DTO.DTOS.MarksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CategoryDTO.Child
{
    public class ChildCategoryListDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string MainCategoryName { get; set; }

        public Guid? MainCategoryId { get; set; }

        public bool Status { get; set; }

        public ICollection<ThirdLevelCategoryDTO> ThirdLevelCategory { get; set; }

        public ICollection<MarkListDTO> MarkList { get; set; }

        public bool CategoryOrMarks { get; set; }
    }
}
