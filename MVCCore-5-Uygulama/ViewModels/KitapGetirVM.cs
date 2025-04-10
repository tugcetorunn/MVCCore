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
        public IFormFile KapakResmiDosya { get; set; }
        public string Ozet { get; set; }
        public int BasimSayisi { get; set; }
        public string Yazar { get; set; } // yazar, kategori, yayınevi için id de bulunmalı. çünkü ileride örn imdb sitesindeki gibi oyuncuya tıklayınca o oyuncunun filmleri listelendiği gibi yazara ait kitaplari yayınevine ait kitaplar, o kategorideki kitaplar listelenecek. o yüzden id lazım
        public string Yayinevi { get; set; }
        public string Kategori { get; set; }
    }
}
