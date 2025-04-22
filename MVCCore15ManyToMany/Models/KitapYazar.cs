using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore15ManyToMany.Models
{
    public class KitapYazar
    {
        [ForeignKey("Kitap")]
        public int KitapId { get; set; }
        [ForeignKey("Yazar")]
        public int YazarId { get; set; }
        public Yazar? Yazar { get; set; }
        public Kitap? Kitap { get; set; }
    }
}
