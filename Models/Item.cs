using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public int? MinItemQuantity { get; set; }

    public int? MaxItemQuantity { get; set; }

    public string? ItemImage { get; set; }

    public double? ItemPrice { get; set; }

    public int? UomId { get; set; }

    public virtual UnitOfMeasure? Uom { get; set; }
}
