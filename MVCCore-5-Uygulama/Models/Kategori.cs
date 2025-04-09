namespace MVCCore_5_Uygulama.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }   
    }
}
