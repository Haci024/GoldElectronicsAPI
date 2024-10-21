using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.DTOS.CvAndCareerDTO
{
    public class AddCvDTO
    {
        public AddCvDTO()
        {
            SendingDate = DateTime.UtcNow;
            IsView = false;
        }
        public bool IsView { get; set; }

        public string WorkType { get; set; }

        public string Email { get; set; }

        public IFormFile CvFile { get; set; }

        public DateTime SendingDate { get; set; }
    }
}
