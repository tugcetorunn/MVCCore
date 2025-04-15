using Microsoft.EntityFrameworkCore;
using MVCCore10IdentityTT.Data;
using MVCCore10IdentityTT.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 10.
builder.Services.AddDbContext<GaleriDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

// 11. 12. migration i�lemleri
builder.Services.AddIdentity<Uye, Rol>().AddEntityFrameworkStores<GaleriDbContext>().AddRoles<Rol>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 13. proje sa� t�k add -> new scaffolded item - mvc area - area ad� (admin, �ye)
// 14.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
