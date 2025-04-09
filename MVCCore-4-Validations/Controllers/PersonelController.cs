using Microsoft.AspNetCore.Mvc;
using MVCCore_4_Validations.Models;

namespace MVCCore_4_Validations.Controllers
{
    public class PersonelController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Personel personel)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        public IActionResult KullaniciEkle()
        {
            return View();
            // return View("Index"); // yanlışlıkla mesela index sayfasına ekleme formunu yazdıysak bu şekilde return view index i verebiliriz.
        }

        [HttpPost]
        public IActionResult KullaniciEkle(KullaniciEkleVM kullanici)
        {
            if (ModelState.IsValid)
            {
                return Content("başarılı...");
            }
            return View();
        }
    }
}
