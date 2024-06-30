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
    public class ImageListConfig : IEntityTypeConfiguration<ImageList>
    {
        public void Configure(EntityTypeBuilder<ImageList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Product).WithMany(x=>x.ProductImages).HasForeignKey(x=>x.ProductId);
        }
    }
}
