using Microsoft.AspNetCore.Mvc;

namespace MVCCore11IdentityUygulama.Areas.EditorArea.Controllers
{
    [Area("EditorArea")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
