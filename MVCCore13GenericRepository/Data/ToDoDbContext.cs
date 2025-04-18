using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCCore13GenericRepository.Models;
using System.Reflection;

namespace MVCCore13GenericRepository.Data
{
    public class ToDoDbContext : IdentityDbContext<Uye>
    {
        public ToDoDbContext()
        {
            
        }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }

        public DbSet<Eylem> Eylemler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
