namespace MVCCore17SinavOncesiUygulama.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<KitapKategori>? Kitaplar { get; set; }
    }
}
