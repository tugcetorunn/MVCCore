using Microsoft.AspNetCore.Mvc;
using MVCCore_6_CookieSession.Models;
using MVCCore_6_CookieSession.ViewModels;

namespace MVCCore_6_CookieSession.Controllers
{
    public class UrunController : Controller
    {
        private readonly Yy2UrunDbContext context;
        public UrunController(Yy2UrunDbContext _context)
        {
            context = _context; 
        }
        public IActionResult Index()
        {
            var urunler = context.Urunlers.Select(x => new UrunlerVM() 
            {
                UrunId = x.UrunId,
                UrunAdi = x.UrunAdi,
                Fiyat = x.Fiyat,
                Resim = x.Resim,
                KategoriAdi = x.Kategori.KategoriAdi
            }).ToList();

            return View(urunler);
        }

        public IActionResult CerezOlustur()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(15);
            Response.Cookies.Append("sepet", "ürünler ->", cookieOptions);
            return Content("Cerez olustu...");
        }

        //public IActionResult SepeteEkle()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult SepeteEkle(int id)
        {
            var urun = context.Urunlers.Select(x => new SepettekiUrunVM { UrunId = id, UrunAdi = x.UrunAdi }).FirstOrDefault();
            // Response.Cookies.Append("sepet", urun.UrunAdi);

            string urunler = Request.Cookies["sepet"];

            if (urunler != null)
            {
                urunler += id + ";";
            }
            else
            {
                urunler = id + ";";
            }

            Response.Cookies.Append("sepet", urunler);

            return RedirectToAction("Index");
            return NoContent();
        }

        public IActionResult SepetiGor()
        {
            string urunlerString = Request.Cookies["sepet"];

            return Content("Sepet icerigi : " + urunlerString);
        }
    }
}
