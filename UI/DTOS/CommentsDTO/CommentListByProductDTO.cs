namespace UI.DTOS.CommentsDTO
{
    public class CommentListByProductDTO
    {
        public Guid productId { get; set; }

        public int Rate { get; set; }

        public DateTime MessageDate { get; set; }

        public string Content { get; set; }

        public string FullName { get; set; }
    }
}
