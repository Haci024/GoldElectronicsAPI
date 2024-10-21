using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class CvAndCareer
    {
        public CvAndCareer()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public bool IsView { get; set; }

        public string Email { get; set; }

        public string WorkType { get; set; }

        public string FileUrl { get; set; }

        public string SavedFileUrl { get; set; }

        public DateTime SendingDate { get; set; }
        
    }
}
