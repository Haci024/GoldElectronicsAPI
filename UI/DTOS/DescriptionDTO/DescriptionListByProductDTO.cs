namespace UI.DTOS.DescriptionDTO
{
    public class DescriptionListByProductDTO
    {
        public Guid Id { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }

        public string SkillName { get; set; }
    }
}
