﻿using Library_System.Models;

namespace Library_System.ViewModels
{
    public class TransactionViewModel
    {
        public Transaction transaction { get; set; }
        public List<TransactionsItem> transactionsItem { get; set; }

        //public int TransactionId { get; set; }

        //public int? TransactionTypeId { get; set; }

        //public DateTime? TransactionDate { get; set; }

        //public int? CustomerId { get; set; }

        //public int? CreatedBy { get; set; }

        //public virtual User? CreatedByNavigation { get; set; }

        //public virtual Customer? Customer { get; set; }

        //public virtual TransactionType? TransactionType { get; set; }
        //public List<TransactionsItem> TransactionItems { get; set; } = new List<TransactionsItem>();


        //public int ItemId { get; set; }

        //public double ItemPrice { get; set; }

        //public int ItemQuantity { get; set; }

        //public string? Notes { get; set; }

        //public virtual Item Item { get; set; } = null!;
    }
}
