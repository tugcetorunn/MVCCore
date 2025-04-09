namespace MVCCore_3_ViewModel.ViewModels
{
    public class UpdateProductVM
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; } = null!;

        public int? CategoryId { get; set; }
    }
}
