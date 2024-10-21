namespace UI.DTOS.CategoryDTO
{
    public class ThirdLevelCategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string MainCategoryName { get; set; }

        public Guid? MainCategoryId { get; set; }

        public bool Status { get; set; }

        public int ProductCount { get; set; }
    }
}
