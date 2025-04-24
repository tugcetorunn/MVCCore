using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCCore13GenericRepository.Models;
using MVCCore13GenericRepository.Services.Abstracts;
using MVCCore13GenericRepository.ViewModels.Eylemler;

namespace MVCCore13GenericRepository.Controllers
{
    [Authorize]
    public class EylemController : Controller // işlerin userid ye göre gelmesi lazım önemli hemen ayarlanacak
    {
        private readonly IEylemService eylemService;
        public EylemController(IEylemService _eylemService)
        {
            eylemService = _eylemService;
        }

        public IActionResult Listele()
        {
            var eylemler = eylemService.IliskiliListele(User.Identity.Name);
            return View(eylemler);
        }

        public IActionResult Ekle()
        {
            var form = eylemService.EklemeFormOlustur();

            return View(form);
        }

        [HttpPost]
        public IActionResult Ekle(EylemEklemeVM eylem)
        {
            if (ModelState.IsValid)
            {
                if (eylemService.Ekle(eylem, User.Identity.Name))
                {
                    return RedirectToAction("Listele");
                }
            }

            var form = eylemService.EklemeFormOlustur();
            return View(form);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            eylemService.Sil(id);
            return RedirectToAction("Listele");
        }

        public IActionResult Guncelle(int id)
        {
            var frm = eylemService.GuncellemeFormOlustur(id);
            return View(frm);
        }

        [HttpPost]
        public IActionResult Guncelle(EylemGuncelleVM eylem)
        {
            if (ModelState.IsValid)
            {
                eylemService.Guncelle(eylem);
                return RedirectToAction("Listele");
            }
            var frm = eylemService.GuncellemeFormOlustur(eylem.EylemId);
            return View(frm);
        }


    }
}
