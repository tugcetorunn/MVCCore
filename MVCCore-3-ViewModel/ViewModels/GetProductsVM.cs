namespace MVCCore_3_ViewModel.ViewModels
{
    public class GetProductsVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string? CategoryName { get; set; }
    }
}
