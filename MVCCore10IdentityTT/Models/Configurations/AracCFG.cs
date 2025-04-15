using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore10IdentityTT.Models.Configurations
{
    // 5.
    public class AracCFG : IEntityTypeConfiguration<Arac>
    {
        public void Configure(EntityTypeBuilder<Arac> builder)
        {
            builder.Property(a => a.Plaka)
                .IsRequired()
                .HasMaxLength(9);
            builder.Property(builder => builder.Renk)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(builder => builder.Aciklama)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(builder => builder.Fiyat)
                .IsRequired()
                .HasColumnType("money");
        }
    }
}
