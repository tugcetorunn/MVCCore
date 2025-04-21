using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore14ToDoDers.Models.Configurations
{
    public class KategoriCFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.KategoriAdi).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Kategori
                {
                    KategoriId = 1,
                    KategoriAdi = "İş"
                },
                new Kategori
                {
                    KategoriId = 2,
                    KategoriAdi = "Ev"
                },
                new Kategori
                {
                    KategoriId = 3,
                    KategoriAdi = "Haftasonu"
                },
                new Kategori
                {
                    KategoriId = 4,
                    KategoriAdi = "Kişisel Gelişim"
                }
            );
        }
    }
}
