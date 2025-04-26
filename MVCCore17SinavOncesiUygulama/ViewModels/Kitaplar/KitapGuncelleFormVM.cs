using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    /// <summary>
    /// güncelleme formu için gerekenleri modelleyen class
    /// </summary>
    public class KitapGuncelleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public KitapGuncelleVM Kitap { get; set; }
    }
}
