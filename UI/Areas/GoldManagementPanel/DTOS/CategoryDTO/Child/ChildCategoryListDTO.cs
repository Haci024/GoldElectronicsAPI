using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Main;

namespace UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child
{
    public class ChildCategoryListDTO
    {
        public Guid Id {  get; set; }

        public string Name { get; set; }

        public bool Status { get; set; } = true;

        public string MainCategoryName { get; set; }

        public Guid MainCategoryId { get; set; }

        public ICollection<MainCategoryListDTO> MainCategoryList { get; set; }


    }
}
