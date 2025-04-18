using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore13GenericRepository.ViewModels.Eylemler
{
    public class EylemEklemeFormVM
    {
        public SelectList Kategoriler { get; set; }
        public SelectList Durumlar { get; set; }
        public EylemEklemeVM Eylem { get; set; }
    }
}
