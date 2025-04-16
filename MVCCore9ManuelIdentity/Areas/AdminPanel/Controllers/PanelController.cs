using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore9ManuelIdentity.Data;
using MVCCore9ManuelIdentity.Models;
using MVCCore9ManuelIdentity.ViewModels.Ürünler;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCCore9ManuelIdentity.Areas.AdminPanel.Controllers
{
    // identity 11. adım area oluşturulması kolay yol -> projeye sağ tık add -> new scaffolded item -> area seçiyoruz. sonra isim yazıyoruz. controller ve view lar otomatik oluşturuluyor.
    // identity 12. adım area içlerine controller eklenmesi
    [Area("AdminPanel")] // unutulmamalı yoksa ekran gelmiyor.
    // identity 21. adım authorize attribute ekliyoruz.
    [Authorize(Roles = "Admin")] // sadece admin rolü olanlar bu controller a erişebilir. bunu yapmazsak uye olarak giriş yaptığımızda bu controller a erişim sağlanıyor. büyük hata...
    public class PanelController : Controller
    {
        private readonly UrunDbContext context;
        private readonly UserManager<Uye> userManager;
        public PanelController(UrunDbContext _context, UserManager<Uye> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            var urunler = context.Urunler.Select(x => new UrunListeleVM
            {
                UrunAdi = x.UrunAdi,
                Aciklama = x.Aciklama,
                Fiyat = x.Fiyat,
                ResimYolu = x.ResimYolu,
                EkleyenUye = x.Uye.AdSoyad,
                Kategori = x.Kategori.KategoriAdi

            }).ToList();

            return View(urunler);
        }

        public IActionResult UrunEkle()
        {
            var model = new UrunEkleFormVM
            {
                Kategoriler = new SelectList(context.Kategoriler.ToList(), "KategoriId", "KategoriAdi")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(UrunEkleVM urun)
        {
            if (ModelState.IsValid)
            {
                //var username = User.Identity.Name;

                //var users = User.FindAll(ClaimTypes.NameIdentifier);

                //foreach (var user in users)
                //{
                //    if (user.Value == "1")
                //    {
                //        return View();
                //    }
                //}

                // 1. yol
                var uyeId= Convert.ToInt32(userManager.GetUserId(User));

                // 2. yol
                var uye = await userManager.GetUserAsync(User);
                var userId = uye.Id; // await userManager.GetUserIdAsync(uye); da yazabiliriz.

                var yeniUrun = new Urun
                {
                    UrunAdi = urun.UrunAdi,
                    Aciklama = urun.Aciklama,
                    Fiyat = urun.Fiyat,
                    ResimYolu = urun.ResimYolu,
                    KategoriId = urun.KategoriId,
                    EkleyenUye = userId /*int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)*/
                };
                context.Urunler.Add(yeniUrun);


                context.SaveChanges();
                //return Redirect("~/Home/Index"); area dışındaki bir yere ulaşmak istediğimizde kullanabiliriz. redirecttoaction da action parametre alan override metod yok. bu yüzden redirect ile url verdiğimiz her yere adres varsa ulaşabiliriz. veya
                return RedirectToAction("Index"); // route u boş bırakınca home a gidiyo olabilir bakılacak.
                //return Content(User.FindFirst("Id").Value + " " + User.FindFirst("Id").ValueType);
            }

            var form = new UrunEkleFormVM
            {
                Kategoriler = new SelectList(context.Kategoriler.ToList(), "KategoriId", "KategoriAdi")
            };

            return View(form);
        }
    }
}
