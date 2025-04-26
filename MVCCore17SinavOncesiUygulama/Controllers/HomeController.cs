using Microsoft.AspNetCore.Mvc;
using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.Services.Abstracts;
using System.Diagnostics;

namespace MVCCore17SinavOncesiUygulama.Controllers
{
    /// <summary>
    /// ilk açýlacak olan controller. tüm ziyaretçiler için tüm kitaplar burada listeleniyor.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKitapRepository kitapRepository;
        private readonly IAuthService authService;

        public HomeController(ILogger<HomeController> logger, IKitapRepository _kitapRepository, IAuthService _authService)
        {
            _logger = logger;
            kitapRepository = _kitapRepository;
            authService = _authService;
        }

        public IActionResult Index()
        {
            ViewBag.UserId = authService.UserIdGetir(User); // listede kitap giriþ yapan üyenin ise güncelle butonu getirilmesi için view e kitabý ekleyen üyenin id lerini gönderiyoruz.
            return View(kitapRepository.TumKitaplar());
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
    }
}
