
using API.Hubs;
using API.Tools;
using Business.Manager;
using Business.Services;
using Data.Connection;
using Data.Repositories;
using Data.Services;
using DTO.AutoMapper;
using Entity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {

    opt.RequireHttpsMetadata = true;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew =  TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true  
      };
   
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://localhost:7267", "https://localhost:7290")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<GoldElectronicsDb>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDAL, CategoryRepository>();

builder.Services.AddScoped<IEmailService, EmailManager>();

builder.Services.AddScoped< IProductService, ProductManager>();
builder.Services.AddScoped< IProductDAL, ProductRepository>();

builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDAL, SliderRepository>();

builder.Services.AddScoped<INotficationService, NotficationsManager>();
builder.Services.AddScoped<INotficationsDAL, NotficationsRepository>();

builder.Services.AddScoped<IDescriptionListService, DescriptionListManager>();
builder.Services.AddScoped<IDescriptionListDAL, DescriptionListRepository>();

builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDAL, ContactUsRepository>();

builder.Services.AddScoped<IColorListService,ColorListManager>();
builder.Services.AddScoped<IColorListDAL, ColorListRepository>();

builder.Services.AddScoped<ImageListService, ImageListManager>();
builder.Services.AddScoped<ImageListDAL, ImageListRepository>();

builder.Services.AddScoped<ICvAndCareerService, CvAndCareerManager>();
builder.Services.AddScoped<ICvAndCareerDAL, CvAndCareerRepository>();

builder.Services.AddScoped<IBasketService, BasketManager>();
builder.Services.AddScoped<IBasketDAL, BasketRepository>();

builder.Services.AddScoped<ISubscriberService, SubscriberManager>();
builder.Services.AddScoped<ISubscriberDAL, SubscriberRepository>();

builder.Services.AddScoped<IMarkService, MarksManager>();
builder.Services.AddScoped<IMarksDAL, MarksRepository>();

builder.Services.AddScoped<ICompareService, CompareManager>();
builder.Services.AddScoped<ICompareDAL, CompareRepository>();

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUsersDAL, UsersRepository>();

builder.Services.AddScoped<ICommentService, CommentcManager>();
builder.Services.AddScoped<ICommentDAL, CommentsRepository>();

builder.Services.AddScoped<ILanguageService, LanguageManager>();
builder.Services.AddScoped<ILanguageDAL, LanguageRepository>();

builder.Services.AddScoped<IWishListService, WishListManager>();
builder.Services.AddScoped<IWishlistDAL, WishListRepository>();
builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
builder.Services.AddSingleton<IGoogleCloudStorageService, GoogleCloudStorageManager>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(CategoryMapper));
builder.Services.AddAutoMapper(typeof(CommentMapper));
builder.Services.AddAutoMapper(typeof(ProductMapper));
builder.Services.AddAutoMapper(typeof(MarksMapper));
builder.Services.AddAutoMapper(typeof(ContactUsMapper));
builder.Services.AddAutoMapper(typeof(ImageListMapper));
builder.Services.AddAutoMapper(typeof(ProductMapper));
builder.Services.AddAutoMapper(typeof(SubscriberMapper));
builder.Services.AddAutoMapper(typeof(SliderMapper));
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddAutoMapper(typeof(ColorListMapper));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<AppUser, AppRole>(
    option => { 
    option.Lockout.MaxFailedAccessAttempts = 5;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); 
    option.SignIn.RequireConfirmedEmail = true;
    option.User.RequireUniqueEmail = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireLowercase = true;
    option.Password.RequiredLength = 10;
}).AddEntityFrameworkStores<GoldElectronicsDb>().AddDefaultTokenProviders();
var app = builder.Build();
app.UseSession(); 
app.UseCookiePolicy();
app.UseCors("AllowAll");
app.UseAuthentication(); 
app.UseAuthorization();  

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.MapHub<SignalRHub>("/signalrhub");
app.MapControllers();

app.Run();
