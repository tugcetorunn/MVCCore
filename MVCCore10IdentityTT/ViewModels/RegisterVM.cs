using System.ComponentModel.DataAnnotations;

namespace MVCCore10IdentityTT.ViewModels
{
    // 16.
    public class RegisterVM
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string SifreTekrari { get; set; }
        public string Adres { get; set; }
    }
}
