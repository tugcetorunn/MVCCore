using MVCCore13GenericRepository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore13GenericRepository.ViewModels.Eylemler
{
    public class EylemGuncelleVM
    {
        public int EylemId { get; set; }
        public string EylemAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime? PlanlananBitirmeTarihi { get; set; }
        public int KategoriId { get; set; }
        public Durum Durum { get; set; }
    }
}
