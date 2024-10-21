using DTO.DTOS.MarksDTO;

namespace UI.DTOS.CategoryDTO
{
    public class NavbarCategoryDTO
    {
        public Guid Id { get; set; }

        public Guid? MainCategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool Status { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<ChildCategoryListDTO> ChildCategories { get; set; }

        public ICollection<MarkListDTO> MarkList { get; set; }

      
    }
}
