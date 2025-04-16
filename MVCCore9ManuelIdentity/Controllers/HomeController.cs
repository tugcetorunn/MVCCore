using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore9ManuelIdentity.Data;
using MVCCore9ManuelIdentity.Models;
using MVCCore9ManuelIdentity.ViewModels.Ürünler;
using System.Diagnostics;
using System.Security.Claims;

namespace MVCCore9ManuelIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UrunDbContext context;

        public HomeController(ILogger<HomeController> logger, UrunDbContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            var urunler = context.Urunler.Select(x => new UrunListeleVM
            {
                UrunAdi = x.UrunAdi,
                Aciklama = x.Aciklama,
                Fiyat = x.Fiyat,
                ResimYolu = x.ResimYolu,
                EkleyenUye = x.Uye.AdSoyad,
                Kategori = x.Kategori.KategoriAdi

            }).ToList();

            return View(urunler);
        }

        //public IActionResult Ekle()
        //{
        //    var model = new UrunEkleFormVM
        //    {
        //        Kategoriler = new SelectList(context.Kategoriler.ToList(), "KategoriId", "KategoriAdi")
        //    };
        //    return View(model);
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public IActionResult Ekle(UrunEkleVM urun)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var yeniUrun = new Urun
        //        {
        //            UrunAdi = urun.UrunAdi,
        //            Aciklama = urun.Aciklama,
        //            Fiyat = urun.Fiyat,
        //            ResimYolu = urun.ResimYolu,
        //            KategoriId = urun.KategoriId,
        //            EkleyenUye = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
        //        };
        //        context.Urunler.Add(yeniUrun);


        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //        //return Content(User.FindFirst("Id").Value + " " + User.FindFirst("Id").ValueType);
        //    }

        //    var form = new UrunEkleFormVM
        //    {
        //        Kategoriler = new SelectList(context.Kategoriler.ToList(), "KategoriId", "KategoriAdi")
        //    };

        //    return View(form);
        //}
    }
}
