using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.Services.Abstracts;
using MVCCore13GenericRepository.ViewModels.Eylemler;

namespace MVCCore13GenericRepository.Controllers
{
    [Authorize]
    public class EylemController : Controller
    {
        private readonly IEylemService eylemService;
        public EylemController(IEylemService _eylemService)
        {
            eylemService = _eylemService;
        }

        public IActionResult Listele()
        {
            var eylemler = eylemService.IliskiliListele();
            return View(eylemler);
        }

        public IActionResult Ekle()
        {
            var form = eylemService.FormOlustur();

            return View(form);
        }

        [HttpPost]
        public IActionResult Ekle(EylemEklemeVM eylem)
        {
            if (ModelState.IsValid)
            {
                if (eylemService.Ekle(eylem))
                {
                    return RedirectToAction("Listele");
                }
            }

            var form = eylemService.FormOlustur();
            return View(form);
        }

        public IActionResult Detay(string id)
        {
            return View();
        }

        public IActionResult Sil(string id)
        {
            return View();
        }

        public IActionResult Guncelle(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guncelle(EylemGuncelleVM eylem)
        {
            return View();
        }


    }
}
