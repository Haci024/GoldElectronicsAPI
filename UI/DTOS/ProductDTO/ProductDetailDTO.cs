using UI.DTOS.DescriptionDTO;
using UI.DTOS.ProductImagesDTO;
using UI.DTOS.ColorsDTO;
using UI.DTOS.CommentsDTO;


namespace UI.DTOS.ProductDTO
{
    public class ProductDetailDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ImageListDTO> ProductImages { get; set; }

        public ICollection<CommentListByProductDTO> CommentList { get; set; }

        public bool Status { get; set; }

        public decimal Price { get; set; }

        public ICollection<ColorListDTO> ColorList { get; set; }

        public bool IsSale { get; set; }

        public decimal SalesPrice { get; set; }

        public ICollection<DescriptionListByProductDTO> DescriptionList { get; set; }

        public DateTime? LastDateForIsSale { get; set; }

        public DateTime AddingDate { get; set; }

        public Guid CategoryId { get; set; }
    }
}
