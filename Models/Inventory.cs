using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public string ItemId { get; set; } = null!;

    public int Quantity { get; set; }

    public string? StockLocation { get; set; }

    public DateTime? LastUpdated { get; set; }

    public int StockId { get; set; }

    public string? CreatedBy { get; set; }
}
