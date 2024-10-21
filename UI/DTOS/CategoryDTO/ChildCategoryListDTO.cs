using UI.DTOS.MarksDTO;

namespace UI.DTOS.CategoryDTO
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
