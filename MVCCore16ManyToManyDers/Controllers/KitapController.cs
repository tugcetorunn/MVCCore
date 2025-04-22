using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Ekle(Kitap kitap, int[] yazarIds)
        {
            //string strIds = "";
            //foreach (int id in yazarIds) 
            //{
            //    strIds += " " + id;
            //}
            // return Content("Seçilen yazar id ler: " + strIds);

            

            return View();
        }
    }
}
