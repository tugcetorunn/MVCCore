using Microsoft.AspNetCore.Mvc;
using MVCCore_4_Validations.Models;

namespace MVCCore_4_Validations.Controllers
{
    public class MusteriController : Controller
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
        public IActionResult Ekle(Musteri musteri)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }
    }
}
