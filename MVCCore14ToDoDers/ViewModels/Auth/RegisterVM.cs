using System.ComponentModel.DataAnnotations;

namespace MVCCore14ToDoDers.ViewModels.Auth
{
    public class RegisterVM
    {
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
