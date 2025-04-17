using System.ComponentModel.DataAnnotations;

namespace MVCCore12GenericRepository.ViewModels.Kitaplar
{
    public class KitapListeleVM
    {
        public int KitapId { get; set; } // unutma linklere gelen id nin actiona düşmesi için buradan id nin gelmesi lazım
        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; } = null!;

        public decimal Fiyat { get; set; }
        [Display(Name = "Kapak Resmi")]
        public string KapakResmiUrl { get; set; } = null!;
        public int BasimSayisi { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public string Kategori { get; set; }
    }
}
