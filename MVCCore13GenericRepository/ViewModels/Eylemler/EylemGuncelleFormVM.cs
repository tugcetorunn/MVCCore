using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore13GenericRepository.ViewModels.Eylemler
{
    public class EylemGuncelleFormVM
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Durumlar { get; set; }
        public EylemGuncelleVM Eylem { get; set; }
    }
}
