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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.ProductImages).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Category).WithMany(x =>x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.Colors).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.Property(x => x.Price).HasColumnType("decimal(6,2)");
        }
    }
}
