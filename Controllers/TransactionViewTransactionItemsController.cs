using Microsoft.AspNetCore.Mvc;
using Library_System.Models; 
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Library_System.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_System.Controllers
{
    public class TransactionViewTransactionItemsController : Controller

    {
        public TransactionViewTransactionItemsController(LibraryContext context)
        {
            _context = context;
        }
        private readonly LibraryContext _context;
        public IActionResult Index(string searchString)
        {  

            using (var context = new LibraryContext())
            {
                IEnumerable<Transaction> TransactionList = _context.Transactions.ToList();

                var transactionWithTransactionItems = (from Transaction in _context.Transactions
                                                       join TransactionsItem
                                                       in _context.TransactionsItems on Transaction.TransactionId equals TransactionsItem.TransactionId
                                                       select new TransactionViewTransactionItems
                                                       {
                                                           TransactionId = Transaction.TransactionId,
                                                           TransactionDate = Transaction.TransactionDate,
                                                           ItemPrice = TransactionsItem.ItemPrice,
                                                           CustomerId=Transaction.CustomerId,
                                                           ItemQuantity=TransactionsItem.ItemQuantity,


                                                       }).ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    transactionWithTransactionItems = transactionWithTransactionItems.Where(n => n.TransactionId.Equals(searchString)).ToList();
                   
                }


                return View(transactionWithTransactionItems);
            }
            
        }
        public IActionResult New()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(int TransactionId, int ItemId,int CustomerId,int ItemPrice,int ItemQuantity,int transactionTypeId)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction{TransactionId = TransactionId,CustomerId= CustomerId ,TransactionTypeId= transactionTypeId };
                _context.Transactions.Add(transaction);
                _context.SaveChanges(); // Save to get the ID

              
                var transactionsItem = new TransactionsItem { ItemId =ItemId,
                    TransactionId =transaction.TransactionId ,ItemPrice= ItemPrice,ItemQuantity = ItemQuantity };
                _context.TransactionsItems.Add(transactionsItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           
            {
                return View();
            }
        }

        public IActionResult Details()
        {

            


                return View();
            }

        }




    
}


