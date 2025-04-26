using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore17SinavOncesiUygulama.Models
{
    /// <summary>
    /// oturum açıp kitap için crud işlemleri yapabilecek olan database objesini modeller
    /// </summary>
    public class Uye : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [NotMapped]
        public string AdSoyad => $"{Ad} {Soyad}";
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
