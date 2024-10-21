namespace UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child
{
    public class NewThirdLevelCategoryDTO
    {
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public bool CategoryOrMarks { get; set; }
        public Guid MainCategoryId { get; set; }
        public ICollection<ChildCategoryListDTO> ChildCategoryList { get; set; }
    }
}
