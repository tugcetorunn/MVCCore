using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore7Uygulama.Models
{
    public class Uye
    {
        public int UyeId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [NotMapped]
        public string AdSoyad => $"{Ad} {Soyad}";
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
