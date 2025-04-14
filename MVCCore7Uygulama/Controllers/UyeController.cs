using Microsoft.AspNetCore.Mvc;
using MVCCore7Uygulama.Contexts;
using MVCCore7Uygulama.Hashers;
using MVCCore7Uygulama.Models;
using MVCCore7Uygulama.ViewModels.Uyeler;

namespace MVCCore7Uygulama.Controllers
{
    public class UyeController : Controller
    {
        private readonly GaleriDbContext context;
        public UyeController(GaleriDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(GirisVM vm)
        {
            //  && x.Sifre == Md5.Hash(vm.Sifre)
            var kullanici = context.Uyeler.Where(x => x.KullaniciAdi == vm.KullaniciAdi).FirstOrDefault();

            if (kullanici == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(vm);
            }

            if (kullanici.Sifre != Md5.Hash(vm.Sifre))
            {
                ModelState.AddModelError("", "Şifre hatalı.");
                return View(vm);
            }

            // kullanıcıyla ilgili diğer bilgilerin de session a kaydedilmesi gerekir şişirmemek için. fakat kolaylık olması açısından username cookie olarak tutulabilir. tekrar girişte hatırlatması için?
            // Kullanıcı bilgilerini sessiona kaydetme

            HttpContext.Session.SetInt32("UyeId", kullanici.UyeId);

            return RedirectToAction("Index", "Galeri");
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(KayitVM vm)
        {
            if (ModelState.IsValid)
            {
                Uye uye = new Uye
                {
                    Ad = vm.Ad,
                    Soyad = vm.Soyad,
                    KullaniciAdi = vm.KullaniciAdi,
                    Sifre = Md5.Hash(vm.Sifre)
                };

                context.Uyeler.Add(uye);
                context.SaveChanges();
                return RedirectToAction("GirisYap");
            }
            return View(vm);
        }
        public IActionResult Test()
        {
            return Content(Md5.Hash("deneme123"));
        }
    }
}
