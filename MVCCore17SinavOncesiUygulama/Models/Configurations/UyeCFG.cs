using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore17SinavOncesiUygulama.Models.Configurations
{
    public class UyeCFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Soyad).IsRequired().HasMaxLength(50);

            Uye uye = new Uye()
            {
                Id = Guid.NewGuid().ToString(),
                Ad = "Zeynep",
                Soyad = "Toker",
                UserName = "zeynep.toker",
                NormalizedUserName = "ZEYNEP.TOKER",
                Email = "tokerzeynep@hotmail.com",
                NormalizedEmail = "TOKERZEYNEP@HOTMAİL.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<Uye> passwordHasher = new PasswordHasher<Uye>();
            uye.PasswordHash = passwordHasher.HashPassword(uye, "Ztk*123456");
            builder.HasData(uye);
        }
    }
}
