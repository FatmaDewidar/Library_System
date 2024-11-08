using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class TransactionsItem
{
    public int TransactionId { get; set; }

    public int ItemId { get; set; }

    public double ItemPrice { get; set; }

    public int ItemQuantity { get; set; }

    public string? Notes { get; set; }

    public virtual Transaction Transaction { get; set; } = null!;
}
