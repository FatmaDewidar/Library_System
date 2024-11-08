using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class TransactionType
{
    public int TransactionTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
