using System.ComponentModel.DataAnnotations;

namespace MVCCore_4_Validations.Models
{
    public class Personel
    {
        public int PersonelId { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(10, ErrorMessage = "Ad alanı en fazla 10 karakter olmalıdır.")]
        public string Ad { get; set; }
        //[Required(ErrorMessage = "Soyad alanı zorunludur.")]
        //[MinLength(3, ErrorMessage = "Soyad alanı en az 3 karakterden oluşmalıdır."), MaxLength(10, ErrorMessage = "Soyad alanı en fazla 10 karakter olmalıdır.")]
        [Required]
        [MinLength(3), MaxLength(10)]
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        [Range(12,99)]
        public int Yas { get; set; }
        public decimal Maas { get; set; }
        public long TCKimlikNo { get; set; }
        public Bolum Bolum { get; set; } // nullable olmasa da valid summary de gözükmüyor required olarak?
    }
}