using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class CvAndCareerConfig : IEntityTypeConfiguration<CvAndCareer>
    {
        public void Configure(EntityTypeBuilder<CvAndCareer> builder)
        {
            builder.HasKey(x=> x.Id);   
            
        }
    }
}
