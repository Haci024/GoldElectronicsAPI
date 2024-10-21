namespace UI.DTOS.MarksDTO
{
    public class MarkListDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public string CategoryName { get; set; }

        public int ProductCount { get; set; }
    }
}
