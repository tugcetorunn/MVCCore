using Microsoft.EntityFrameworkCore;
using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Data;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar;

namespace MVCCore17SinavOncesiUygulama.Repositories
{
    public class KitapRepository : BaseRepository<Kitap>, IKitapRepository
    {
        public KitapRepository(KitapDbContext _context) : base(_context)
        {
        }

        public Kitap KitapBul(int id)
        {
            var kitap = table.Include(x => x.Uye)
                .Include(x => x.Kategoriler)
                .Where(x => x.KitapId == id).SingleOrDefault();

            return kitap;
        }
        public void KitapGuncelle(KitapGuncelleVM kitap)
        {
            var eskiKitap = KitapBul(kitap.KitapId);
            if (eskiKitap != null)
            {
                eskiKitap.KitapAdi = kitap.KitapAdi;
                eskiKitap.Fiyat = kitap.Fiyat;
                eskiKitap.Ozet = kitap.Ozet;
                eskiKitap.SayfaSayisi = kitap.SayfaSayisi;
                // Kategorileri güncelle
                eskiKitap.Kategoriler.Clear();
                foreach (var kategoriId in kitap.KategoriIdler)
                {
                    KitapKategori iliski = new() { KategoriId = kategoriId, Kitap = eskiKitap };
                    eskiKitap.Kategoriler.Add(iliski);
                }
                context.SaveChanges();
            }
        }

        public List<KitapListeleVM> UyeyeOzelListele(string uyeId)
        {
            var kitaplar = table.Include(x => x.Kategoriler)
            .ThenInclude(k => k.Kategori).Where(x => x.UyeId == uyeId).ToList();
            var kitaplarVm = kitaplar.Select(x => new KitapListeleVM
            {
                KitapId = x.KitapId,
                KitapAdi = x.KitapAdi,
                Fiyat = x.Fiyat,
                Ozet = x.Ozet,
                SayfaSayisi = x.SayfaSayisi,
                UyeId = x.UyeId,
                Kategoriler = x.Kategoriler?.Select(k => new KitapKategoriVM
                {
                    KategoriId = k.KategoriId,
                    KategoriAdi = k.Kategori.KategoriAdi
                }).ToList() ?? new List<KitapKategoriVM>()
            }).ToList();

            return kitaplarVm;
        }
    }
}
