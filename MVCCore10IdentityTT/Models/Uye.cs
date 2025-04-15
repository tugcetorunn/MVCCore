using Microsoft.AspNetCore.Identity;

namespace MVCCore10IdentityTT.Models
{
    // 2.
    public class Uye : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public List<Arac>? Araclar { get; set; }
    }
}