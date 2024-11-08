using Library_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;
        public IActionResult Index(string searchString)
        {
            IEnumerable<Customer> customerList = _context.Customers.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                customerList = customerList.Where(n => n.CustomerName.Contains(searchString)).ToList();
            }
            return View(customerList);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
        }
        public IActionResult Edit(int? CustomerId)
        {
            if (CustomerId == null || CustomerId == 0)
            {
                return NotFound();

            }
            var customer = _context.Customers.Find(CustomerId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? CustomerId)
        {
            if (CustomerId == null || CustomerId == 0)
            {
                return NotFound();

            }
            var customer = _context.Customers.Find(CustomerId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
