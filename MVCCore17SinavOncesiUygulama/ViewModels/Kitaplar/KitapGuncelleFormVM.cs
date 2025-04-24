using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    public class KitapGuncelleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public KitapGuncelleVM Kitap { get; set; }
    }
}
