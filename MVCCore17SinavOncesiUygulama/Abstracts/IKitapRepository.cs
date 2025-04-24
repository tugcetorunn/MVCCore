using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar;

namespace MVCCore17SinavOncesiUygulama.Abstracts
{
    public interface IKitapRepository : IRepository<Kitap>
    {
        List<KitapListeleVM> UyeyeOzelListele(string uyeId);
        void KitapGuncelle(KitapGuncelleVM kitap);
        Kitap KitapBul(int id);
    }
}
