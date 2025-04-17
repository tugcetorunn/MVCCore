using MVCCore12GenericRepository.Data;
using MVCCore12GenericRepository.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SahafDbContext>();

builder.Services.AddTransient<KitapRepository>();
builder.Services.AddTransient<YazarRepository>();
builder.Services.AddTransient<YayineviRepository>();
builder.Services.AddTransient<KategoriRepository>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
