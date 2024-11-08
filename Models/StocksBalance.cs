using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class StocksBalance
{
    public int StockId { get; set; }

    public string ItemId { get; set; } = null!;

    public DateTime BalanceDate { get; set; }

    public int Quantity { get; set; }

    public string? CreatedBy { get; set; }
}
