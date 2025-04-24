using Microsoft.EntityFrameworkCore;

namespace MVCCore17SinavOncesiUygulama.Models.Configurations
{
    public class KategoriCFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(k => k.KategoriAdi).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Kategori { KategoriId = 1, KategoriAdi = "Roman" },
                new Kategori { KategoriId = 2, KategoriAdi = "Bilim Kurgu" },
                new Kategori { KategoriId = 3, KategoriAdi = "Kişisel Gelişim" },
                new Kategori { KategoriId = 4, KategoriAdi = "Tarih" },
                new Kategori { KategoriId = 5, KategoriAdi = "Biyografi" }
            );
        }
    }
}
