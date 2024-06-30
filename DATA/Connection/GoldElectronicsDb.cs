using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Connection
{
    public class GoldElectronicsDb :IdentityDbContext<AppUser,AppRole,Guid>
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ImageList> ImageList { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<ColorList> ColorLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Odissey;initial catalog=GoldElectronicsDb;integrated Security=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
