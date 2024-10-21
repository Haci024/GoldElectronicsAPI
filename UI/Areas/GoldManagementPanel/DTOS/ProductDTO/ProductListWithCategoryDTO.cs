namespace UI.Areas.GoldManagementPanel.DTOS.ProductDTO
{
    public class ProductListWithCategoryDTO
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public string MarksName { get; set; }

        public string MainCategoryName { get; set; }

        public Guid MarksId { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public Guid CategoryId { get; set; }
    }
}
