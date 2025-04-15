using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore10IdentityTT.Models.Configurations
{
    // 7.
    public class RolCFG : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(new Rol
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            builder.HasData(new Rol
            {
                Id = 2,
                Name = "Uye",
                NormalizedName = "UYE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
