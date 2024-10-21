using Data.Configurations;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Connection
{
    public class GoldElectronicsDb :IdentityDbContext<AppUser,AppRole,Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notfications> Notfications { get; set; }
        public DbSet<DescriptionList> DescriptionList { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCompany> ProductCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ImageList> ImageList { get; set; }
        public DbSet<Languages> Localizations { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<ColorList> ColorLists { get; set; }
        public DbSet<Compare> Compare { get; set; }
      //  public DbSet<Orders> Orders { get; set; }
       // public DbSet<Basket> Basket { get; set; }
        public DbSet<CvAndCareer> CvAndCareers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=Odissey;initial catalog=GoldElectronicsDb;integrated Security=true;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("server=Odissey;initial catalog=OdisseyElectroDB;integrated Security=true;TrustServerCertificate=true");
           //optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019;initial catalog=GoldElectronicsDb;user=ElectroAdmin;password=8yL99_9pp@9;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductCompanyConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new SliderConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new CompanyConfig());
            builder.ApplyConfiguration(new ColorListConfig());
            builder.ApplyConfiguration(new SubscriberConfig());
            builder.ApplyConfiguration(new CvAndCareerConfig());
           // builder.ApplyConfiguration(new BasketConfig());
           // builder.ApplyConfiguration(new OrdersConfig());
            builder.ApplyConfiguration(new AppUserConfig());
            builder.ApplyConfiguration(new MarksConfig());
            builder.ApplyConfiguration(new CommentsConfig());
            builder.ApplyConfiguration(new StockConfig());
            builder.ApplyConfiguration(new ContactUsConfig());
            builder.ApplyConfiguration(new LocalizationConfig());
        }
    }
}
