using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore15ManyToMany.Models
{
    public class Kitap
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string Onsoz { get; set; }
        public int SayfaSayisi { get; set; }
        public decimal Fiyat { get; set; }
        public ICollection<KitapYazar>? Yazarlar { get; set; }
    }
}
