using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore15ManyToMany.Data;
using MVCCore15ManyToMany.Models;
using MVCCore15ManyToMany.ViewModels.Kitap;

namespace MVCCore15ManyToMany.Controllers
{
    public class KitapController : Controller
    {
        private readonly SahafDbContext context;
        public KitapController(SahafDbContext _context)
        {
            context = _context;
        }
        public IActionResult Listele()
        {
            var kitaplar = context.Kitaplar.Select(x => new KitapListeleVM
            {
                KitapAdi = x.KitapAdi,
                Fiyat = x.Fiyat,
                Onsoz = x.Onsoz,
                KitapId = x.KitapId,
                SayfaSayisi = x.SayfaSayisi,
                Yazarlar = x.Yazarlar.Select(ky => ky.Yazar.AdSoyad)
            });
            return View(kitaplar);
        }

        public IActionResult Ekle()
        {
            KitapEkleFormVM form = new KitapEkleFormVM()
            {
                Yazarlar = new SelectList(context.Yazarlar.ToList(), "YazarId", "AdSoyad")
            };
            return View(form);
        }

        [HttpPost]
        public IActionResult Ekle(KitapEkleVM kitap)
        {
            if (ModelState.IsValid)
            {
                Kitap yeniKitap = new Kitap
                {
                    KitapAdi = kitap.KitapAdi,
                    Fiyat = kitap.Fiyat,
                    SayfaSayisi = kitap.SayfaSayisi,
                    Onsoz = kitap.Onsoz
                };

                //yeniKitap.YazarIdler = kitap.YazarIdler;
                // birden fazla savechanges ile ekleme
                //context.Kitaplar.Add(yeniKitap);
                //context.SaveChanges();

                //List<KitapYazar> iliskiler = new();

                //foreach (var item in kitap.YazarIdler)
                //{
                //    iliskiler.Add(new KitapYazar
                //    {
                //        KitapId = yeniKitap.KitapId,
                //        YazarId = item
                //    });
                //}

                //context.KitapYazar.AddRange(iliskiler);

                //context.SaveChanges();

                // tek savechanges kullanımı
                context.Kitaplar.Add(yeniKitap);

                List<KitapYazar> iliskiler = new();

                foreach (var item in kitap.YazarIdler)
                {
                    iliskiler.Add(new KitapYazar
                    {
                        Kitap = yeniKitap, // direk nav prop a gönderdik.
                        YazarId = item,
                    });
                }

                context.SaveChanges();

                return RedirectToAction("Listele");
            }

            KitapEkleFormVM form = new KitapEkleFormVM()
            {
                Yazarlar = new SelectList(context.Yazarlar.ToList(), "YazarId", "AdSoyad")
            };
            return View(form);

        }

        public IActionResult Guncelle()
        {
            KitapGuncelleFormVM form = new()
            {
                Yazarlar = new SelectList(context.Yazarlar.ToList(), "YazarId", "AdSoyad")
            };
            return View(form);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapGuncelleVM kitap)
        {
            if (ModelState.IsValid)
            {
                var eskiKitap = context.Kitaplar.Find(kitap.KitapId);
                eskiKitap.SayfaSayisi = kitap.SayfaSayisi;
                eskiKitap.Fiyat = kitap.Fiyat;
                eskiKitap.Onsoz = kitap.Onsoz;
                eskiKitap.KitapAdi = kitap.KitapAdi;

                var eskiKitapYazarlar = context.KitapYazar.Select(x => new { Yazar = x.YazarId, Kitap = x.KitapId }).Where(k => k.Kitap == eskiKitap.KitapId);

                // context.KitapYazar.Select

                return RedirectToAction("Listele");
            }

            KitapGuncelleFormVM form = new()
            {
                Yazarlar = new SelectList(context.Yazarlar.ToList(), "YazarId", "AdSoyad")
            };
            return View(form);
        }
    }
}
