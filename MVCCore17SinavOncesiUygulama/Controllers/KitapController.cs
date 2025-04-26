using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.Services.Abstracts;
using MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar;
using System.Diagnostics;

namespace MVCCore17SinavOncesiUygulama.Controllers
{
    /// <summary>
    /// kitap ile ilgili önyüz isteklerini alıp işleyen veri geri döndüren controller
    /// </summary>
    public class KitapController : Controller
    {
        private readonly IKitapRepository kitapRepository;
        private readonly IKategoriRepository kategoriRepository;
        private readonly IKitapKategoriRepository kitapKategoriRepository;
        private readonly IAuthService authService;
        public KitapController(IKitapRepository _kitapRepository, IAuthService _authService, IKategoriRepository _kategoriRepository, IKitapKategoriRepository _kitapKategoriRepository)
        {
            kitapRepository = _kitapRepository;
            authService = _authService;
            kategoriRepository = _kategoriRepository;
            kitapKategoriRepository = _kitapKategoriRepository;
        }

        [Authorize] 
        public IActionResult Listele()
        {
            var userId = authService.UserIdGetir(User);
            var kitaplar = kitapRepository.UyeyeOzelListele(userId);
            return View(kitaplar);
        }

        // tüm ziyaretçilerin göreceği detay sayfasını da getirdiği için sadece detay actionında authorize yok
        public IActionResult Detay(int kitapId)
        {
            ViewBag.UserId = authService.UserIdGetir(User);
            var kitapDetay = kitapRepository.DetayGetir(kitapId);
            return View(kitapDetay);
        }

        [Authorize]
        public IActionResult Ekle()
        {
            return View(kitapRepository.EklemeFormuOlustur(authService.UserIdGetir(User)));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Ekle(KitapEkleVM kitap)
        {
            if (ModelState.IsValid)
            {
                kitapRepository.KitapEkle(kitap, authService.UserIdGetir(User));
                return RedirectToAction("Listele");
            }

            var form = kitapRepository.EklemeFormuOlustur(authService.UserIdGetir(User));
            form.Kitap = kitap;
            return View(form);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Sil(int kitapId)
        {
            kitapRepository.Sil(kitapId);
            return RedirectToAction("Listele");
        }

        [Authorize]
        public IActionResult Guncelle(int kitapId)
        {
            var form = kitapRepository.GuncellemeFormuOlustur(kitapId, authService.UserIdGetir(User));
            if (form != null)
                return View(form);
            return RedirectToAction("Login", "Auth"); // kitap null gelirse veya üyenin kitabı değilse logine atar
        }

        [HttpPost]
        [Authorize]
        public IActionResult Guncelle(KitapGuncelleVM kitap)
        {
            if (ModelState.IsValid)
            {
                kitapRepository.KitapGuncelle(kitap);
                return RedirectToAction("Listele");
            }

            var form = kitapRepository.GuncellemeFormuOlustur(kitap.KitapId, authService.UserIdGetir(User));
            return View(form);
        }
    }
}
