using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCCore10IdentityTT.Models;
using System.Reflection;

namespace MVCCore10IdentityTT.Data
{
    // 4.
    public class GaleriDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public GaleriDbContext()
        {
            
        }
        public GaleriDbContext(DbContextOptions<GaleriDbContext> options) : base(options)
        {
            
        }

        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Marka> Markalar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // 8.
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 1, UserId = 1 });
        }
    }
}
