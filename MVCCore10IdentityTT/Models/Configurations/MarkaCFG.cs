using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore10IdentityTT.Models.Configurations
{
    public class MarkaCFG : IEntityTypeConfiguration<Marka>
    {
        public void Configure(EntityTypeBuilder<Marka> builder)
        {
            builder.Property(m => m.MarkaAd)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasData(
                new Marka
                {
                    MarkaId = 1,
                    MarkaAd = "BMW"
                },
                new Marka
                {
                    MarkaId = 2,
                    MarkaAd = "Mercedes"
                },
                new Marka
                {
                    MarkaId = 3,
                    MarkaAd = "Toyota"
                },
                new Marka
                {
                    MarkaId = 4,
                    MarkaAd = "Honda"
                },
                new Marka
                {
                    MarkaId = 5,
                    MarkaAd = "Ferrari"
                });
        }
    }
}
