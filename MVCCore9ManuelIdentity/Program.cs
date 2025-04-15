using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCCore9ManuelIdentity.Data;
using MVCCore9ManuelIdentity.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// identity 4. adım dbcontext sınıfının service olarak eklenmesi
builder.Services.AddDbContext<UrunDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UrunDbConnection")));

// identity 5. adım identity servislerinin eklenmesi
// builder.Services.AddDefaultIdentity<IdentityUser>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
//    .AddEntityFrameworkStores<UrunDbContext>();

builder.Services.AddIdentity<Uye, Rol>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
})
    .AddEntityFrameworkStores<UrunDbContext>()
    .AddRoles<Rol>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// identity 20. adım authenticate çalıştırma (cookie ayarları?)
app.UseAuthentication(); // sıra önemli... authorize işlemlerini yapmadan önce bunu eklememiz gerek.
app.UseAuthorization();

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
