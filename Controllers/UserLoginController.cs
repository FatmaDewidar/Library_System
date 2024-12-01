using Library_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Controllers
{
    public class UserLoginController : Controller
    {
        public UserLoginController(LibraryContext context)
        {
            _context = context;
        }
        private readonly LibraryContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        // معالجة تسجيل الدخول
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // البحث عن المستخدم في قاعدة البيانات
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

           if (user != null)
             {
                 // تسجيل الدخول الناجح
                 TempData["Message"] = "تم تسجيل الدخول بنجاح!";
                 return RedirectToAction("Index", "Home"); // إعادة التوجيه للصفحة الرئيسية
             }
            
            else
            {
                // تسجيل الدخول الفاشل
                ViewBag.Error = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                return View();
            }
        }
    }
}
