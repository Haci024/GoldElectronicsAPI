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
    public class CommentsConfig:IEntityTypeConfiguration<Comments>
    {
       

        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.AppUser).WithMany(x=>x.Comments).HasForeignKey(x=>x.ProductId);
            builder.HasOne(x => x.Product).WithMany(x => x.Comments).HasForeignKey(x => x.ProductId);
        }
    }
}
