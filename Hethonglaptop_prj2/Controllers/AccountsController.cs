using Hethonglaptop_prj2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hethonglaptop_prj2.Controllers
{
    public class AccountsController : Controller
    {
        private readonly Project2HthonglaptopvaphukienmaytinhContext _context;

        public AccountsController(Project2HthonglaptopvaphukienmaytinhContext context)
        {
            _context = context;
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                // kiểm tra trùng username
                if (_context.Accounts.Any(a => a.UserName == acc.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                    return View(acc);
                }

                _context.Add(acc);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(acc);
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.UserName == username && a.Password == password);
            if (acc != null)
            {
                // Lưu Session
                HttpContext.Session.SetString("UserName", acc.UserName);
                HttpContext.Session.SetString("Role", acc.Role ?? "User");

                // Nếu là Admin thì chuyển đến trang Admin
                if (acc.Role != null && acc.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
