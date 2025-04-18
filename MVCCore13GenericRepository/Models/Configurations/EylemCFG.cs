using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore13GenericRepository.Models.Configurations
{
    public class EylemCFG : IEntityTypeConfiguration<Eylem>
    {
        public void Configure(EntityTypeBuilder<Eylem> builder)
        {
            builder.Property(x => x.EylemAdi).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Aciklama).IsRequired().HasMaxLength(150);
        }
    }
}
