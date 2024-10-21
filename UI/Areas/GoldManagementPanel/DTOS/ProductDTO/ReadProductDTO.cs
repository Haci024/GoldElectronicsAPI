namespace UI.Areas.GoldManagementPanel.DTOS.ProductDTO
{
    public class ReadProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public string MainCategoryName { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public decimal SalesPrice { get; set; }

        public bool IsSale { get; set; }

        public DateTime LastDateForIsSale { get; set; }
    }
}
