using MVCCore16ManyToManyDers.Models;

namespace MVCCore16ManyToManyDers.ViewModels
{
    public class KitapEkleFormVM
    {
        public Kitap Kitap { get; set; }
        public ICollection<YazarVM> Yazarlar { get; set; }
    }
}
