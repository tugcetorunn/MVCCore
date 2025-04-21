using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCore14ToDoDers.Services.LoginService;
using MVCCore14ToDoDers.ViewModels.Auth;

namespace MVCCore14ToDoDers.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILoginService loginService;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;
        public AuthController(ILoginService _loginService, SignInManager<IdentityUser> _signInManager, IMapper _mapper)
        {
            loginService = _loginService;
            mapper = _mapper;
            signInManager = _signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        // string.IsNullOrEmpty(userId)
        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = loginService.Login(vm);
                if (user != null)
                {
                    // Kullanıcı adı ve şifre doğruysa, kullanıcıyı giriş yaptır
                    signInManager.SignInAsync(user, isPersistent: false).Wait(); // signin yapmadan user property si dolmuyor.
                    return RedirectToAction("Listele", "Eylem");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                loginService.Register(vm);
                return RedirectToAction("Login");
            }
            return View(vm);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait(); // signout async olduğu için wait ettik. yoksa hemen redirect yapıyor. signout işlemi bitmeden redirect yapıyor. bu yüzden wait ettik.
            return RedirectToAction("Login");
        }
    }
}
