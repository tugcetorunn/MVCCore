using MVCCore_5_Uygulama.Models;

namespace MVCCore_5_Uygulama.ViewModels
{
    public class KitapGetirVM
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int SayfaSayisi { get; set; }
        public string KapakResmiUrl { get; set; }
        public IFormFile KapakResmiDosya { get; set; } // string???
        public string Ozet { get; set; }
        public int BasimSayisi { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public string Kategori { get; set; }
    }
}
