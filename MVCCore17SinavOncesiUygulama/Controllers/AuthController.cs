using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.Services.Abstracts;
using MVCCore17SinavOncesiUygulama.ViewModels.Auth;
using System.Threading.Tasks;

namespace MVCCore17SinavOncesiUygulama.Controllers
{
    /// <summary>
    /// view den kayıt, giriş, çıkış taleplerini karşılayan ve cevap dönen controller
    /// </summary>
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly SignInManager<Uye> signInManager; // browsera kaydedeceği özellikler olduğu için controllerdan yürütüyoruz.
        public AuthController(IAuthService _authService, SignInManager<Uye> _signInManager)
        {
            authService = _authService;
            signInManager = _signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            var loginResult = authService.Login(vm);
            if (loginResult.Uye != null)
            {
                await signInManager.SignInAsync(loginResult.Uye, isPersistent: false);
                return RedirectToAction("Index", "Home"); // login başarılı olduğunda tüm ürünlerin listelendiği sayfaya gider
            }
            else
            {
                ModelState.AddModelError("", loginResult.Mesaj);
                return View(vm);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                if (await authService.Register(vm))
                    return RedirectToAction("Login");
                else
                {
                    ModelState.AddModelError("", "Kayıt işlemi başarısız...");
                    return View(vm);
                }

            }
            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
