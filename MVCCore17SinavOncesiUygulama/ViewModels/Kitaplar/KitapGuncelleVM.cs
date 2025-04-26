using MVCCore17SinavOncesiUygulama.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    /// <summary>
    /// kitap güncelleme sayfasında önyüzde gereken propertyler için view model
    /// </summary>
    public class KitapGuncelleVM
    {
        public int KitapId { get; set; }
        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; }

        [RegularExpression(@"^\d+([.,]\d{1,2})?$", ErrorMessage = "Fiyat geçerli bir sayı olmalıdır.")] // ondalıklı sayıları da kabul eder
        [Range(0, 10000000, ErrorMessage = "Fiyat geçerli bir sayı olmalıdır.")]
        public decimal Fiyat { get; set; }

        [Display(Name = "Özet")]
        public string Ozet { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }
        public List<int>? KategoriIdler { get; set; }
    }
}