using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MVCCore15ManyToMany.Models.Configurations
{
    public class KitapYazarCFG : IEntityTypeConfiguration<KitapYazar>
    {
        public void Configure(EntityTypeBuilder<KitapYazar> builder)
        {
            builder.HasKey(ky => new { ky.KitapId, ky.YazarId });
        }
    }
}
