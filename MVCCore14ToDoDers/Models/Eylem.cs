using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore14ToDoDers.Models
{
    public class Eylem
    {
        public int EylemId { get; set; }
        public string EylemAdi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime EylemTarihi { get; set; }
        public string Aciklama { get; set; }
        public bool TamamlandiMi { get; set; } = false;
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
