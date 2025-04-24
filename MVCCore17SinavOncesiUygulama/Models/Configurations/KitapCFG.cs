using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore17SinavOncesiUygulama.Models.Configurations
{
    public class KitapCFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.KitapAdi).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Ozet).IsRequired().HasMaxLength(200);
        }
    }
}
