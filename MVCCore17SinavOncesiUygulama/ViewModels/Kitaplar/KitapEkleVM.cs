using MVCCore17SinavOncesiUygulama.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    /// <summary>
    /// kitap ekleme formu için kullanıcıdan alınacak bilgileri tutan view model
    /// </summary>
    public class KitapEkleVM
    {
        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; }
        [RegularExpression(@"^\d+([.,]\d{1,2})?$", ErrorMessage = "Fiyat geçerli bir sayı olmalıdır.")] // çalışması için önyüzde input type number olmalı
        [Range(0, 10000000, ErrorMessage = "Fiyat geçerli bir sayı olmalıdır.")]
        public decimal Fiyat { get; set; }

        [Display(Name = "Özet")]
        public string Ozet { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }
        public ICollection<int> KategoriIdler { get; set; }

    }
}
