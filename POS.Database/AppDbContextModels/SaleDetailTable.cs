using System;
using System.Collections.Generic;

namespace POS.Database.AppDbContextModels;

public partial class SaleDetailTable
{
    public int SaleDetailId { get; set; }

    public string VoucherNo { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public string Price { get; set; } = null!;
}
