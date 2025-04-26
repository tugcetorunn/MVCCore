using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    /// <summary>
    /// kitap ekleme formu için gereken özellikleri modelleyen class
    /// </summary>
    public class KitapEkleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public KitapEkleVM Kitap { get; set; }
    }
}
