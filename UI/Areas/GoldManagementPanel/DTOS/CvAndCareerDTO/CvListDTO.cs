namespace UI.Areas.GoldManagementPanel.DTOS.CvAndCareerDTO
{
    public class CvListDTO
    {
        public Guid Id { get; set; }

        public string WorkType { get; set; }

        public string FileUrl { get; set; }

        public string Email { get; set; }

        public string SavedFileUrl { get; set; }

        public DateTime SendingDate { get; set; }
    }
}
