using Microsoft.AspNetCore.Mvc;
using MVCCore_1.Models;

namespace MVCCore_1.Controllers
{
    // .../controller/action/id
    // .../area/controller/action/id
    public class BaslangicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public string Index()
        //{
        //    return "hello mvc";
        //}

        public IActionResult VeriAktar()
        {
            ViewData["mesaj"] = "merhabalar"; // key-vaelue mantığıyla çalışan bir nesnedir.
            ViewBag.Message = "Helloo";

            Urun urun = new Urun() { UrunId = 1, UrunAdi = "T Cetveli", Fiyat = 500};


            //ViewData["urun"] = urun.UrunId + " - " + urun.UrunAdi + " - " + urun.Fiyat;
            //ViewBag.Product = urun.UrunId + " - " + urun.UrunAdi + " - " + urun.Fiyat;

            ViewData["urun"] = urun;
            ViewBag.Product = urun;

            List<Urun> urunler = new()
            {
                new Urun() { UrunId = 2, UrunAdi = "silgi", Fiyat = 55 },
                new Urun() { UrunId = 3, UrunAdi = "kalem", Fiyat = 75 },
                new Urun() { UrunId = 4, UrunAdi = "ruj", Fiyat = 150 }
            };

            // özel kullanım
            ViewData["urunler"] = urunler;

            return View();
        }

        public IActionResult ModelKullanimi()
        {
            Urun urun = new Urun() { UrunId = 1, UrunAdi = "T Cetveli", Fiyat = 500 };

            return View(urun);
        }

        public IActionResult TumUrunler()
        {
            List<Urun> urunler = new()
            {
                new Urun() { UrunId = 2, UrunAdi = "silgi", Fiyat = 55 },
                new Urun() { UrunId = 3, UrunAdi = "kalem", Fiyat = 75 },
                new Urun() { UrunId = 4, UrunAdi = "ruj", Fiyat = 150 }
            };

            return View(urunler);
        }

        public IActionResult VeriAl()
        {
            return View();
        }

        // queryString kullanımı
        public IActionResult VerileriYakalaWithGet() 
        {
            string veriler = Request.QueryString.Value;

            veriler = veriler.Substring(1, veriler.Length - 1);
            string[] values = veriler.Split('&');

            string[] degerler = new string[values.Length];
            int count = 0;
            foreach (var value in values)
            {
                degerler[count] = value.Split('=')[count];
            }

            return Content(degerler[0] + " " + degerler[1] + " " + degerler[2]);
            
        }

        // requestForm kullanımı
        public IActionResult VerileriYakalaWithRF()
        {
            string ad = Request.Form["ad"];
            string soyad = Request.Form["soyad"];
            int yas = int.Parse(Request.Form["yas"]);
            // Request.Form.TryGetValue da kullanılabilir.
            return Content(ad + " " + soyad + " " + yas);
        }

        //IFormCollection kullanımı
        public IActionResult VerileriYakalaWithIFC(IFormCollection frm)
        {
            string ad = frm["ad"];
            string soyad = frm["soyad"];
            int yas = int.Parse(frm["yas"]);
            return Content(ad + " " + soyad + " " + yas);
        }

        // parametre kullanımı
        public IActionResult VerileriYakalaWithParameter(string ad, string soyad, int yas)
        {
            return Content(ad + " " + soyad + " " + yas);
        }

        public IActionResult VerileriYakalaWithParameterModel(Personel personel)
        {
            return Content(personel.Ad + " " + personel.Soyad + " " + personel.Yas);
        }
    }
}
