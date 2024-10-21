using System.ComponentModel.DataAnnotations;

namespace UI.Areas.GoldManagementPanel.DTOS.ImageListDTO
{
    public class NewImageDTO
    {
        public NewImageDTO()
        {
            Status = true;
            
        }
        public bool Status { get; set; }
        
        public IFormFile Image { get; set; }
    }
}
