namespace UI.Areas.GoldManagementPanel.DTOS.MarksDTO
{
    public class MarkListDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public bool Status { get; set; }

        public string CategoryName { get; set; }

        public int ProductCount { get; set; }
    }
}
