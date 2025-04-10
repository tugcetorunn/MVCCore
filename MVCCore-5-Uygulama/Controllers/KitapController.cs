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
            var kitaplar = KitapMapleme().ToList();

            return View(kitaplar);
        }

        private IQueryable<KitapGetirVM> KitapMapleme()
        {
            var kitap = context.Kitaplar.Select(x => new KitapGetirVM
            {
                KitapId = x.KitapId, // id eklememizin sebebi index ten gittiğimiz detay düzenle sil sayfalarında id nin gönderilmesi gerekiyor.
                KitapAdi = x.KitapAdi,
                Fiyat = x.Fiyat,
                SayfaSayisi = x.SayfaSayisi,
                KapakResmiUrl = x.KapakResmiUrl,
                Ozet = x.Ozet,
                BasimSayisi = x.BasimSayisi,
                Yazar = x.Yazar.YazarAdSoyad,
                Yayinevi = x.Yayinevi.YayineviAdi,
                Kategori = x.Kategori.KategoriAdi
            });

            return kitap;
        }

        public IActionResult Detay(int id)
        {
            var kitap = KitapMapleme().Where(x => x.KitapId == id).FirstOrDefault();

            return View(kitap);
        }

        public IActionResult Ekle()
        {
            KitapEkleFormVM vm = new KitapEkleFormVM
            {
                Kategoriler = SelectListOlustur()[0],
                Yazarlar = SelectListOlustur()[1],
                Yayinevleri = SelectListOlustur()[2]
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
                Kategoriler = SelectListOlustur()[0],
                Yazarlar = SelectListOlustur()[1],
                Yayinevleri = SelectListOlustur()[2]
            };

            return View(vm);
        }

        public List<SelectList> SelectListOlustur()
        {
            List<SelectList> selectLists = new List<SelectList>
            {
                new SelectList(context.Kategoriler.ToList(), "KategoriId", "KategoriAdi"),
                new SelectList(context.Yazarlar.ToList(), "YazarId", "YazarAdSoyad"),
                new SelectList(context.Yayinevleri.ToList(), "YayineviId", "YayineviAdi")
            };
            return selectLists;
        }

        public IActionResult Duzenle(int id)
        {
            KitapGuncelleFormVM frm = new();
            var kitap = context.Kitaplar.Select(x => new KitapGuncelleVM
            {
                KitapId = x.KitapId,
                KitapAdi = x.KitapAdi,
                Fiyat = x.Fiyat,
                SayfaSayisi = x.SayfaSayisi,
                KapakResmiUrl = x.KapakResmiUrl,
                Ozet = x.Ozet,
                BasimSayisi = x.BasimSayisi
            }).Where(x => x.KitapId == id).SingleOrDefault();

            frm.Kitap = kitap;

            frm.Kategoriler = SelectListOlustur()[0];
            frm.Yazarlar = SelectListOlustur()[1];
            frm.Yayinevleri = SelectListOlustur()[2];

            return View(frm);
        }

        [HttpPost]
        public IActionResult Duzenle(KitapGuncelleVM kitap)
        {
            if (kitap.KapakResmiDosya == null && string.IsNullOrEmpty(kitap.KapakResmiUrl))
            {
                ModelState.AddModelError("KapakResmiUrl", "Kapak resmi seçmelisiniz.");
            } // gerek yok ama kullanım örneği.

            if (ModelState.IsValid)
            {
                Kitap guncelKitap = new()
                {
                    KitapId = kitap.KitapId,
                    KitapAdi = kitap.KitapAdi,
                    SayfaSayisi = kitap.SayfaSayisi,
                    BasimSayisi = kitap.BasimSayisi,
                    Ozet = kitap.Ozet,
                    YazarId = kitap.YazarId,
                    Fiyat = kitap.Fiyat,
                    KategoriId = kitap.KategoriId,
                    YayineviId = kitap.YayineviId
                };

                if (kitap.KapakResmiDosya != null)
                {
                    guncelKitap.KapakResmiUrl = FileOperations.UploadImage(kitap.KapakResmiDosya);
                }

                context.Kitaplar.Update(guncelKitap);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            KitapGuncelleFormVM vm = new KitapGuncelleFormVM
            {
                Kategoriler = SelectListOlustur()[0],
                Yazarlar = SelectListOlustur()[1],
                Yayinevleri = SelectListOlustur()[2]
            };

            return View(vm);
            
        }

        [HttpPost] // get metoduyşa da siler fakat güvenli değil, get metodu direk action ı çalıştırmaya yönelik olduğu için url i girdiğimizde js çalışmadan yani kullanıcıya onay vermeden siler. o yüzden post metodu kullanıyoruz.
        public IActionResult Sil(int id)
        {
            var kitap = context.Kitaplar.Where(x => x.KitapId == id).FirstOrDefault();
            if (kitap != null)
            {
                context.Kitaplar.Remove(kitap);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // detay ve liste için viewmodeller düzenlenecek ayrı vm olacak. ne gösterilecekse.
        // display name attributeleri ekle
        // sayfasayisi short olsun
    }
}
