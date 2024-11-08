using Library_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    public class SupplierController : Controller
    {
        public SupplierController(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;
        public IActionResult Index(string searchString)
        {
            IEnumerable<Supplier> supplierList = _context.Suppliers.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                supplierList = supplierList.Where(n => n.SupplierName.Contains(searchString)).ToList();
            }
            return View(supplierList);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }
        public IActionResult Edit(int? SupplierId)
        {
            if (SupplierId == null || SupplierId == 0)
            {
                return NotFound();

            }
            var supplier = _context.Suppliers.Find(SupplierId);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier supplier)
        {

            if (ModelState.IsValid)
            {
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? SupplierId)
        {
            if (SupplierId == null || SupplierId == 0)
            {
                return NotFound();

            }
            var supplier = _context.Suppliers.Find(SupplierId);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
