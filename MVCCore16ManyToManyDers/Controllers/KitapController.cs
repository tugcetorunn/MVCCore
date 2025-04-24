using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore16ManyToManyDers.Data;
using MVCCore16ManyToManyDers.Models;
using MVCCore16ManyToManyDers.ViewModels;

namespace MVCCore16ManyToManyDers.Controllers
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
            return View();
        }

        public IActionResult Ekle()
        {
            KitapEkleFormVM form = new KitapEkleFormVM()
            {
                Yazarlar = context.Yazarlar.Select(x => new YazarVM { AdSoyad = x.AdSoyad, YazarId = x.YazarId }).ToList(),
            };
            return View(form);
        }

        [HttpPost]
        public IActionResult Ekle(Kitap kitap, int[] yazarIds)
        {
            //string strIds = "";
            //foreach (int id in yazarIds) 
            //{
            //    strIds += " " + id;
            //}
            // return Content("Seçilen yazar id ler: " + strIds);

            if (ModelState.IsValid)
            {
                Kitap yeniKitap = new Kitap
                {
                    KitapAdi = kitap.KitapAdi,
                    Fiyat = kitap.Fiyat,
                    SayfaSayisi = kitap.SayfaSayisi,
                    Onsoz = kitap.Onsoz
                };

                context.Kitaplar.Add(yeniKitap);

                List<KitapYazar> iliskiler = new();

                foreach (var item in yazarIds)
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
                Yazarlar = context.Yazarlar.Select(x => new YazarVM { AdSoyad = x.AdSoyad, YazarId = x.YazarId }).ToList(),
            };
            return View(form);

        }
    }
}
