using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MVCCore14ToDoDers.ViewModels.Eylemler
{
    public class EylemEkleVM
    {
        [Display(Name = "Eylem")]
        public string EylemAdi { get; set; }
        [Display(Name = "Eylem Tarihi")]
        public DateTime EylemTarihi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }
        public string? UserId { get; set; }
    }
}
