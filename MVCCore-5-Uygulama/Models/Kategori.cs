using System.ComponentModel.DataAnnotations;

namespace MVCCore_5_Uygulama.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        [StringLength(50, ErrorMessage = "Kategori adı 50 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "Kategori adı boş olamaz.")]
        public string KategoriAdi { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }   
    }
}
