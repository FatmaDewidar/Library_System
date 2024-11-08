using Library_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    public class StockController : Controller
    {
        public StockController(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;
        public IActionResult Index(string searchString)
        {
            IEnumerable<Stock> stockList = _context.Stocks.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                stockList = stockList.Where(n => n.StockName.Contains(searchString)).ToList();
            }
            return View(stockList);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Stocks.Add(stock);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(stock);
            }
        }
        public IActionResult Edit(int? StockId)
        {
            if (StockId == null || StockId == 0)
            {
                return NotFound();

            }
            var stock = _context.Stocks.Find(StockId);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stock stock)
        {

            if (ModelState.IsValid)
            {
                _context.Stocks.Update(stock);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(stock);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? StockId)
        {
            if (StockId == null || StockId == 0)
            {
                return NotFound();

            }
            var stock = _context.Stocks.Find(StockId);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Stock stock)
        {
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
