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
    public class MarksConfig : IEntityTypeConfiguration<Marks>
    {
        public void Configure(EntityTypeBuilder<Marks> builder)
        {
           builder.HasKey(x => x.Id);
           builder.HasMany(x=>x.Products).WithOne(x=>x.Marks).HasForeignKey(x=>x.MarksId);
          
           
        }
    }
}
