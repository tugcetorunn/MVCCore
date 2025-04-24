using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.Services.Abstracts;
using MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar;

namespace MVCCore17SinavOncesiUygulama.Controllers
{
    [Authorize]
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
        public IActionResult Listele()
        {
            var userId = authService.UserIdGetir(User);
            var kitaplar = kitapRepository.UyeyeOzelListele(userId);
            return View(kitaplar);
        }

        public IActionResult Ekle()
        {
            KitapEkleFormVM form = new KitapEkleFormVM
            {
                Kategoriler = new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAdi")
            };
            return View(form);
        }

        [HttpPost]
        public IActionResult Ekle(KitapEkleVM kitap)
        {
            if (ModelState.IsValid)
            {
                var yeniKitap = new Kitap
                {
                    KitapAdi = kitap.KitapAdi,
                    Fiyat = kitap.Fiyat,
                    Ozet = kitap.Ozet,
                    SayfaSayisi = kitap.SayfaSayisi,
                    UyeId = authService.UserIdGetir(User)
                };

                yeniKitap.Kategoriler = new List<KitapKategori>();
                foreach (var item in kitap.KategoriIdler)
                {
                    KitapKategori iliski = new() { KategoriId = item, Kitap = yeniKitap };
                    yeniKitap.Kategoriler.Add(iliski);
                    //kitapKategoriRepository.Ekle(iliski);
                }
                
                kitapRepository.Ekle(yeniKitap);

                return RedirectToAction("Listele");
            }
            KitapEkleFormVM form = new KitapEkleFormVM
            {
                Kategoriler = new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAdi"),
                Kitap = kitap
            };
            return View(form);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            kitapRepository.Sil(id);
            return RedirectToAction("Listele");
        }

        public IActionResult Guncelle(int id)
        {
            var kitap = kitapRepository.KitapBul(id);
            KitapGuncelleFormVM form = new KitapGuncelleFormVM
            {
                Kitap = new KitapGuncelleVM
                {
                    KitapId = kitap.KitapId,
                    KitapAdi = kitap.KitapAdi,
                    Fiyat = kitap.Fiyat,
                    Ozet = kitap.Ozet,
                    SayfaSayisi = kitap.SayfaSayisi,
                    KategoriIdler = kitap.Kategoriler?.Select(k => k.KategoriId).ToList()
                },
                Kategoriler = new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAdi")
            };
            return View(form);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapGuncelleVM kitap)
        {
            if (ModelState.IsValid)
            {
                kitapRepository.KitapGuncelle(kitap);
                return RedirectToAction("Listele");
            }

            KitapGuncelleFormVM form = new KitapGuncelleFormVM
            {
                Kategoriler = new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAdi")
            };
            return View(form);
        }
    }
}
