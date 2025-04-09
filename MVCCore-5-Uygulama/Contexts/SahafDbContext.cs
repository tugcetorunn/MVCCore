using Microsoft.EntityFrameworkCore;
using MVCCore_5_Uygulama.Models;
using MVCCore_5_Uygulama.Models.Extensions;
using System.Reflection;

namespace MVCCore_5_Uygulama.Contexts
{
    public class SahafDbContext : DbContext
    {
        public SahafDbContext()
        {
            
        }

        public SahafDbContext(DbContextOptions<SahafDbContext> options) : base(options) { }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yayinevi> Yayinevleri { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddData();
        }
    }
}
