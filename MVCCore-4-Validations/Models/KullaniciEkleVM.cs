using MVCCore_4_Validations.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace MVCCore_4_Validations.Models
{
    public class KullaniciEkleVM
    {
        [Required, MaxLength(20)]
        public string Ad { get; set; }
        [Required, MaxLength(20)]
        public string Soyad { get; set; }
        [Required, MinLength(5), MaxLength(20), RazorKarakteriOlamaz(ErrorMessage = "@ karakteri olamaz.")]
        public string KullaniciAdi { get; set; }
        //[RegularExpression("")] // kendi patternimizi oluşturup buna göre validation sağlıyor.
        [Required, MinLength(8), MaxLength(12)]
        public string Sifre { get; set; }
        [Required, MinLength(8), MaxLength(12), Compare("Sifre", ErrorMessage = "Şifre ve şifre tekrarı uyuşmuyor.")]
        public string SifreTekrari { get; set; }
    }
}
