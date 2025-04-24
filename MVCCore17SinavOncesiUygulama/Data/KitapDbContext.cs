using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCCore17SinavOncesiUygulama.Models;
using System.Reflection;

namespace MVCCore17SinavOncesiUygulama.Data
{
    public class KitapDbContext : IdentityDbContext<Uye>
    {
        public KitapDbContext()
        {
            
        }

        public KitapDbContext(DbContextOptions<KitapDbContext> options) : base(options)
        {

        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KitapKategori> KitapKategori { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
