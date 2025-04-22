using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore15ManyToMany.ViewModels.Kitap
{
    public class KitapGuncelleFormVM
    {
        public SelectList Yazarlar { get; set; }
        public KitapGuncelleVM Kitap { get; set; }
    }
}
