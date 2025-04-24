using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.ViewModels.Auth;
using System.Security.Claims;

namespace MVCCore17SinavOncesiUygulama.Services.Abstracts
{
    public interface IAuthService
    {
        Uye Login(LoginVM vm, out string mesaj);
        Task<bool> Register(RegisterVM vm);
        string UserIdGetir(ClaimsPrincipal uye);
    }
}
