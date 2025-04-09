using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore_5_Uygulama.Contexts;
using MVCCore_5_Uygulama.Models;
using MVCCore_5_Uygulama.Utilities;
using MVCCore_5_Uygulama.ViewModels;

namespace MVCCore_5_Uygulama.Controllers
{
    public class KitapController : Controller
    {
        private readonly SahafDbContext context;
        public KitapController(SahafDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var kitaplar = context.Kitaplar.Select(x => new KitapGetirVM
            {
                KitapAdi = x.KitapAdi,
                Fiyat = x.Fiyat,
                SayfaSayisi = x.SayfaSayisi,
                KapakResmiUrl = x.KapakResmiUrl,
                Ozet = x.Ozet,
                BasimSayisi = x.BasimSayisi,
                Yazar = x.Yazar.YazarAdSoyad,
                Yayinevi = x.Yayinevi.YayineviAdi,
                Kategori = x.Kategori.KategoriAdi
            }).ToList();

            return View(kitaplar);
        }

        public IActionResult Ekle()
        {
            KitapEkleFormVM vm = new KitapEkleFormVM
            {
                Kategoriler = new SelectList(context.Kategoriler.ToList(), "KategoriId", "KategoriAdi"),
                Yazarlar = new SelectList(context.Yazarlar.ToList(), "YazarId", "YazarAdSoyad"),
                Yayinevleri = new SelectList(context.Yayinevleri.ToList(), "YayineviId", "YayineviAdi")
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Ekle(KitapEkleVM kitap)
        {
            if(ModelState.IsValid)
            {
                Kitap yeniKitap = new Kitap
                {
                    KitapAdi = kitap.KitapAdi,
                    Fiyat = kitap.Fiyat,
                    KategoriId = kitap.KategoriId,
                    YazarId = kitap.YazarId,
                    YayineviId = kitap.YayineviId,
                    SayfaSayisi = kitap.SayfaSayisi,
                    Ozet = kitap.Ozet,
                    BasimSayisi = kitap.BasimSayisi
                };

                yeniKitap.KapakResmiUrl = FileOperations.UploadImage(kitap.KapakResmiDosya);

                context.Kitaplar.Add(yeniKitap);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            KitapEkleFormVM vm = new KitapEkleFormVM
            {
                Kategoriler = new SelectList(context.Kategoriler.ToList(), "KategoriId", "KategoriAdi"),
                Yazarlar = new SelectList(context.Yazarlar.ToList(), "YazarId", "YazarAdSoyad"),
                Yayinevleri = new SelectList(context.Yayinevleri.ToList(), "YayineviId", "YayineviAdi")
            };

            return View(vm);
        }


    }
}
