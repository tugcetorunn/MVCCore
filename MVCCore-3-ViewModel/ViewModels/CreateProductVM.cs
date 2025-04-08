namespace MVCCore_3_ViewModel.ViewModels
{
    public class CreateProductVM
    {
        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public IFormFile ImageUrl { get; set; } = null!;

        public int? CategoryId { get; set; }
    }
}
