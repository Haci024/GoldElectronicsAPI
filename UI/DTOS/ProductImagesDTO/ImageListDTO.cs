namespace UI.DTOS.ProductImagesDTO
{
    public class ImageListDTO
    {
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

        public string SavedFileUrl { get; set; }

        public Guid ProductId { get; set; }

        public bool Status { get; set; }
    }
}
