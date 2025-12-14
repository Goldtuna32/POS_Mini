using System;
using System.Collections.Generic;

namespace POS.Database.AppDbContextModels;

public partial class ProductCategoryTable
{
    public int ProductCategoryId { get; set; }

    public string ProductCategoryCode { get; set; } = null!;

    public string ProductCategoryName { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
