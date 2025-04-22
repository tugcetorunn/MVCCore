using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCore16ManyToManyDers.Models;

namespace MVCCore15ManyToMany.Models.Configurations
{
    public class KitapCFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.KitapAdi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Onsoz).IsRequired().HasMaxLength(300);

        }
    }
}
