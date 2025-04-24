using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.Services.Abstracts;
using MVCCore17SinavOncesiUygulama.ViewModels.Auth;
using System.Threading.Tasks;

namespace MVCCore17SinavOncesiUygulama.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly SignInManager<Uye> signInManager;
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
            string mesaj;
            var uye = authService.Login(vm, out mesaj);
            if (uye != null)
            {
                await signInManager.SignInAsync(uye, isPersistent: false);
                return RedirectToAction("Listele", "Kitap");
            }
            else
            {
                ModelState.AddModelError("", mesaj);
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
                    RedirectToAction("Login");
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
