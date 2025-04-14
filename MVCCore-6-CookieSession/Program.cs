using MVCCore_6_CookieSession.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Yy2UrunDbContext>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30); // session süresi (30 sn klavye mouse hareketi olmazsa session deðeri silinir. tekrar oluþturulmasý gerekir. )
    options.Cookie.HttpOnly = true; // sadece http üzerinden eriþilebilir
    options.Cookie.IsEssential = true; // session zorunlu
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); // session kullanýmý için gerekli

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
