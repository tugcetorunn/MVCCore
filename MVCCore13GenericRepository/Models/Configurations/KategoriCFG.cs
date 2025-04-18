using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore13GenericRepository.Models.Configurations
{
    public class KategoriCFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.KategoriAd).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Kategori
                {
                    KategoriId = 1,
                    KategoriAd = "İş"
                },
                new Kategori
                {
                    KategoriId = 2,
                    KategoriAd = "Ev"
                },
                new Kategori
                {
                    KategoriId = 3,
                    KategoriAd = "Haftasonu"
                },
                new Kategori
                {
                    KategoriId = 4,
                    KategoriAd = "Kişisel Gelişim"
                }
            );
        }
    }
}
