using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCCore9ManuelIdentity.Models.Configurations
{
    public class UyeCFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            // identity 14. adım root ya da super user oluşturuyoruz.

            Uye user = new Uye
            {
                Id = 1,
                Ad = "Super",
                Soyad = "User",
                Adres = "Server",
                UserName = "sprUser",
                NormalizedUserName = "SPRUSER",
                Email = "super@user.com",
                NormalizedEmail = "SUPER@USER.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<Uye> passwordHasher = new PasswordHasher<Uye>();
            user.PasswordHash = passwordHasher.HashPassword(user, "sprUser_123");
            builder.HasData(user); // bu yazdıklarımız üye tablosunda olacak rol atama ilişki tablosunda olacağı için burada yapmıyoruz.
        }
    }
}
