using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore_5_Uygulama.Models
{
    public class Yazar
    {
        public int YazarId { get; set; }
        public string YazarAdi { get; set; }
        public string YazarSoyadi { get; set; }
        public string Biyografi { get; set; }
        [NotMapped]
        public string YazarAdSoyad => YazarAdi + " " + YazarSoyadi;
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
