using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore_5_Uygulama.Models.Configurations
{
    public class KitapCFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(k => k.KitapAdi)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(k => k.Fiyat).HasColumnType("money").IsRequired();
            builder.Property(k => k.SayfaSayisi).IsRequired();
            builder.Property(k => k.KapakResmiUrl)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(k => k.Ozet).HasMaxLength(200).IsRequired();
            builder.Property(k => k.BasimSayisi).IsRequired();
        }
    }
}
