using Microsoft.EntityFrameworkCore;
using MVCCore7Uygulama.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GaleriDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GaleriDbConnection")));

builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(1));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
