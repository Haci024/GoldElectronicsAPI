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
    public class OrdersConfig : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x=> x.Id);   
           // builder.HasOne(x=>x.AppUser).WithMany(x=>x.Orders).HasForeignKey(x=>x.AppUserId);
           
           
            
        }
    }
}
