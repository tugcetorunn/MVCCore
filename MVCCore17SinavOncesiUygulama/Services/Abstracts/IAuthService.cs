using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.ResultViewModels;
using MVCCore17SinavOncesiUygulama.ViewModels.Auth;
using System.Security.Claims;

namespace MVCCore17SinavOncesiUygulama.Services.Abstracts
{
    /// <summary>
    /// authService i soyutlamak üzere yazılan interface
    /// </summary>
    public interface IAuthService
    {
        LoginResult Login(LoginVM vm);
        Task<bool> Register(RegisterVM vm);
        string UserIdGetir(ClaimsPrincipal uye); // controllerlarda user id gereken noktalarda kullanılmak üzere yazılan metod
    }
}
