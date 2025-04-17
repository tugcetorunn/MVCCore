using Microsoft.EntityFrameworkCore;
using MVCCore12GenericRepository.Data;
using MVCCore12GenericRepository.Models;
using MVCCore12GenericRepository.ViewModels.Kitaplar;

namespace MVCCore12GenericRepository.Repositories
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        public KitapRepository(SahafDbContext _context) : base(_context)
        {
        }

        public KitapDetayVM IliskiliKitapDetay(int id)
        {
            var kitap = context.Kitaplar
                .Include(x => x.Yazar)
                .Include(x => x.Kategori)
                .Include(x => x.Yayinevi)
                .Select(x => new KitapDetayVM
                {
                    KitapId = x.KitapId,
                    KitapAdi = x.KitapAdi,
                    Fiyat = x.Fiyat,
                    SayfaSayisi = x.SayfaSayisi,
                    KapakResmiUrl = x.KapakResmiUrl,
                    Ozet = x.Ozet,
                    BasimSayisi = x.BasimSayisi,
                    Yazar = x.Yazar.YazarAdSoyad,
                    Yayinevi = x.Yayinevi.YayineviAdi,
                    Kategori = x.Kategori.KategoriAdi
                }).FirstOrDefault(x => x.KitapId == id);

            if (kitap != null)
            {
                return kitap;
            }
            else
            {
                throw new Exception("Kitap bulunamadı.");
            }
        }

        public ICollection<KitapListeleVM> IliskiliKitapListele()
        {
            var kitaplar = context.Kitaplar
                .Include(x => x.Yazar)
                .Include(x => x.Kategori)
                .Include(x => x.Yayinevi)
                .Select(x => new KitapListeleVM
                {
                    KitapId = x.KitapId,
                    KitapAdi = x.KitapAdi,
                    Fiyat = x.Fiyat,
                    KapakResmiUrl = x.KapakResmiUrl,
                    BasimSayisi = x.BasimSayisi,
                    Yazar = x.Yazar.YazarAdSoyad,
                    Yayinevi = x.Yayinevi.YayineviAdi,
                    Kategori = x.Kategori.KategoriAdi
                }).ToList();
            return kitaplar;
        }
    }
}
