using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore10IdentityTT.Models.Configurations
{
    // 6.
    public class UyeCFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.Property(u => u.Ad)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.Soyad)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.Adres)
                .IsRequired()
                .HasMaxLength(100);

            Uye user = new Uye
            {
                Id = 1,
                Ad = "Tugce",
                Soyad = "Torun",
                Adres = "Bursa, Turkey",
                UserName = "tugcetorun",
                NormalizedUserName = "TUGCETORUN",
                Email = "ttorun@hotmail.com",
                NormalizedEmail = "TTORUN@HOTMAIL.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<Uye> passwordHasher = new PasswordHasher<Uye>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Tug_123");
            builder.HasData(user);
        }
    }
}
