using Microsoft.AspNetCore.Identity;

namespace MVCCore9ManuelIdentity.Models
{
    // primary key varsayılan string istemiyorsak <> içinde belirtiriz.
    public class Uye : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public ICollection<Urun>? Urunler { get; set; }
    }
}
