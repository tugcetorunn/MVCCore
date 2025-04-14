using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore7Uygulama.Models.Configurations
{
    public class AracCNF : IEntityTypeConfiguration<Arac>
    {
        public void Configure(EntityTypeBuilder<Arac> builder)
        {
            builder.Property(x => x.Plaka).IsRequired().HasMaxLength(9);
            builder.Property(x => x.UyeId).IsRequired();
            builder.Property(x => x.MarkaId).IsRequired();
            builder.Property(x => x.Model).IsRequired();
            builder.Property(x => x.Renk).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Fiyat).IsRequired().HasColumnType("money");
            builder.Property(x => x.Aciklama).HasMaxLength(200);
        }
    }
}
