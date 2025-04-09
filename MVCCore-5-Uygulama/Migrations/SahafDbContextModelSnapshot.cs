﻿// <auto-generated />
using MVCCore_5_Uygulama.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCCore_5_Uygulama.Migrations
{
    [DbContext(typeof(SahafDbContext))]
    partial class SahafDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriId"));

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoriler");

                    b.HasData(
                        new
                        {
                            KategoriId = 1,
                            KategoriAdi = "Roman"
                        },
                        new
                        {
                            KategoriId = 2,
                            KategoriAdi = "Bilim"
                        },
                        new
                        {
                            KategoriId = 3,
                            KategoriAdi = "Tarih"
                        },
                        new
                        {
                            KategoriId = 4,
                            KategoriAdi = "Edebiyat"
                        },
                        new
                        {
                            KategoriId = 5,
                            KategoriAdi = "Kişisel Gelişim"
                        });
                });

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Kitap", b =>
                {
                    b.Property<int>("KitapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KitapId"));

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("money");

                    b.Property<string>("KapakResmiUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ozet")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SayfaSayisi")
                        .HasColumnType("int");

                    b.Property<int>("YayineviId")
                        .HasColumnType("int");

                    b.Property<int>("YazarId")
                        .HasColumnType("int");

                    b.HasKey("KitapId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("YayineviId");

                    b.HasIndex("YazarId");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Yayinevi", b =>
                {
                    b.Property<int>("YayineviId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YayineviId"));

                    b.Property<string>("YayineviAdi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("YayineviId");

                    b.ToTable("Yayinevleri");

                    b.HasData(
                        new
                        {
                            YayineviId = 1,
                            YayineviAdi = "Can Yayınları"
                        },
                        new
                        {
                            YayineviId = 2,
                            YayineviAdi = "Alfa Yayınları"
                        },
                        new
                        {
                            YayineviId = 3,
                            YayineviAdi = "Pegasus Yayınları"
                        });
                });

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Yazar", b =>
                {
                    b.Property<int>("YazarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YazarId"));

                    b.Property<string>("Biyografi")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("YazarAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("YazarSoyadi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("YazarId");

                    b.ToTable("Yazarlar");

                    b.HasData(
                        new
                        {
                            YazarId = 1,
                            Biyografi = "",
                            YazarAdi = "Dan",
                            YazarSoyadi = "Brown"
                        },
                        new
                        {
                            YazarId = 2,
                            Biyografi = "",
                            YazarAdi = "Adam",
                            YazarSoyadi = "Fawer"
                        },
                        new
                        {
                            YazarId = 3,
                            Biyografi = "",
                            YazarAdi = "Michel",
                            YazarSoyadi = "Montaigne"
                        },
                        new
                        {
                            YazarId = 4,
                            Biyografi = "",
                            YazarAdi = "Ömer",
                            YazarSoyadi = "Seyfettin"
                        },
                        new
                        {
                            YazarId = 5,
                            Biyografi = "",
                            YazarAdi = "Halil",
                            YazarSoyadi = "İnalcık"
                        });
                });

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Kitap", b =>
                {
                    b.HasOne("MVCCore_5_Uygulama.Models.Kategori", "Kategori")
                        .WithMany("Kitaplar")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCCore_5_Uygulama.Models.Yayinevi", "Yayinevi")
                        .WithMany("Kitaplar")
                        .HasForeignKey("YayineviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCCore_5_Uygulama.Models.Yazar", "Yazar")
                        .WithMany("Kitaplar")
                        .HasForeignKey("YazarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Yayinevi");

                    b.Navigation("Yazar");
                });

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Kategori", b =>
                {
                    b.Navigation("Kitaplar");
                });

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Yayinevi", b =>
                {
                    b.Navigation("Kitaplar");
                });

            modelBuilder.Entity("MVCCore_5_Uygulama.Models.Yazar", b =>
                {
                    b.Navigation("Kitaplar");
                });
#pragma warning restore 612, 618
        }
    }
}
