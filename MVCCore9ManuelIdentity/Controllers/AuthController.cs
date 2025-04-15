using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCore9ManuelIdentity.Data;
using MVCCore9ManuelIdentity.Models;
using MVCCore9ManuelIdentity.ViewModels;
using System.Threading.Tasks;

namespace MVCCore9ManuelIdentity.Controllers
{
    // identity 6. adım controller oluşturulması
    public class AuthController : Controller
    {
        private readonly UrunDbContext context;
        private readonly UserManager<Uye> userManager;
        private readonly SignInManager<Uye> signInManager;

        public AuthController(UserManager<Uye> _userManager, UrunDbContext _context, SignInManager<Uye> _signInManager)
        {
            userManager = _userManager;
            context = _context;
            signInManager = _signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            // identity 7. adım login işlemi

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = userManager.FindByNameAsync(vm.UserName).Result; // await keywordünün yaptığını (çıktıyı task tan kurtarmak) result ta yapar. ama await kullanmak daha mantıklı çünkü result kullanırsak task ı beklemeden diğer kod çalışır ve hata alırız. await ile task ı bekleriz. ?

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                return View();
            }

            if (await userManager.CheckPasswordAsync(user, vm.Password))
            {
                var result = await signInManager.PasswordSignInAsync(user, vm.Password, false, false); // 3. parametre isPersistent benihatırla işlevini yani oturum kalıcı olsun mu sorusuna cevaptır. true yaparsak cookie süresi dolana kadar oturum açık kalır. false yaparsak browser ı kapatınca oturumu kapatır.

                if (result.Succeeded) {
                    return RedirectToAction("Index", "Home");
                }

                // signInAsync metodu da var fakat o metod şifre kontrolü yapmadan doğrudan bir kullanıcıyı oturum açmış sayar. signInManager.SignInAsync(user, false);
            }

            ModelState.AddModelError("", "Şifre hatalı");

            //var result = await signInManager.PasswordSignInAsync(user, vm.Password, true, false); // kullanıcı id sini cookie ye de yazdığı için user ve password checkleri yeterli değil aslında bu metodu kullanmamız gerekir.

            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    var resultPassword = await signInManager.CheckPasswordSignInAsync(user, vm.Password, false);

            //    if (!resultPassword.Succeeded)
            //    {
            //        ModelState.AddModelError("", "Şifre hatalı");
            //    }
            //}
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            // identity 8. adım register işlemi

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = new Uye
            {
                UserName = vm.UserName,
                Email = vm.Email,
                Ad = vm.Ad,
                Soyad = vm.Soyad,
                Adres = vm.Adres
            };
            
            var result = await userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                // identity 18. adım kullanıcıya rol atama işlemi
                await userManager.AddToRoleAsync(user, "Uye"); // bu kodu çalıştırmadan önce rolü oluşturmalıyız. yoksa hata alırız.
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); // modelstate kullanıp error ları görmek istiyorsak bu koddan sonra bir de cshtml de validation-summary all eklememiz gerek.
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout() // kullanıcı giriş yaptığında 
        {
            // identity 9. adım logout işlemi
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
