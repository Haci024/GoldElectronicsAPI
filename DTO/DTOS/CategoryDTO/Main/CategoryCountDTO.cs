using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.CategoryDTO.Main
{
    public class CategoryCountDTO
    {
        public int TotalCategoryCount { get; set; }

        public int MainCategoryCount { get; set; }

        public int ChildCategoryCount { get; set; }

        public int ProductCategoryCount { get; set; }   

        public int DeactiveCategoryCount { get; set; }  
    }
}
