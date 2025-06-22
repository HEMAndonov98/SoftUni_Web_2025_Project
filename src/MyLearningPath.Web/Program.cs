using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MyLearningPath.Core.Interfaces;
using MyLearningPath.Core.Models.User;

using MyLearningPath.Infrastructure;
using MyLearningPath.Infrastructure.Providers;
using MyLearningPath.Infrastructure.Query_Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<SafeDeleteInterceptor>();
builder.Services.AddSingleton<IStorageProvider, LocalStorageProvider>();

//Database
var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<ApplicationDbContext>(
(sp, options) => options
    .UseSqlServer(connectionString)
    .AddInterceptors(
        sp.GetRequiredService<SafeDeleteInterceptor>()));

// Identity configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
