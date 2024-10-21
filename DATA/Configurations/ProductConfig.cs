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
            builder.HasMany(x => x.WishList).WithOne(x =>x.Products).HasForeignKey(x => x.ProductId);
            builder.HasMany(x=>x.Comments).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            builder.HasMany(x=>x.Compare).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            builder.HasMany(x => x.Colors).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(x => x.DescriptionList).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Stock).WithOne(x => x.Product);
            builder.Property(x => x.Price).HasColumnType("decimal(6,2)");
            

        }
    }
}
