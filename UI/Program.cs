using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;
using UI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("https://localhost:7290", "https://localhost:7267") 
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); 
        });
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().
    AddViewLocalization().
    AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(ShareResource).GetTypeInfo().Assembly.FullName);
            return factory.Create(nameof(ShareResource), assemblyName.Name);
        };

    });

builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCultures = new List<CultureInfo>
        {
                        new CultureInfo("az-AZ"),
                         new CultureInfo("en-US"),
                          new CultureInfo("ru-RU"),
    };
        options.DefaultRequestCulture = new RequestCulture(culture: "az-AZ", uiCulture: "az-AZ");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;

        options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
    });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  
        options.LogoutPath = "/Account/Logout";  
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        options.AccessDeniedPath= "/Home/Error";
        options.Cookie.Name = "OdisseyElectroCookie";
    });

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication(); 
app.UseAuthorization();
app.UseCors("AllowAll");
app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseRequestLocalization();

app.MapControllerRoute(
      name: "GoldManagementPanel",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
