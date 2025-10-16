using System.Diagnostics;
using Hethonglaptop_prj2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Project2HthonglaptopvaphukienmaytinhContext _context;
        public HomeController(Project2HthonglaptopvaphukienmaytinhContext context)
        {
            _context = context;
        }
        private readonly ILogger<HomeController> _logger;
        public IActionResult Index()
        {
            var sanPhams = _context.SanPhams.ToList();  // lấy dữ liệu từ DB
            return View(sanPhams); // truyền sang View
        }

        public IActionResult Introduce()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ChiTiet(string id)
        {
            var sp = _context.SanPhams.FirstOrDefault(s => s.MaSp == id);
            if (sp == null) return NotFound();
            return View(sp);
        }
    }
}
