namespace MVCCore7Uygulama.Models
{
    public class Arac
    {
        public int AracId { get; set; }
        public string Plaka { get; set; }
        public int MarkaId { get; set; }
        public Marka? Marka { get; set; }
        public int Model { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public int UyeId { get; set; } // ismi farklı yazarsak [foreignKey("Uye")] attribute ü ile bağlantı sağlayabilirz.
        public Uye? Uye { get; set; }
    }
}
