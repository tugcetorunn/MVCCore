using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore17SinavOncesiUygulama.Models.Configurations
{
    public class KitapKategoriCFG : IEntityTypeConfiguration<KitapKategori>
    {
        public void Configure(EntityTypeBuilder<KitapKategori> builder)
        {
            builder.HasKey(builder => new { builder.KitapId, builder.KategoriId }); // composite key
        }
    }
}
