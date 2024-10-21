namespace UI.DTOS.BasketDTO
{
    public class BasketContentDTO
    {
        public Guid ProductId { get; set; }

        public int itemCount { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

        public string SavedImageUrl { get; set; }
    }
}
