using MVCCore13GenericRepository.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore13GenericRepository.ViewModels.Eylemler
{
    public class EylemListeleVM
    {
        public int EylemId { get; set; }
        [Display(Name = "Eylem")]
        public string EylemAdi { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime EklenmeTarihi { get; set; }
        public Durum Durum { get; set; }
    }
}
