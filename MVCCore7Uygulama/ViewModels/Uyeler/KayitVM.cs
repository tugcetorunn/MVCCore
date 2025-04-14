using System.ComponentModel.DataAnnotations;

namespace MVCCore7Uygulama.ViewModels.Uyeler
{
    public class KayitVM
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; } // kullanıcı veya şifre büyük küçük harf karışık olsa da sql de büyük küçük harf farkı olmadığı için girişte önemi olmaz.
        public string Sifre { get; set; }
        [Compare("Sifre", ErrorMessage = "Şifre ve şifre tekrarı uyuşmuyor.")]
        public string SifreTekrari { get; set; }
    }
}
