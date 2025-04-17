using System.ComponentModel.DataAnnotations;

namespace MVCCore12GenericRepository.ViewModels.Kitaplar
{
    public class KitapEkleVM
    {
        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; } = null!;

        public decimal Fiyat { get; set; }
        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }
        [Display(Name = "Kapak Resmi")]
        public string KapakResmiUrl { get; set; } = null!;
        [Display(Name = "Özet")]
        public string Ozet { get; set; } = null!;

        public int BasimSayisi { get; set; }
        public int YazarId { get; set; }
        public int YayineviId { get; set; }
        public int KategoriId { get; set; }
    }
}