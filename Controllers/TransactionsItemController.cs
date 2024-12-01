using Library_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_System.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library_System.Controllers
{
    public class TransactionsItemController : Controller
    {

        public TransactionsItemController(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;
        public IActionResult Index()
        {
            var TransactionsItem = _context.TransactionsItems
                .Include(t => t.Transaction)
                .Where(n => n.Transaction.TransactionTypeId == 1)
                .ToList();
            if (TransactionsItem == null)
            {
                return NotFound();
            }
            return View(TransactionsItem);
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
        public IActionResult New(int TransactionId, int TransactionTypeId, int CustomerId)
        {
            //int TransactionId, int ItemId, int CustomerId, int ItemPrice, int ItemQuantity, int transactionTypeId

            if (ModelState.IsValid)
            {
                var transaction = new Transaction
                {
                    TransactionId = TransactionId,
                    TransactionTypeId = TransactionTypeId,
                    CustomerId = CustomerId,
                };
                _context.Transactions.Add(transaction);
                _context.SaveChanges();

                /*var transactionsItem = new TransactionsItem
                {
                    ItemId = transactionsItem.ItemId,
                    TransactionId = model.TransactionId,
                    ItemPrice = model.ItemPrice,
                    ItemQuantity = model.ItemQuantity
                };
                _context.TransactionsItems.Add(transactionsItem);
                _context.SaveChanges();*/


                return RedirectToAction("Index");
            }


            return View();



        }
        public IActionResult NewOld(Transaction transaction, TransactionsItem transactionsItem)
        {
            //int TransactionId, int ItemId, int CustomerId, int ItemPrice, int ItemQuantity, int transactionTypeId

            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                _context.TransactionsItems.Add(transactionsItem);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(transaction);
            }
            /*var transaction = new Transaction 
            { TransactionId = TransactionId,
                CustomerId = CustomerId, 
                TransactionTypeId = transactionTypeId };
            _context.Transactions.Add(transaction);
            _context.SaveChanges(); */


            /*var transactionsItem = new TransactionsItem
                            {
                                ItemId = ItemId,
                                TransactionId = transaction.TransactionId,
                                ItemPrice = ItemPrice,
                                ItemQuantity = ItemQuantity
                            };
                            _context.TransactionsItems.Add(transactionsItem);
                            _context.SaveChanges();*/
            //  return RedirectToAction("Index");
        }
        /* public IActionResult Create()
         {
             return View(new TransactionViewModel());
         }


         [HttpPost]

         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create(TransactionViewModel model)
         {
             if (ModelState.IsValid)
             {
                 var transaction = new Transaction
                 {
                     TransactionId = model.TransactionId,
                     TransactionDate = DateTime.Now,
                     TransactionItems = model.TransactionItems.Select(i => new TransactionsItem
                     {
                         ItemId = i.ItemId,
                         ItemQuantity = i.ItemQuantity,
                         ItemPrice = i.ItemPrice
                     }).ToList()
                 };

                 _context.Transactions.Add(transaction);
                 await _context.SaveChangesAsync();
                 return RedirectToAction("Index");
             }

             return View(model);
         }*/


        public IActionResult Create()
        {

            var model = new TransactionViewModel
            {
                transaction = new Transaction(),

               // transactionsItem = new List<TransactionsItem> { new TransactionsItem(), new TransactionsItem(), new TransactionsItem() }  // Initially adding one empty order item

            };
            return View(model);
            //TransactionViewModel viewModel = new TransactionViewModel();
            //viewModel.TransactionItems = new List<TransactionsItem>();

            ////for a while we are generating rows from server side but good practice //is to genrate it from client side(JQuery/JavaScript)
            //TransactionsItem row1 = new TransactionsItem();
            //TransactionsItem row2 = new TransactionsItem();
            //TransactionsItem row3 = new TransactionsItem();

            //viewModel.TransactionDate = DateTime.Now;
            //viewModel.TransactionItems.Add(row1);
            //viewModel.TransactionItems.Add(row2);
            //viewModel.TransactionItems.Add(row3);
           // return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionViewModel transactionViewModel)
        {
            //ModelState.Remove("transactionsItem");
            if (ModelState.IsValid)
            {
                transactionViewModel.transaction.TransactionTypeId = 1;
                _context.Transactions.Add(transactionViewModel.transaction);
                await _context.SaveChangesAsync();

                foreach (var item in transactionViewModel.transactionsItem)
                {

                    item.TransactionId = transactionViewModel.transaction.TransactionId;
                    _context.TransactionsItems.Add(item);
                    //var transactionItems = new TransactionsItem()
                    //{
                    //    TransactionId = i.TransactionId,
                    //    ItemId = i.ItemId,
                    //    ItemQuantity = i.ItemQuantity,
                    //    ItemPrice= i.ItemPrice,
                    //};


                    //_context.TransactionsItems.Add(transactionItems);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "TransactionsItem");
            }
            return View(transactionViewModel);

        }

    
    //
    }



    }
