using Library_System.Models;

namespace Library_System.ViewModels
{
    public class TransactionViewTransactionItems
    {
        public int TransactionId { get; set; }

        public int? TransactionTypeId { get; set; }

        public DateTime? TransactionDate { get; set; }

        public int? CustomerId { get; set; }

        public int? CreatedBy { get; set; }

        public virtual User? CreatedByNavigation { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual TransactionType? TransactionType { get; set; }
      

        public int ItemId { get; set; }

        public double ItemPrice { get; set; }

        public int ItemQuantity { get; set; }

        public string? Notes { get; set; }

        public virtual Item Item { get; set; } = null!;

        public virtual Transaction Transaction { get; set; } = null!;
    }
}