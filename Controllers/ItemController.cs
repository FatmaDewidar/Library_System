using Library_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Controllers
{
    public class ItemController : Controller
    {
        public ItemController(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;
        public IActionResult Index(string searchString)
        {

            IEnumerable<Item> itemsList = _context.Items.ToList();
            if (!String.IsNullOrEmpty(searchString)) {
                itemsList = itemsList.Where(n => n.ItemName.Contains(searchString)).ToList();
            }
            return View(itemsList);

          
        }

        public IActionResult Index1(string searchString)
        {

            IEnumerable<Item> itemsList = _context.Items.Include(u => u.Uom).ToList();
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    itemsList = itemsList.Where(n => n.ItemName.Contains(searchString)).ToList();
            //}
            return View(itemsList);


        }


        public IActionResult New()
        {
            createUomList();

            createCategoryList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }
        [HttpGet]
        public IActionResult Edit(int? ItemId)
        {
            createUomList();
            createCategoryList();
            if (ItemId == null || ItemId == 0)
            {
                return NotFound();

            }
            var item = _context.Items.Find(ItemId);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {

            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? ItemId)
        {
            createUomList();

            createCategoryList();
            if (ItemId == null || ItemId == 0)
            {
                return NotFound();

            }
            var item = _context.Items.Find(ItemId);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public void createCategoryList(int selectId = 1)
        {
            List<Category> categories = _context.Categories.ToList();
            SelectList ListItems = new SelectList(categories, "CategoryId", "CategoryName", selectId);
            ViewBag.categoryList = ListItems;

        }
        public void createUomList(int selectId = 1)
        {
            List<UnitOfMeasure> units = _context.UnitOfMeasures.ToList();
            SelectList ListItems = new SelectList(units, "UomId", "UomName", selectId);
            ViewBag.uomList = ListItems;

        }
    }
}
