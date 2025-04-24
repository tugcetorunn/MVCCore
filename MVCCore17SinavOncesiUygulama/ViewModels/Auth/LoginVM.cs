using System.ComponentModel.DataAnnotations;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Auth
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz")]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olmalıdır")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre boş olamaz")]
        [StringLength(50, ErrorMessage = "Şifre en fazla 50 karakter olmalıdır")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
    }
}
