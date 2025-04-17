using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore12GenericRepository.ViewModels.Kitaplar
{
    public class KitapEkleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Yazarlar { get; set; }
        public SelectList Yayinevleri { get; set; }
        public KitapEkleVM Kitap { get; set; }
    }
}
