using Microsoft.EntityFrameworkCore;
using MVCCore15ManyToMany.Models;
using System.Reflection;

namespace MVCCore15ManyToMany.Data
{
    public class SahafDbContext : DbContext
    {
        public SahafDbContext()
        {
            
        }

        public SahafDbContext(DbContextOptions<SahafDbContext> options) : base(options)
        {
            
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<KitapYazar> KitapYazar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
