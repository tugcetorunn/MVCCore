﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore12GenericRepository.Models;
using MVCCore12GenericRepository.Repositories;
using MVCCore12GenericRepository.ViewModels.Kitaplar;

namespace MVCCore12GenericRepository.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapRepository kitapRepository;
        private readonly YazarRepository yazarRepository;
        private readonly YayineviRepository yayineviRepository;
        private readonly KategoriRepository kategoriRepository;
        private readonly IMapper mapper;
        public KitapController(KitapRepository _kitapRepository, YazarRepository _yazarRepository, YayineviRepository _yayineviRepository, KategoriRepository _kategoriRepository, IMapper _mapper)
        {
            kitapRepository = _kitapRepository;
            yazarRepository = _yazarRepository;
            yayineviRepository = _yayineviRepository;
            kategoriRepository = _kategoriRepository;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            //var kitaplar = kitapRepository.Listele(x => x.Yayinevi, x => x.Yazar, x => x.Kategori);
            //var kitaplarVM = mapper.Map<ICollection<KitapListeleVM>>(kitaplar);

            var kitaplar = kitapRepository.IliskiliKitapListele();

            return View(kitaplar);
        }

        public IActionResult Detay(int id)
        {
            //var kitap = kitapRepository.Bul(id, x => x.Yazar, x => x.Kategori, x => x.Yayinevi);
            //var kitap = kitapRepository.Bul(id); // nav lar gelmez.
            //if (kitap != null)
            //{
            //    var kitapDetayVM = mapper.Map<KitapDetayVM>(kitap);
            //    return View(kitapDetayVM);
            //}
            //ModelState.AddModelError("", "Kitap bulunamadı.");

            var kitap = kitapRepository.IliskiliKitapDetay(id);

            if (kitap != null)
            {
                return View(kitap);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Ekle()
        {
            KitapEkleFormVM frm = new KitapEkleFormVM
            {
                Kategoriler = SelectListOlustur()[0],
                Yazarlar = SelectListOlustur()[1],
                Yayinevleri = SelectListOlustur()[2]
            };
            return View(frm);
        }

        [HttpPost]
        public IActionResult Ekle(KitapEkleVM kitap)
        {
            // modelstate leri unutma
            if (ModelState.IsValid)
            {
                Kitap yeniKitap = new Kitap(){};
                mapper.Map(kitap, yeniKitap);
                kitapRepository.Ekle(yeniKitap);
                return RedirectToAction("Index");
            }

            return View(kitap);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            Kitap kitap = kitapRepository.Bul(id);
            if (kitap != null)
            {
                kitapRepository.Sil(id);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Silinecek kitap bulunamadı.");
            return RedirectToAction("Index");
        }
        public List<SelectList> SelectListOlustur()
        {
            List<SelectList> selectLists = new List<SelectList>
            {
                new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAdi"),
                new SelectList(yazarRepository.Listele(), "YazarId", "YazarAdSoyad"),
                new SelectList(yayineviRepository.Listele(), "YayineviId", "YayineviAdi")
            };
            return selectLists;
        }

        public IActionResult Guncelle(int id)
        {
            KitapGuncelleFormVM frm = new KitapGuncelleFormVM
            {
                Kitap = mapper.Map(kitapRepository.IliskiliKitapDetay(id), new KitapGuncelleVM()),
                Kategoriler = SelectListOlustur()[0],
                Yazarlar = SelectListOlustur()[1],
                Yayinevleri = SelectListOlustur()[2]
            };
            return View(frm);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapGuncelleVM kitap)
        {
            if (ModelState.IsValid)        
            {
                Kitap guncelKitap = kitapRepository.Bul(kitap.KitapId);
                if (guncelKitap != null)
                {
                    guncelKitap = mapper.Map(kitap, guncelKitap);
                    kitapRepository.Guncelle(guncelKitap);
                    return RedirectToAction("Index");
                }
            }
            KitapGuncelleFormVM frm = new KitapGuncelleFormVM
            {
                Kategoriler = SelectListOlustur()[0],
                Yazarlar = SelectListOlustur()[1],
                Yayinevleri = SelectListOlustur()[2]
            };
            return View(frm);
        }

    }
}
