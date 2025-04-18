using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCCore13GenericRepository.Data;
using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.Repositories;
using MVCCore13GenericRepository.Services.Abstracts;
using MVCCore13GenericRepository.Services.Concretes;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnection")));

builder.Services.AddIdentity<Uye, IdentityRole>(options => // AddIdentityCore<Uye> kullandığımda üyeService için unabled to service hatası geliyor.
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ToDoDbContext>();

builder.Services.AddTransient<EylemRepository>();
builder.Services.AddTransient<KategoriRepository>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IEylemService, EylemService>();
builder.Services.AddTransient<IUyeService, UyeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
