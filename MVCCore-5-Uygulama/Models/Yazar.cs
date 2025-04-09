using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore_5_Uygulama.Models
{
    public class Yazar
    {
        public int YazarId { get; set; }
        [StringLength(50, ErrorMessage = "Yazar adı 50 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "Yazar adı boş olamaz.")]
        public string YazarAdi { get; set; }
        [StringLength(50, ErrorMessage = "Yazar soyadı 50 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "Yazar soyadı boş olamaz.")]
        public string YazarSoyadi { get; set; }
        [StringLength(500, ErrorMessage = "Biyografi 500 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "Biyografi boş olamaz.")]
        public string Biyografi { get; set; }
        [NotMapped]
        public string YazarAdSoyad => YazarAdi + " " + YazarSoyadi;
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
