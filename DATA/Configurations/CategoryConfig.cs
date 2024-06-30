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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.HasOne(x=>x.MainCategory).WithMany(x=>x.ChildCategories).HasForeignKey(x=>x.MainCategoryId);
            builder.HasMany(x => x.ChildCategories).WithOne(x=>x.MainCategory).HasForeignKey(x => x.MainCategoryId);
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

        }
    }
}
