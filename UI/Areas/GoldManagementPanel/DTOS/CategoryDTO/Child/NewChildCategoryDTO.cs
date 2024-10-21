using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Main;

namespace UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child
{
    public class NewChildCategoryDTO
    {
        public NewChildCategoryDTO()
        {
            CategoryOrMarks = false;
            ImageUrl=String.Empty;
        }
        public string Name { get; set; }

        public bool Status { get; set; } = true;

        public bool CategoryOrMarks { get; set; }

        public Guid MainCategoryId { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<MainCategoryListDTO> MainCategoryList { get; set; } 
    }
}
