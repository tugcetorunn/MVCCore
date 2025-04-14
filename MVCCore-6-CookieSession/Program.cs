using MVCCore_6_CookieSession.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Yy2UrunDbContext>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30); // session s�resi (30 sn klavye mouse hareketi olmazsa session de�eri silinir. tekrar olu�turulmas� gerekir. )
    options.Cookie.HttpOnly = true; // sadece http �zerinden eri�ilebilir
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

app.UseSession(); // session kullan�m� i�in gerekli

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
