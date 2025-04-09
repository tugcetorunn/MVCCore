namespace MVCCore_5_Uygulama.ViewModels
{
    public class KitapEkleVM
    {
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int SayfaSayisi { get; set; }
        public IFormFile KapakResmiUrl { get; set; }
        public string Ozet { get; set; }
        public int YazarId { get; set; }
        public int YayineviId { get; set; }
        public int KategoriId { get; set; }
    }
}
