using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore7Uygulama.ViewModels.Araclar
{
    public class AracEkleFormVM
    {
        public SelectList Markalar { get; set; }
        public AracEkleVM Arac { get; set; }
        // public string UyeAdi { get; set; }
    }
}
