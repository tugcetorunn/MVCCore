namespace MVCCore10IdentityTT.Models
{
    // 1.
    public class Arac
    {
        public int AracId { get; set; }
        public string Plaka { get; set; }
        public decimal Fiyat { get; set; }
        public int MarkaId { get; set; }
        public int UyeId { get; set; }
        public Marka? Marka { get; set; }
        public Uye? Uye { get; set; }
        public int Model { get; set; }
        public string Renk { get; set; }
        public string Aciklama { get; set; }
    }
}
