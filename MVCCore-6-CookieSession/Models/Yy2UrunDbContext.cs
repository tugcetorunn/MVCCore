﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCore_6_CookieSession.Models;

public partial class Yy2UrunDbContext : DbContext
{
    public Yy2UrunDbContext()
    {
    }

    public Yy2UrunDbContext(DbContextOptions<Yy2UrunDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=.; initial catalog=YY2_UrunDB; integrated security=true; trust server certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.UrunId);

            entity.ToTable("Urunler");

            entity.Property(e => e.UrunId).HasColumnName("UrunID");
            entity.Property(e => e.Fiyat).HasColumnType("money");
            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.Resim)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Urunlers).HasForeignKey(d => d.KategoriId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
