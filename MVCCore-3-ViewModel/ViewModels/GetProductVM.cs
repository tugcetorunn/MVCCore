namespace MVCCore_3_ViewModel.ViewModels
{
    public class GetProductVM
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string? CategoryName { get; set; }
    }
}
