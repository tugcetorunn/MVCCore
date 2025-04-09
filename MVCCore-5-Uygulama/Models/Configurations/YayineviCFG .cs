using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore_5_Uygulama.Models.Configurations
{
    public class YayineviCFG : IEntityTypeConfiguration<Yayinevi>
    {
        public void Configure(EntityTypeBuilder<Yayinevi> builder)
        {
            builder.Property(k => k.YayineviAdi)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
