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
    public class LocalizationConfig : IEntityTypeConfiguration<Languages>
    {
        public void Configure(EntityTypeBuilder<Languages> builder)
        {
            builder.HasKey(x => x.Id);
           
        }
    }
}
