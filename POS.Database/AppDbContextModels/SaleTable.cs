using System;
using System.Collections.Generic;

namespace POS.Database.AppDbContextModels;

public partial class SaleTable
{
    public int SaleId { get; set; }

    public string SaleVoucherNo { get; set; } = null!;

    public string SaleDate { get; set; } = null!;

    public string TotalAmount { get; set; } = null!;
}
