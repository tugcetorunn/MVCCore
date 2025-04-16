using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MVCCore9ManuelIdentity.Models;
using System.Reflection;

namespace MVCCore9ManuelIdentity.Data
{
    // identity 3. adım dbcontext sınıfının oluşturulması
    public class UrunDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public UrunDbContext()
        {
            
        }
        public UrunDbContext(DbContextOptions<UrunDbContext> options) : base(options)
        {

        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // identity 15. adım cfg leri uyguluyoruz.
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // identity 16. adım rol ve üye tablosu arasındaki ilişkiyi tanımlıyoruz.
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                });

            // identity 17. adım migration silip yeniden oluşturuyoruz.
            // concurrency stamp ve security stamp ne araştır???

            builder.Entity<Kategori>().HasData(
                new Kategori
                {
                    KategoriId = 1,
                    KategoriAdi = "Elektronik"
                },
                new Kategori
                {
                    KategoriId = 2,
                    KategoriAdi = "Giyim"
                },
                new Kategori
                {
                    KategoriId = 3,
                    KategoriAdi = "Yiyecek"
                });
        }

    }
}
