using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCore10IdentityTT.Models;
using MVCCore10IdentityTT.ViewModels;

namespace MVCCore10IdentityTT.Controllers
{
    // 17.
    public class AuthController : Controller
    {
        // 18.
        private readonly UserManager<Uye> userManager;
        private readonly SignInManager<Uye> signInManager;
        public AuthController(UserManager<Uye> _userManager, SignInManager<Uye> _signInManager){
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            // 20.
            if (ModelState.IsValid)
            {
                var uye = await userManager.FindByNameAsync(vm.KullaniciAdi);

                if (uye != null)
                {
                    var sifreResult = await userManager.CheckPasswordAsync(uye, vm.Sifre);
                    if (!sifreResult)
                    {
                        ModelState.AddModelError("hata", "Şifre hatalı.");
                        return View(vm);
                    }
                    var result = await signInManager.PasswordSignInAsync(uye, vm.Sifre, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("hata", "Giriş başarısız.");
                    return View(vm);
                }
                else
                {
                    ModelState.AddModelError("hata", "Kullanıcı adı bulunamadı.");
                    return View(vm);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            // 19.
            if (ModelState.IsValid)
            {
                Uye uye = new Uye
                {
                    UserName = vm.KullaniciAdi,
                    Email = vm.Email,
                    Ad = vm.Ad,
                    Soyad = vm.Soyad,
                    Adres = vm.Adres,
                };

                // 29.
                await userManager.AddToRoleAsync(uye, "Uye");

                var result = await userManager.CreateAsync(uye, vm.Sifre);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("hata", error.Description);
                }

                return View(vm);
            }

            ModelState.AddModelError("hata", "Kullanıcı oluşturulamadı. Girdiğiniz veriler hatalı.");
            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
