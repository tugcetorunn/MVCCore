using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore13GenericRepository.Models
{
    public class Eylem
    {
        public int EylemId { get; set; }
        public string EylemAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public DateTime? PlanlananBitirmeTarihi { get; set; }
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
        public Durum Durum { get; set; }
        [ForeignKey("Uye")]
        public string EkleyenUye { get; set; }
        public Uye? Uye { get; set; }
    }
}