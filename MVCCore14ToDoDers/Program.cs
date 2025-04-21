using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCCore14ToDoDers.Data;
using MVCCore14ToDoDers.Mappers;
using MVCCore14ToDoDers.Repositories;
using MVCCore14ToDoDers.Services.EylemService;
using MVCCore14ToDoDers.Services.KategoriService;
using MVCCore14ToDoDers.Services.LoginService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ToDoDbContext>();

builder.Services.AddAutoMapper(typeof(ToDoMapper));

builder.Services.AddTransient<EylemRepository>();
builder.Services.AddTransient<KategoriRepository>();

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IKategoriService, KategoriService>();
builder.Services.AddTransient<IEylemService, EylemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
