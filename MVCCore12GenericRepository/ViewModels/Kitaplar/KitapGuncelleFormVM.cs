using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore12GenericRepository.ViewModels.Kitaplar
{
    public class KitapGuncelleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Yazarlar { get; set; }
        public SelectList Yayinevleri { get; set; }
        public KitapGuncelleVM Kitap { get; set; }
    }
}
