namespace MVCCore_5_Uygulama.Models
{
    public class Yayinevi
    {
        public int YayineviId { get; set; }
        public string YayineviAdi { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
