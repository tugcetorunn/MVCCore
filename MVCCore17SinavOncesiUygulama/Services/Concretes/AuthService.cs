using Microsoft.AspNetCore.Identity;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.Services.Abstracts;
using MVCCore17SinavOncesiUygulama.ViewModels.Auth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCCore17SinavOncesiUygulama.Services.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Uye> userManager;
        public AuthService(UserManager<Uye> _userManager)
        {
            userManager = _userManager;
        }
        public Uye Login(LoginVM vm, out string mesaj)
        {
            mesaj = "";
            var user = userManager.FindByNameAsync(vm.KullaniciAdi).Result;
            if (user != null)
            {
                var result = userManager.CheckPasswordAsync(user, vm.Sifre).Result;
                if (result)
                {
                    return user;
                }
                mesaj = "Şifre yanlış.";
            }
            mesaj = "Kullanıcı bulunamadı.";
            return null;
        }

        public async Task<bool> Register(RegisterVM vm)
        {
            var user = new Uye
            {
                UserName = vm.KullaniciAdi,
                Email = vm.Email,
                Ad = vm.Ad,
                Soyad = vm.Soyad
            };
            var result = await userManager.CreateAsync(user, vm.Sifre);
            return result.Succeeded;
        }

        public string UserIdGetir(ClaimsPrincipal uye)
        {
            var userId = userManager.GetUserId(uye);
            return userId;
        }
    }
}
