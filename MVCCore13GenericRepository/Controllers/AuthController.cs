using Microsoft.AspNetCore.Mvc;
using MVCCore13GenericRepository.Services.Abstracts;
using MVCCore13GenericRepository.ViewModels.Auth;
using System.Threading.Tasks;

namespace MVCCore13GenericRepository.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUyeService uyeService;
        public AuthController(IUyeService _uyeService)
        {
            uyeService = _uyeService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("hata", "Kullanıcı adı veya şifre geçersiz.");
                return View(vm);
            }
            if(await uyeService.Login(vm))
                return RedirectToAction("Listele", "Eylem");

            ModelState.AddModelError("hata", "Kullanıcı adı veya şifre geçersiz.");
            return View(vm);
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
                if (await uyeService.Register(vm))
                    return RedirectToAction("Login");

                ModelState.AddModelError("hata", "Kayıt yapılamadı.");
                return View(vm);
            }

            ModelState.AddModelError("hata", "Kayıt olurken hata oluştu. Veriler geçerli değil.");
            return View(vm);
        }

        public IActionResult Logout()
        {
            uyeService.Logout();
            return RedirectToAction("Login");
        }
    }
}
