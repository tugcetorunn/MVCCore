using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore9ManuelIdentity.Models
{
    // primary key varsayılan string istemiyorsak <> içinde belirtiriz.
    public class Uye : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [NotMapped]
        public string AdSoyad => $"{Ad} {Soyad}";
        public string Adres { get; set; }
        public ICollection<Urun>? Urunler { get; set; }
    }
}
