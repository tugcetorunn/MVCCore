using Microsoft.AspNetCore.Mvc;
using MVCCore12GenericRepository.Repositories;

namespace MVCCore12GenericRepository.Controllers
{
    public class KategoriController : Controller
    {
        private readonly KategoriRepository kategoriRepository;
        public KategoriController(KategoriRepository _kategoriRepository)
        {
            kategoriRepository = _kategoriRepository;
        }
        public IActionResult Index()
        {
            return View(kategoriRepository.Listele());
        }

    }
}
