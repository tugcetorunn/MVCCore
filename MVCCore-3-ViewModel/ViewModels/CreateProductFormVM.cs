using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore_3_ViewModel.ViewModels
{
    public class CreateProductFormVM
    {
        public SelectList Categories { get; set; }
        public CreateProductVM Product { get; set; }
    }
}
