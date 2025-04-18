using MVCCore13GenericRepository.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore13GenericRepository.ViewModels.Eylemler
{
    public class EylemEklemeVM
    {

        [Display(Name = "Eylem")]
        public string EylemAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "Planlanan Bitirme Tarihi")]
        public DateTime? PlanlananBitirmeTarihi { get; set; }
        public int KategoriId { get; set; }
        public Durum Durum { get; set; }
    }
}
