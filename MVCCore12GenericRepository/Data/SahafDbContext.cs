using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVCCore12GenericRepository.Models;

namespace MVCCore12GenericRepository.Data;

public partial class SahafDbContext : DbContext
{
    public SahafDbContext()
    {
    }

    public SahafDbContext(DbContextOptions<SahafDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategori> Kategoriler { get; set; }

    public virtual DbSet<Kitap> Kitaplar { get; set; }

    public virtual DbSet<Yayinevi> Yayinevleri { get; set; }

    public virtual DbSet<Yazar> Yazarlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=.; initial catalog=SahafDb; integrated security=true; trust server certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriAdi).HasMaxLength(20);
        });

        modelBuilder.Entity<Kitap>(entity =>
        {
            entity.HasKey(e => e.KitapId);

            entity.ToTable("Kitaplar");

            entity.HasIndex(e => e.KategoriId, "IX_Kitaplar_KategoriId");

            entity.HasIndex(e => e.YayineviId, "IX_Kitaplar_YayineviId");

            entity.HasIndex(e => e.YazarId, "IX_Kitaplar_YazarId");

            entity.Property(e => e.Fiyat).HasColumnType("money");
            entity.Property(e => e.KapakResmiUrl).HasMaxLength(100);
            entity.Property(e => e.KitapAdi).HasMaxLength(100);
            entity.Property(e => e.Ozet).HasMaxLength(200);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Kitaplar).HasForeignKey(d => d.KategoriId);

            entity.HasOne(d => d.Yayinevi).WithMany(p => p.Kitaplar).HasForeignKey(d => d.YayineviId);

            entity.HasOne(d => d.Yazar).WithMany(p => p.Kitaplar).HasForeignKey(d => d.YazarId);
        });

        modelBuilder.Entity<Yayinevi>(entity =>
        {
            entity.HasKey(e => e.YayineviId);

            entity.ToTable("Yayinevleri");

            entity.Property(e => e.YayineviAdi).HasMaxLength(30);
        });

        modelBuilder.Entity<Yazar>(entity =>
        {
            entity.HasKey(e => e.YazarId);

            entity.ToTable("Yazarlar");

            entity.Property(e => e.Biyografi).HasMaxLength(300);
            entity.Property(e => e.YazarAdi).HasMaxLength(20);
            entity.Property(e => e.YazarSoyadi).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
