namespace UI.Areas.GoldManagementPanel.DTOS.ContactUsDTO
{
    public class ReadContactUsMessageDTO
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public bool IsView { get; set; } = true;

        public DateTime SendingDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
