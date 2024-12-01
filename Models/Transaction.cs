using System;
using System.Collections.Generic;

namespace Library_System.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? TransactionTypeId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? CustomerId { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual TransactionType? TransactionType { get; set; }

    public virtual ICollection<TransactionsItem>? TransactionsItems { get; set; } 
}
