using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore15ManyToMany.ViewModels.Kitap
{
    public class KitapEkleFormVM
    {
        public SelectList Yazarlar { get; set; }
        public KitapEkleVM Kitap { get; set; }
    }
}
