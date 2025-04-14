using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore7Uygulama.Models.Configurations
{
    public class MarkaCNF : IEntityTypeConfiguration<Marka>
    {
        public void Configure(EntityTypeBuilder<Marka> builder)
        {
            builder.Property(x => x.MarkaAdi).IsRequired().HasMaxLength(50);
        }
    }
}
