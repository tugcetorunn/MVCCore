using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCore_3_ViewModel.Models;

public partial class SimpleMarketDbContext : DbContext
{
    public SimpleMarketDbContext()
    {
    }

    public SimpleMarketDbContext(DbContextOptions<SimpleMarketDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=.; initial catalog=SimpleMarketDb; integrated security=true; trust server certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
