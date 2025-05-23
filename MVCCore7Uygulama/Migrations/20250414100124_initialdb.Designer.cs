﻿// <auto-generated />
using MVCCore7Uygulama.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCCore7Uygulama.Migrations
{
    [DbContext(typeof(GaleriDbContext))]
    [Migration("20250414100124_initialdb")]
    partial class initialdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCCore7Uygulama.Models.Arac", b =>
                {
                    b.Property<int>("AracId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AracId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("money");

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.Property<string>("Plaka")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Renk")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UyeId")
                        .HasColumnType("int");

                    b.HasKey("AracId");

                    b.HasIndex("MarkaId");

                    b.HasIndex("UyeId");

                    b.ToTable("Araclar");

                    b.HasData(
                        new
                        {
                            AracId = 1,
                            Aciklama = "Mercedes",
                            Fiyat = 200000m,
                            MarkaId = 5,
                            Model = 2020,
                            Plaka = "34ABC123",
                            Renk = "Beyaz",
                            UyeId = 1
                        });
                });

            modelBuilder.Entity("MVCCore7Uygulama.Models.Marka", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkaId"));

                    b.Property<string>("MarkaAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MarkaId");

                    b.ToTable("Markalar");

                    b.HasData(
                        new
                        {
                            MarkaId = 1,
                            MarkaAdi = "Toyota"
                        },
                        new
                        {
                            MarkaId = 2,
                            MarkaAdi = "Honda"
                        },
                        new
                        {
                            MarkaId = 3,
                            MarkaAdi = "Ford"
                        },
                        new
                        {
                            MarkaId = 4,
                            MarkaAdi = "BMW"
                        },
                        new
                        {
                            MarkaId = 5,
                            MarkaAdi = "Mercedes"
                        });
                });

            modelBuilder.Entity("MVCCore7Uygulama.Models.Uye", b =>
                {
                    b.Property<int>("UyeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UyeId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UyeId");

                    b.ToTable("Uyeler");

                    b.HasData(
                        new
                        {
                            UyeId = 1,
                            Ad = "Ahmet",
                            KullaniciAdi = "ahmet",
                            Sifre = "202CB962AC59075B964B07152D234B70",
                            Soyad = "Yılmaz"
                        },
                        new
                        {
                            UyeId = 2,
                            Ad = "Mehmet",
                            KullaniciAdi = "mehmet",
                            Sifre = "202CB962AC59075B964B07152D234B70",
                            Soyad = "Demir"
                        },
                        new
                        {
                            UyeId = 3,
                            Ad = "Ayşe",
                            KullaniciAdi = "ayse",
                            Sifre = "250CF8B51C773F3F8DC8B4BE867A9A02",
                            Soyad = "Kara"
                        },
                        new
                        {
                            UyeId = 4,
                            Ad = "Fatma",
                            KullaniciAdi = "fatma",
                            Sifre = "68053AF2923E00204C3CA7C6A3150CF7",
                            Soyad = "Çelik"
                        },
                        new
                        {
                            UyeId = 5,
                            Ad = "Ali",
                            KullaniciAdi = "ali",
                            Sifre = "098F6BCD4621D373CADE4E832627B4F6",
                            Soyad = "Koç"
                        });
                });

            modelBuilder.Entity("MVCCore7Uygulama.Models.Arac", b =>
                {
                    b.HasOne("MVCCore7Uygulama.Models.Marka", "Marka")
                        .WithMany("Araclar")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCCore7Uygulama.Models.Uye", "Uye")
                        .WithMany()
                        .HasForeignKey("UyeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marka");

                    b.Navigation("Uye");
                });

            modelBuilder.Entity("MVCCore7Uygulama.Models.Marka", b =>
                {
                    b.Navigation("Araclar");
                });
#pragma warning restore 612, 618
        }
    }
}
