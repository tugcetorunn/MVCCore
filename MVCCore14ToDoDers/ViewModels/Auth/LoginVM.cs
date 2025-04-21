using System.ComponentModel.DataAnnotations;

namespace MVCCore14ToDoDers.ViewModels.Auth
{
    public class LoginVM
    {
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
