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
    public class LocalizationConfig : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.HasKey(x => x.Id);
           
        }
    }
}
