using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore7Uygulama.Models.Configurations
{
    public class UyeCNF : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Soyad).IsRequired().HasMaxLength(20);
            builder.Property(x => x.KullaniciAdi).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Sifre).IsRequired().HasMaxLength(100);
        }
    }
}
