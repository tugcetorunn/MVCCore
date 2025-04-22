using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore15ManyToMany.Models
{
    public class Yazar
    {
        public int YazarId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [NotMapped]
        public string AdSoyad => Ad + " " + Soyad;
        public ICollection<KitapYazar>? Kitaplar { get; set; }
    }
}