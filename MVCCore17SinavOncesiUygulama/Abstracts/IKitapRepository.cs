using MVCCore17SinavOncesiUygulama.Models;
using MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar;

namespace MVCCore17SinavOncesiUygulama.Abstracts
{
    /// <summary>
    /// irepositoryden genel metodları alır, kitap için özel metodlar oluşturur
    /// </summary>
    public interface IKitapRepository : IRepository<Kitap>
    {
        List<KitapListeleVM> TumKitaplar();
        List<KitapListeleVM> UyeyeOzelListele(string uyeId);
        void KitapEkle(KitapEkleVM kitap, string uyeId);
        void KitapGuncelle(KitapGuncelleVM kitap);
        KitapDetayVM DetayGetir(int kitapId);
        KitapGuncelleFormVM GuncellemeFormuOlustur(int kitapId, string uyeId);
        KitapEkleFormVM EklemeFormuOlustur(string uyeId);
    }
}
