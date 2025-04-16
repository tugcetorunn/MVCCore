using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore9ManuelIdentity.ViewModels.Ürünler
{
    public class UrunEkleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public UrunEkleVM Urun { get; set; }
    }
}
