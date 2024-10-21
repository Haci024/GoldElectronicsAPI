namespace UI.Areas.GoldManagementPanel.DTOS.ProductDTO
{
    public class IsSaleProductsDTO
    {
        public Guid Id { get; set; }

        public Guid MarksId { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string MarksName { get; set; }

        public string MainCategoryName { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal Price { get; set; }

        public DateTime LastDateForIsSale { get; set; }
    }
}
