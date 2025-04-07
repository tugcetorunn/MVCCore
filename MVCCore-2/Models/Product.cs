namespace MVCCore_2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Category? Category { get; set; } // nav prop olmasaydı uzun uzun join ler yazmamız gerekirdi.
        public int? CategoryId { get; set; } // ürün işlemi yaparken (ekleme vs.) category yi girebilmek için bunu vermemiz gerek. 

    }
}