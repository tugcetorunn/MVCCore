using Microsoft.AspNetCore.Mvc;
using MVCCore_1.Models;
using Newtonsoft.Json;

namespace MVCCore_1.Controllers
{
    public class UrunController : Controller
    {
        static List<Urun> urunler = new List<Urun>();

        public IActionResult UrunleriGetir()
        {
            return View(urunler);
        }
        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            urunler.Add(urun);
            return RedirectToAction("UrunleriGetir");
        }

        
    }
}
