using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore9ManuelIdentity.Models.Configurations
{
    public class RolCFG : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            // identity 13. adım rol ekliyoruz.
            builder.HasData(
                new Rol
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Rol
                {
                    Id = 2,
                    Name = "Uye",
                    NormalizedName = "UYE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
        }
    }
}
