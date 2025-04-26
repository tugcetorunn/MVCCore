using MVCCore17SinavOncesiUygulama.Models;

namespace MVCCore17SinavOncesiUygulama.ResultViewModels
{
    /// <summary>
    /// controllera sadece giriş yapan kullanıcıyı değil aynı zamanda yaşanan hatayı da göndermek için oluşturulan class
    /// </summary>
    public class LoginResult
    {
        public string Mesaj { get; set; }
        public Uye? Uye { get; set; }
    }
}
