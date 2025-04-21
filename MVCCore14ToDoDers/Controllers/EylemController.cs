using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore14ToDoDers.Services.EylemService;
using MVCCore14ToDoDers.Services.KategoriService;
using MVCCore14ToDoDers.Services.LoginService;
using MVCCore14ToDoDers.ViewModels.Eylemler;

namespace MVCCore14ToDoDers.Controllers
{
    public class EylemController : Controller
    {
        private readonly IEylemService eylemService;
        private readonly IKategoriService kategoriService;
        private readonly ILoginService loginService;
        private readonly IMapper mapper;
        public EylemController(IEylemService _eylemService, IKategoriService _kategoriService, ILoginService _loginService, IMapper _mapper)
        {
            eylemService = _eylemService;
            kategoriService = _kategoriService;
            loginService = _loginService;
            mapper = _mapper;
        }
        public IActionResult Listele()
        {
            var eylemler = eylemService.TumEylemler(loginService.GetUserId(User));
            return View(eylemler); // NullReferenceException: Object reference not set to an instance of an object. hatası geldi view e veriyi göndermezsek gelir.
        }

        public IActionResult Ekle()
        {
            EylemEklemeFormVM form = new EylemEklemeFormVM();
            form.Kategoriler = new SelectList(kategoriService.TumKategoriler(), "KategoriId", "KategoriAdi");
            return View(form);
        }

        public IActionResult Ekle(EylemEkleVM eylem)
        {
            if (ModelState.IsValid)
            {
                eylem.UserId = loginService.GetUserId(User);
                eylemService.EylemEkle(eylem);
                return RedirectToAction("Listele");
            }
            EylemEklemeFormVM form = new EylemEklemeFormVM();
            form.Kategoriler = new SelectList(kategoriService.TumKategoriler(), "KategoriId", "KategoriAdi");
            return View(form);
        }
    }
}
