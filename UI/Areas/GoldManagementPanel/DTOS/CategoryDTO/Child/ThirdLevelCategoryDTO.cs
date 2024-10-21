namespace UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child
{
    public class ThirdLevelCategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MainCategoryName { get; set; }

        public int? MainCategoryId { get; set; }

        public bool Status { get; set; }

        public int ProductCount { get; set; }
    }
}
