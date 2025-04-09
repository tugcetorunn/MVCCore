using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore_5_Uygulama.Models;

namespace MVCCore_5_Uygulama.ViewModels
{
    public class KitapEkleFormVM
    {
        public KitapEkleVM Kitap { get; set; }
        public SelectList Yazarlar { get; set; }
        public SelectList Yayinevleri { get; set; }
        public SelectList Kategoriler { get; set; }
    }
}
