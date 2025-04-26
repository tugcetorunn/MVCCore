using MVCCore17SinavOncesiUygulama.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    /// <summary>
    /// tek bir kitap için olan bilgileri kullanıcıya gösterecek view model
    /// </summary>
    public class KitapDetayVM
    {
        [Display(Name = "Kitap Id")]
        public int KitapId { get; set; }

        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }

        [Display(Name = "Özet")]
        public string Ozet { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }
        public ICollection<KitapKategoriVM> Kategoriler { get; set; }

        [Display(Name = "Ekleyen Üye")]
        public string UyeAd { get; set; }
        public string UyeId { get; set; }
    }
}
