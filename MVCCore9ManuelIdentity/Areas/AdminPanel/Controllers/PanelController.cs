using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCCore9ManuelIdentity.Areas.AdminPanel.Controllers
{
    // identity 11. adım area oluşturulması kolay yol -> projeye sağ tık add -> new scaffolded item -> area seçiyoruz. sonra isim yazıyoruz. controller ve view lar otomatik oluşturuluyor.
    // identity 12. adım area içlerine controller eklenmesi
    [Area("AdminPanel")] // unutulmamalı yoksa ekran gelmiyor.
    // identity 21. adım authorize attribute ekliyoruz.
    [Authorize(Roles = "Admin")] // sadece admin rolü olanlar bu controller a erişebilir. bunu yapmazsak uye olarak giriş yaptığımızda bu controller a erişim sağlanıyor. büyük hata...
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
