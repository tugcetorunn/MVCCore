namespace MVCCore7Uygulama.Models
{
    public class Marka
    {
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public ICollection<Arac>? Araclar { get; set; }
    }
}
