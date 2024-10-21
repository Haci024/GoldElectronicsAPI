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
    public class ProductCompanyConfig : IEntityTypeConfiguration<ProductCompany>
    {
        public void Configure(EntityTypeBuilder<ProductCompany> builder)
        {
            builder.HasKey(x => new { x.ProductsId,x.CompanyId }) ;
       
            builder.HasOne(pc => pc.Products)
                   .WithMany(p => p.ProductCompanies)
                   .HasForeignKey(pc => pc.ProductsId);
            builder.HasOne(pc => pc.Company)
                   .WithMany(c => c.ProductCompanies)
                   .HasForeignKey(pc => pc.CompanyId);
        }
    }
}
