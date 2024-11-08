using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class UnitOfMeasure
{
    public int UomId { get; set; }

    public string UomName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
