using System;
using System.Collections.Generic;

namespace MVCCore_3_ViewModel.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
