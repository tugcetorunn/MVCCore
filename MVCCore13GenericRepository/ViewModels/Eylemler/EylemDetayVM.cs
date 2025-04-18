using MVCCore13GenericRepository.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCCore13GenericRepository.ViewModels.Eylemler
{
    public class EylemDetayVM
    {

        public int EylemId { get; set; }
        [Display(Name = "Eylem")]
        public string EylemAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime EklenmeTarihi { get; set; }
        [Display(Name = "Planlanan Bitirme Tarihi")]
        public DateTime? PlanlananBitirmeTarihi { get; set; }
        public string Kategori { get; set; }
        public Durum Durum { get; set; }
    }
}
