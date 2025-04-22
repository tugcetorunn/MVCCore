using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore16ManyToManyDers.Models
{
    public class KitapYazar
    {
        public int KitapId { get; set; }
        public int YazarId { get; set; }
        public Yazar? Yazar { get; set; }
        public Kitap? Kitap { get; set; }
    }
}
