namespace MVCCore10IdentityTT.Models
{
    public class Marka
    {
        public int MarkaId { get; set; }
        public string MarkaAd { get; set; }
        public List<Arac>? Araclar { get; set; }
    }
}