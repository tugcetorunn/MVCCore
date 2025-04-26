using Microsoft.AspNetCore.Identity;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.ResultViewModels;
using MVCCore17SinavOncesiUygulama.Services.Abstracts;
using MVCCore17SinavOncesiUygulama.ViewModels.Auth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCCore17SinavOncesiUygulama.Services.Concretes
{
    /// <summary>
    /// userManager yardımıyla kullanıcı oluşturma, giriş yapma işlemlerini controller dan uzaklaştırmak üzere oluşturulmuş service
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly UserManager<Uye> userManager;
        public AuthService(UserManager<Uye> _userManager)
        {
            userManager = _userManager;
        }
        public LoginResult Login(LoginVM vm)
        {
            LoginResult loginResult = new(); // üyeyi, sonucu ve mesajı döndürecek result class
            var user = userManager.FindByNameAsync(vm.KullaniciAdi).Result;
            if (user != null)
            {
                var result = userManager.CheckPasswordAsync(user, vm.Sifre).Result;
                if (result)
                {
                    // signin metodunu controller da çalıştıracağız.
                    loginResult.Uye = user;
                }
                else
                {
                    loginResult.Uye = null;
                    loginResult.Mesaj = "Şifre yanlış.";
                }  
            }
            else 
            {
                loginResult.Uye = null;
                loginResult.Mesaj = "Kullanıcı bulunamadı.";
            }
            
            return loginResult;
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
