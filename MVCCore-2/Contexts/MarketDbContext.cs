using Microsoft.EntityFrameworkCore;
using MVCCore_2.Models;

namespace MVCCore_2.Contexts
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext()
        {
            
        }
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseSqlServer("Server=.; Database=SimpleMarketDb; Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketDbContext).Assembly); // Assembly.GetExecutingAssembly()
        }
    }
}
