
using Business.Manager;
using Business.Services;
using Data.Connection;
using Data.Repositories;
using Data.Services;
using DTO.AutoMapper;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GoldElectronicsDb>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDAL, CategoryRepository>();

builder.Services.AddScoped< IProductService, ProductManager>();
builder.Services.AddScoped< IProductDAL, ProductRepository>();

builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDAL, SliderRepository>();

builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDAL, ContactUsRepository>();

builder.Services.AddScoped<IColorListService,ColorListManager>();
builder.Services.AddScoped<IColorListDAL, ColorListRepository>();

builder.Services.AddScoped<ImageListService, ImageListManager>();
builder.Services.AddScoped<ImageListDAL, ImageListRepository>();

builder.Services.AddScoped<ISubscriberService, SubscriberManager>();
builder.Services.AddScoped<ISubscriberDAL, SubscriberRepository>();

builder.Services.AddScoped<IMarkService, MarksManager>();
builder.Services.AddScoped<IMarksDAL, MarksRepository>();

builder.Services.AddScoped<ICommentService, CommentcManager>();
builder.Services.AddScoped<ICommentDAL, CommentsRepository>();

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<AppUser, AppRole>(
    option => { 
    option.Lockout.MaxFailedAccessAttempts = 5;//Daxil olan istifadəçilər maksimum 5 dəfə məlumatları səhv daxil edə bilər
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //Səhv məlumat daxil edən istifadəçinin bloklanma müddəti
    option.SignIn.RequireConfirmedEmail = true;//Ancaq təsdiqlənmiş e-poçt malik istifadəçilər girə bilsin
    option.User.RequireUniqueEmail = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireLowercase = true;
    option.Password.RequiredLength = 10;



}).AddEntityFrameworkStores<GoldElectronicsDb>().AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
