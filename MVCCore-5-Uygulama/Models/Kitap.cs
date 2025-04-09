namespace MVCCore_5_Uygulama.Models
{
    public class Kitap
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int SayfaSayisi { get; set; }
        public string KapakResmiUrl { get; set; }
        public string Ozet { get; set; }
        public int YazarId { get; set; }
        public Yazar? Yazar { get; set; }
        public int YayineviId { get; set; }
        public Yayinevi? Yayinevi { get; set; }
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
