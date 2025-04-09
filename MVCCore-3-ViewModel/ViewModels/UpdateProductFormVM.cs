using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore_3_ViewModel.ViewModels
{
    public class UpdateProductFormVM
    {
        public SelectList Categories { get; set; }
        public UpdateProductVM Product { get; set; }
    }
}
