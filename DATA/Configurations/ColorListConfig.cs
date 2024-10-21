using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ColorListConfig : IEntityTypeConfiguration<ColorList>
    {
        public void Configure(EntityTypeBuilder<ColorList> builder)
        {
            builder.HasKey(x=> x.Id);   
            builder.HasOne(x=>x.Product).WithMany(x=>x.Colors).HasForeignKey(x=>x.ProductId);
            
        }
    }
}
