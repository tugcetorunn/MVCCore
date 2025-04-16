using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore11IdentityUygulama.Data;
using MVCCore11IdentityUygulama.Models;
using MVCCore11IdentityUygulama.Utilities;
using MVCCore11IdentityUygulama.ViewModels.Haberler;
using System.Threading.Tasks;

namespace MVCCore11IdentityUygulama.Controllers
{
    // 22. haber işlemleri için gerekli controller ların oluşturulması
    public class HaberController : Controller
    {
        private readonly HaberPortalDbContext dbContext;
        private readonly UserManager<Editor> userManager;
        public HaberController(HaberPortalDbContext _dbContext, UserManager<Editor> _userManager)
        {
            dbContext = _dbContext;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            var haberler = dbContext.Haberler.Select(x => new HaberListeleVM
            {
                HaberId = x.HaberId,
                Baslik = x.Baslik,
                ResimYolu = x.ResimYolu,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                Kategori = x.Kategori.KategoriAdi
            }).ToList();

            return View(haberler);
        }

        public IActionResult Detay(int id)
        {
            //var haber = dbContext.Haberler.Select(x => new HaberDetayVM
            //{
            //    Baslik = x.Baslik,
            //    Detay = x.Detay,
            //    ResimYolu = x.ResimYolu,
            //    OlusturulmaTarihi = x.OlusturulmaTarihi,
            //    Kategori = x.Kategori.KategoriAdi
            //}).FirstOrDefault(x => x.HaberId == id);

            var haber = dbContext.Haberler
                .Where(x => x.HaberId == id)
                .Select(x => new HaberDetayVM
                {
                    HaberId = x.HaberId,
                    Baslik = x.Baslik,
                    Detay = x.Detay,
                    ResimYolu = x.ResimYolu,
                    OlusturulmaTarihi = x.OlusturulmaTarihi,
                    Kategori = x.Kategori.KategoriAdi
                })
                .FirstOrDefault();

            return View(haber);
        }

        [Authorize(Roles = "Admin, Editor")]
        public IActionResult HaberEkle()
        {
            HaberEkleFormVM frm = new HaberEkleFormVM() { Kategoriler = KategoriSelectListOlustur() };
            return View(frm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IActionResult HaberEkle(HaberEkleVM haber)
        {
            if (!ModelState.IsValid)
            {
                return View(haber);
            }
            Haber yeniHaber = new Haber
            {
                Baslik = haber.Baslik,
                Detay = haber.Detay,
                EditorId = int.Parse(userManager.GetUserId(User)),
                KategoriId = haber.KategoriId,
                OlusturulmaTarihi = DateTime.Now,
                ResimYolu = FileOperations.UploadImage(haber.ResimDosyasi),
            };

            dbContext.Haberler.Add(yeniHaber);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Editor")]
        public IActionResult HaberGuncelle(int id)
        {
            var haber = dbContext.Haberler
                .Where(x => x.HaberId == id)
                .Select(x => new HaberGuncelleVM
                {
                    Baslik = x.Baslik,
                    Detay = x.Detay,
                    ResimYolu = x.ResimYolu,
                    KategoriId = x.KategoriId
                }).FirstOrDefault();
            var frm = new HaberGuncelleFormVM
            {
                Kategoriler = KategoriSelectListOlustur(),
                Haber = haber
            }; // değerler gelsin
            return View(frm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IActionResult HaberGuncelle(HaberEkleVM haber)
        {
            
            return View(haber);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Sil(int id)
        {
            var haber = dbContext.Haberler.Find(id);
            dbContext.Haberler.Remove(haber);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList KategoriSelectListOlustur()
        {
            return new SelectList(dbContext.Kategoriler.ToList(), "KategoriId", "KategoriAdi");
        }
    }
}
