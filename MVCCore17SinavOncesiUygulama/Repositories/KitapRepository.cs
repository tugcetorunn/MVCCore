using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Data;
using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.Services.Concretes;
using MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar;

namespace MVCCore17SinavOncesiUygulama.Repositories
{
    /// <summary>
    /// kitap modeline özel metodların controller da sadece çağrılmak üzere oluşturulduğu repository sınıfı
    /// </summary>
    public class KitapRepository : BaseRepository<Kitap>, IKitapRepository
    {
        private readonly IKategoriRepository kategoriRepository; // select list oluşturulurken kategoriRspository nin listele metodunu çağırmak için inject edildi
        public KitapRepository(KitapDbContext _context, IKategoriRepository _kategoriRepository) : base(_context)
        {
            kategoriRepository = _kategoriRepository;
        }

        public List<KitapListeleVM> TumKitaplar()
        {
            // home sayfasında kullanıcı olan veya olmayan tüm ziyaretçilerin göreceği liste
            return IliskiliGetirYardimciMetod().Select(x => new KitapListeleVM
            {
                KitapAdi = x.KitapAdi,
                Fiyat = x.Fiyat,
                SayfaSayisi = x.SayfaSayisi,
                KitapId = x.KitapId,
                UyeAd = x.Uye.AdSoyad, // üye adını göstermek için
                UyeId = x.UyeId // oturum açan kullanıcı eğer bu kitabı ekleyen kullanıcı ise güncelle butonu gelir, değilse güncelle butonu gelmez.
            }).ToList();
        }

        public List<KitapListeleVM> UyeyeOzelListele(string uyeId)
        {
            // kullanıcının kendi ekediği kitapların listelendiği metod
            return TumKitaplar().Where(x => x.UyeId == uyeId).ToList();
        }

        public void KitapGuncelle(KitapGuncelleVM kitap)
        {
            // güncellenecek kitabın bulunması
            var eskiKitap = KitapBul(kitap.KitapId);

            // database de kayıtlıysa yeni değerlerin atanması
            if (eskiKitap != null)
            {
                eskiKitap.KitapAdi = kitap.KitapAdi;
                eskiKitap.Fiyat = kitap.Fiyat;
                eskiKitap.Ozet = kitap.Ozet;
                eskiKitap.SayfaSayisi = kitap.SayfaSayisi;

                // önceden seçilmiş kategoriler siliniyor;
                eskiKitap.Kategoriler.Clear();
                foreach (var kategoriId in kitap.KategoriIdler)
                {
                    // yeni seçilmiş kategoriler ekleniyor
                    KitapKategori iliski = new() { KategoriId = kategoriId, Kitap = eskiKitap };
                    eskiKitap.Kategoriler.Add(iliski);
                }
                context.SaveChanges();
            }
        }
        
        public KitapDetayVM DetayGetir(int kitapId)
        {
            // hem ortak listede hem üyeye özel listede detay için çalışacak metod
            var kitap = IliskiliGetirYardimciMetod().Where(x => x.KitapId == kitapId).SingleOrDefault();
            if(kitap != null)
            {
                return new KitapDetayVM
                {
                    KitapId = kitap.KitapId,
                    KitapAdi = kitap.KitapAdi,
                    Fiyat = kitap.Fiyat,
                    Ozet = kitap.Ozet,
                    SayfaSayisi = kitap.SayfaSayisi,
                    UyeAd = kitap.Uye.AdSoyad, // üye adını göstermek için
                    UyeId = kitap.UyeId, // bu detay sayfasına gelen kullanıcı eğer bu kitabı ekleyen kullanıcı ise güncelle butonu gelir, değilse güncelle butonu gelmez.
                    Kategoriler = kitap.Kategoriler?.Select(k => new KitapKategoriVM
                    {
                        KategoriId = k.KategoriId,
                        KategoriAdi = k.Kategori.KategoriAdi
                    }).ToList() ?? new List<KitapKategoriVM>()
                };
            }

            return null;
        }

        public void KitapEkle(KitapEkleVM kitap, string uyeId)
        {
            // kullanıcıdan yeni kitap değerlerinin alınması
            var yeniKitap = new Kitap
            {
                KitapAdi = kitap.KitapAdi,
                Fiyat = kitap.Fiyat,
                Ozet = kitap.Ozet,
                SayfaSayisi = kitap.SayfaSayisi,
                UyeId = uyeId
            };

            // seçilen kategorilerin ilişki propertysine eklenmesi
            yeniKitap.Kategoriler = new List<KitapKategori>();
            foreach (var item in kitap.KategoriIdler)
            {
                KitapKategori iliski = new() { KategoriId = item, Kitap = yeniKitap };
                yeniKitap.Kategoriler.Add(iliski);
            }

            Ekle(yeniKitap);
        }

        public KitapGuncelleFormVM GuncellemeFormuOlustur(int kitapId, string uyeId)
        {
            // güncellenmek üzere seçilmiş kitabın eski değerlerinin ve kategorilerin forma aktarılması
            var kitap = KitapBul(kitapId);
            if (kitap != null && kitap.Uye.Id == uyeId) // kendi kitabıysa güncelleyebilir 
            {
                KitapGuncelleFormVM form = new KitapGuncelleFormVM
                {
                    Kitap = new KitapGuncelleVM
                    {
                        KitapId = kitap.KitapId,
                        KitapAdi = kitap.KitapAdi,
                        Fiyat = kitap.Fiyat,
                        Ozet = kitap.Ozet,
                        SayfaSayisi = kitap.SayfaSayisi,
                        KategoriIdler = kitap.Kategoriler?.Select(k => k.KategoriId).ToList() // önceden seçilmiş kategorilerin formda seçili gelmesi için
                    },
                    Kategoriler = new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAdi")
                };
                return form;
            }

            return null;
        }

        public KitapEkleFormVM EklemeFormuOlustur(string uyeId)
        {
            // tüm kategorilerin forma aktarılması
            KitapEkleFormVM form = new KitapEkleFormVM
            {
                Kategoriler = new SelectList(kategoriRepository.Listele(), "KategoriId", "KategoriAdi")
            };
            return form;
        }

        public Kitap KitapBul(int id)
        {
            // güncelleme işlemi ve formu oluşturma metodları için tekrarı önlemek için oluşturulan metod
            var kitap = IliskiliGetirYardimciMetod()
                .Where(x => x.KitapId == id).SingleOrDefault();

            return kitap;
        }

        public IQueryable<Kitap> IliskiliGetirYardimciMetod()
        {
            // nav prop ları getirmek (eager loading) istediğimiz metodlarda tekrarı önlemek için oluşturulan metod
            var queryableKitap = table.Include(x => x.Uye)
                .Include(x => x.Kategoriler)
                .ThenInclude(k => k.Kategori);
            return queryableKitap;
        }

    }
}
