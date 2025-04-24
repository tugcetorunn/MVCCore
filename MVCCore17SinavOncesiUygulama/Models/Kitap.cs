using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore17SinavOncesiUygulama.Models
{
    public class Kitap
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public ICollection<KitapKategori>? Kategoriler { get; set; }
        [ForeignKey("Uye")]
        public string UyeId { get; set; }
        public Uye? Uye { get; set; }
    }
}
