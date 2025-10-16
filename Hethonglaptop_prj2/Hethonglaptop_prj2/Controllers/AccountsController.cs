using Hethonglaptop_prj2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Controllers
{
    public class AccountsController : Controller
    {
        private readonly Project2HthonglaptopvaphukienmaytinhContext _context;

        public AccountsController(Project2HthonglaptopvaphukienmaytinhContext context)
        {
            _context = context;
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,UserName,Password,Email,Role")] Account acc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acc);
                await _context.SaveChangesAsync();
                return View("~/Views/Admin/Index.cshtml");
            }
            return View(acc);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var acc = await _context.Accounts.FindAsync(id);
            if (acc == null) return NotFound();

            return View(acc);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,UserName,Password,Email,Role")] Account acc)
        {
            if (id != acc.AccountId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Accounts.Any(e => e.AccountId == acc.AccountId))
                        return NotFound();
                    else
                        throw;
                }
                return View("~/Views/Admin/Index.cshtml");
            }
            return View(acc);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var acc = await _context.Accounts
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (acc == null) return NotFound();

            return View(acc);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc != null)
            {
                _context.Accounts.Remove(acc);
                await _context.SaveChangesAsync();
            }
            return View("~/Views/Admin/Index.cshtml");
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
