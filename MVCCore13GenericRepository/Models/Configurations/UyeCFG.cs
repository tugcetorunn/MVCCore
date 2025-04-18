using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore13GenericRepository.Models.Configurations
{
    public class UyeCFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ad).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Soyad).IsRequired().HasMaxLength(50);

            Uye uye = new Uye
            {
                Id = Guid.NewGuid().ToString(),
                Ad = "Leyla",
                Soyad = "Tekin",
                Email = "leyla@x.com",
                NormalizedEmail = "LEYLA@X.COM",
                UserName = "leyla",
                NormalizedUserName = "LEYLA"
            };

            PasswordHasher < Uye> passwordHasher = new PasswordHasher<Uye>();
            uye.PasswordHash = passwordHasher.HashPassword(uye, "Leyla*123");
            uye.SecurityStamp = Guid.NewGuid().ToString();
            builder.HasData(uye);
        }
    }
}
