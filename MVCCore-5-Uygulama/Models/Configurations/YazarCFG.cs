using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore_5_Uygulama.Models.Configurations
{
    public class YazarCFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.Property(k => k.YazarAdi)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(k => k.YazarSoyadi)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(k => k.Biyografi).HasMaxLength(300);
        }
    }
}
