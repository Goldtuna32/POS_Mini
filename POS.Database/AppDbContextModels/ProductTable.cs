using System;
using System.Collections.Generic;

namespace POS.Database.AppDbContextModels;

public partial class ProductTable
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal ProductPrice { get; set; }

    public string ProductCategoryCode { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
