using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCore16ManyToManyDers.Models;

namespace MVCCore15ManyToMany.Models.Configurations
{
    public class YazarCFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Soyad).IsRequired().HasMaxLength(20);

            builder.HasData(new Yazar
            {
                YazarId = 1,
                Ad = "Orhan",
                Soyad = "Pamuk"
            },
            new Yazar
            {
                YazarId = 2,
                Ad = "Yaşar",
                Soyad = "Kemal"
            },
            new Yazar
            {
                YazarId = 3,
                Ad = "Oğuz",
                Soyad = "Atay"
            },
            new Yazar
            {
                YazarId = 4,
                Ad = "Sabahattin",
                Soyad = "Ali"
            },
            new Yazar
            {
                YazarId = 5,
                Ad = "Dan",
                Soyad = "Brown"
            });
        }
    }
}
