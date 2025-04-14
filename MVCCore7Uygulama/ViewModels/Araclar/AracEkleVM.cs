using MVCCore7Uygulama.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCCore7Uygulama.ViewModels.Araclar
{
    public class AracEkleVM
    {
        public string Plaka { get; set; }
        [Display(Name = "Markalar")]
        public int MarkaId { get; set; }
        public int Model { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        // public int UyeId { get; set; } // bu değişkeni kullanmıyoruz çünkü sessiondan alıyoruz
    }
}
