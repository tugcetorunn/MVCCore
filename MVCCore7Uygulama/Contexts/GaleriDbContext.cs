using Microsoft.EntityFrameworkCore;
using MVCCore7Uygulama.Hashers;
using MVCCore7Uygulama.Models;
using System.Reflection;

namespace MVCCore7Uygulama.Contexts
{
    public class GaleriDbContext : DbContext
    {
        public GaleriDbContext()
        {
            
        }

        public GaleriDbContext(DbContextOptions<GaleriDbContext> options) : base(options)
        {

        }

        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Uye>().HasData(
                new Uye { UyeId = 1, Ad = "Ahmet", Soyad = "Yılmaz", KullaniciAdi = "ahmet", Sifre = Md5.Hash("123") },
                new Uye { UyeId = 2, Ad = "Mehmet", Soyad = "Demir", KullaniciAdi = "mehmet", Sifre = Md5.Hash("123") },
                new Uye { UyeId = 3, Ad = "Ayşe", Soyad = "Kara", KullaniciAdi = "ayse", Sifre = Md5.Hash("456") },
                new Uye { UyeId = 4, Ad = "Fatma", Soyad = "Çelik", KullaniciAdi = "fatma", Sifre = Md5.Hash("789") },
                new Uye { UyeId = 5, Ad = "Ali", Soyad = "Koç", KullaniciAdi = "ali", Sifre = Md5.Hash("test") });

            modelBuilder.Entity<Marka>().HasData(
                new Marka { MarkaId = 1, MarkaAdi = "Toyota" },
                new Marka { MarkaId = 2, MarkaAdi = "Honda" },
                new Marka { MarkaId = 3, MarkaAdi = "Ford" },
                new Marka { MarkaId = 4, MarkaAdi = "BMW" },
                new Marka { MarkaId = 5, MarkaAdi = "Mercedes" });

            modelBuilder.Entity<Arac>().HasData(
                new Arac { AracId = 1, Aciklama = "Mercedes", Fiyat = 200000, MarkaId = 5, Model = 2020, Plaka = "34ABC123", Renk = "Beyaz", UyeId = 1 });
        }
    }
}
