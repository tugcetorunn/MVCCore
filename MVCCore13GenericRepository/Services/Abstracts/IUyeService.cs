using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.ViewModels.Auth;

namespace MVCCore13GenericRepository.Services.Abstracts
{
    public interface IUyeService
    {
        Task<bool> Login(LoginVM vm);
        Task<bool> Register(RegisterVM vm);
        Task Logout();
        string GetUserId(Uye uye);
    }
}
