using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore14ToDoDers.ViewModels.Eylemler
{
    public class EylemEklemeFormVM
    {
        public SelectList Kategoriler { get; set; } // selectlistler view özel bu yüzden katman olduğunda bunların burada olmaması gerekir?
        public EylemEkleVM Eylem { get; set; }
    }
}
