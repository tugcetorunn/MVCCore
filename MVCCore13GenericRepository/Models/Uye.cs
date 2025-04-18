using Microsoft.AspNetCore.Identity;

namespace MVCCore13GenericRepository.Models
{
    public class Uye : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public ICollection<Eylem>? Eylemler { get; set; }
    }
}