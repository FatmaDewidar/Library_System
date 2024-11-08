using Library_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Library_System.Controllers
{
    public class TransactionController : Controller
    {
        public TransactionController(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;
        public IActionResult Index(string searchString, int TransactionTypeId)
        {

            /*  IEnumerable<Transaction> TransactionList = _context.Transactions.ToList();
                  if (!String.IsNullOrEmpty(searchString))
                  {
                      TransactionList = TransactionList.Where(n => n.TransactionId.Equals(searchString)).ToList();
                  }
              return View(TransactionList);*/
            var transaction = _context.Transactions.Where(n => n.TransactionTypeId == 1);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }
        public IActionResult Details()
        {
            var transaction = _context.Transactions.Where(n => n.TransactionTypeId == 1);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(transaction);
            }

        }
    }
}
