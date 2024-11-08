using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public string StockName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }
}
