using Microsoft.AspNetCore.Mvc;
using project2_hethonglaptop.Models;

namespace project2_hethonglaptop.Controllers
{
    public class AdminController : Controller
    {
        private readonly Project2HthonglaptopvaphukienmaytinhContext _context;

        public AdminController(Project2HthonglaptopvaphukienmaytinhContext context)
        {
            _context = context;
        }

        // GET: /Admin/Create
        public IActionResult Create()
        {
            return View(); // Trả về form thêm sản phẩm
        }

        // Trang Dashboard Admin
        public IActionResult Index()
        {
            return View();
        }

        // Quản lý sản phẩm
        public IActionResult Products()
        {
            // Sau này có thể lấy danh sách sản phẩm từ DB để truyền vào View
            return View();
        }

        // Quản lý đơn hàng
        public IActionResult Orders()
        {
            // Sau này có thể lấy danh sách đơn hàng từ DB để truyền vào View
            return View();
        }

        // Quản lý người dùng
        public IActionResult Users()
        {
            // Sau này có thể lấy danh sách user từ DB để truyền vào View
            return View();
        }
    }
}
