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
            TransactionViewModel viewModel = new TransactionViewModel();
            viewModel.TransactionItems = new List<TransactionsItem>();

            //for a while we are generating rows from server side but good practice //is to genrate it from client side(JQuery/JavaScript)
            TransactionsItem row1 = new TransactionsItem();
            TransactionsItem row2 = new TransactionsItem();
            TransactionsItem row3 = new TransactionsItem();

            viewModel.TransactionDate = DateTime.Now;
            viewModel.TransactionItems.Add(row1);
            viewModel.TransactionItems.Add(row2);
            viewModel.TransactionItems.Add(row3);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionViewModel transactionViewModel)
        {
            if (ModelState.IsValid)
            {
                var Transaction = new Transaction()
                {
                    TransactionId = transactionViewModel.TransactionId,
                    TransactionTypeId = transactionViewModel.TransactionTypeId,
                    TransactionDate = transactionViewModel.TransactionDate,
                    CustomerId = transactionViewModel.CustomerId
                };


                _context.Transactions.Add(Transaction);
                await _context.SaveChangesAsync();

                foreach (var i in transactionViewModel.TransactionItems)
                {
                    var transactionItems = new TransactionsItem()
                    {
                        TransactionId = i.TransactionId,
                        ItemId = i.ItemId,
                        ItemQuantity = i.ItemQuantity,
                        ItemPrice= i.ItemPrice,
                    };


                    _context.TransactionsItems.Add(transactionItems);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(transactionViewModel);

        }

        public IActionResult Add(List<TransactionViewModel> transactionVM, List<TransactionViewModel> transactionsItemVM)
        {
            if (transactionVM.Select(x => x.TransactionId).FirstOrDefault() == 0)
            { }
            else
            {

            }

            {
                var ifExistBillForCardId = (from b in _context.Transactions
                                            where

                                            b.TransactionId == transactionVM.Select(x => x.TransactionId).FirstOrDefault()
                                            && b.TransactionDate != null
                                            && (b.TransactionType == null)
                                            select b).ToList();
                if (transactionVM.Select(x => x.TransactionId).FirstOrDefault() == 0)
                { return Json("يجب اختيار العميل"); }
                else if (transactionVM.Select(x => x.CustomerId).FirstOrDefault() == 0)
                { return Json("يجب اختيار السياره "); }
                else if (Convert.ToDateTime(transactionVM.Select(x => x.TransactionDate).FirstOrDefault()) ==DateTime.Now )
                { return Json("يجب اختيار تاريخ الفاتوره"); }
                else if (transactionVM.Select(x => x.ItemPrice).FirstOrDefault() == 0)
                { return Json("يجب ادخال اجمالي الفاتوره"); }

                else if (transactionVM.Select(x => x.TransactionTypeId).FirstOrDefault() == 0)
                { return Json("يجب اختيار طريقة الدفع "); }



                else
                {

                    Transaction TransactionModel = new Transaction();
                    TransactionsItem transactionsItemModel = new TransactionsItem();
                    //Transactions_transItem Transactions_transItemModel = new Transactions_transItem();
                    TransactionModel.TransactionId = transactionVM.Select(x => x.TransactionId).FirstOrDefault();
                    TransactionModel.TransactionDate = transactionVM.Select(x => x.TransactionDate).FirstOrDefault();
                    TransactionModel.CustomerId = transactionVM.Select(x => x.CustomerId).FirstOrDefault();

                    if (_context.Transactions.Count() == 0)
                        TransactionModel.TransactionId = 1;
                    else
                    {
                        TransactionModel.TransactionId = _context.Transactions.Max(x => x.TransactionId) + 1;
                    }
                    TransactionModel.TransactionDate = DateTime.Now;
                    // TransactionModel.InsertedBy = Program.userID;
                    // TransactionModel.Isdeleted = false;
                    _context.Transactions.Add(TransactionModel);
                    _context.SaveChanges();
                    TransactionsItem TransItemModel = new TransactionsItem();
                    //billdetails add
                    foreach (TransactionViewModel item in transactionVM)
                    {
                        TransItemModel.TransactionId = _context.Transactions.Max(x => x.TransactionId);
                        TransItemModel.ItemId = item.ItemId;
                        TransItemModel.ItemPrice = item.ItemPrice;
                        TransItemModel.ItemQuantity = item.ItemQuantity;

                        //TransItemModel.ItemPrice = _context.Items.Where(x => x.ItemId == item.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                        //inventory reuce amount
                        //  invProModel = _Context.Inventoryproducts.Where(x => x.InventoryId == item.InventoryId && x.ProductId == item.ProductId).FirstOrDefault();

                        _context.TransactionsItems.Add(TransItemModel);
                        _context.SaveChanges();
                        TransItemModel = new TransactionsItem();



                    }
                    //add operation
                    foreach (TransactionViewModel item in transactionsItemVM)
                    {
                        if (item.TransactionId == 0 || item.TransactionId == null)
                        { }
                        else
                        {
                            transactionsItemModel.TransactionId = _context.Transactions.Max(x => x.TransactionId);
                            transactionsItemModel.ItemId = item.ItemId;
                            transactionsItemModel.ItemPrice = item.ItemPrice;
                            transactionsItemModel.ItemQuantity = item.ItemQuantity;
                            _context.TransactionsItems.Add(transactionsItemModel);
                            _context.SaveChanges();
                            transactionsItemModel = new TransactionsItem();
                        }
                       
                    }
                    return Json("PrintInvoice?BillId=");

                }

            }

        

        }
    }



    }
