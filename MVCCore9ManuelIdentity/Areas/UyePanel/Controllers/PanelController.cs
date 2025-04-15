using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCCore9ManuelIdentity.Areas.UyePanel.Controllers
{
    [Area("UyePanel")]
    [Authorize(Roles = "Uye")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
