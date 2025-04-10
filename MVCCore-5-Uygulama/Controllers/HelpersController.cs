using Microsoft.AspNetCore.Mvc;

namespace MVCCore_5_Uygulama.Controllers
{
    public class HelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
