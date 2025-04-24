namespace MVCCore17SinavOncesiUygulama.Models
{
    public class KitapKategori
    {
        public int KategoriId { get; set; }
        public int KitapId { get; set; }
        public Kitap? Kitap { get; set; }
        public Kategori? Kategori { get; set; }
    }
}