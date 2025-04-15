using Microsoft.AspNetCore.Mvc;

namespace MVCCore10IdentityTT.Areas.UyePanel.Controllers
{
    // 23.
    // 24. index.cshtml oluşturulması
    // 25. viewImports ve viewStart dosyalarının arealara kopyalanması (ui layoutu özümsemeleri için)
    [Area("UyePanel")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
