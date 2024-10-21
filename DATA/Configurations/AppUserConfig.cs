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
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasMany(x => x.Orders).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            //builder.HasMany(x => x.Baskets).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.Comments).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
          
        }
    }
}
