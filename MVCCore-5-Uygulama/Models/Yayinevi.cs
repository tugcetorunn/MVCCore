using System.ComponentModel.DataAnnotations;

namespace MVCCore_5_Uygulama.Models
{
    public class Yayinevi
    {
        public int YayineviId { get; set; }
        [Required(ErrorMessage = "Yayınevi adı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Yayınevi adı en fazla 100 karakter olabilir.")]
        public string YayineviAdi { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
