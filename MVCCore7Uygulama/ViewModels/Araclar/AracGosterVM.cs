using MVCCore7Uygulama.Models;

namespace MVCCore7Uygulama.ViewModels.Araclar
{
    public class AracGosterVM
    {
        public string Uye { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public int Model { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
    }
}
