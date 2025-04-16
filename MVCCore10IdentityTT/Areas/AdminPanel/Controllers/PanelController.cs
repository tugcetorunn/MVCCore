using Microsoft.AspNetCore.Mvc;

namespace MVCCore10IdentityTT.Areas.AdminPanel.Controllers
{
    // 21.
    // 22. index.cshtml oluşturulması
    [Area("AdminPanel")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
