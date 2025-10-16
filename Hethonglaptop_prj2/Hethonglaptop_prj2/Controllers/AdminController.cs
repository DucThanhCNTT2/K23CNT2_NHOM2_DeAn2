using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hethonglaptop_prj2.Models;
using Hethonglaptop_prj2.Models.ViewModels;

namespace Hethonglaptop_prj2.Controllers
{
    public class AdminController : Controller
    {
        private readonly Project2HthonglaptopvaphukienmaytinhContext _context;

        public AdminController(Project2HthonglaptopvaphukienmaytinhContext context)
        {
            _context = context;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            var vm = new AdminIndexViewModel
            {
                SanPhams = _context.SanPhams.ToList(),
                KhachHangs = _context.KhachHangs.ToList(),
                NhanViens = _context.NhanViens.ToList(),
                HoaDons = _context.HoaDons.ToList(),
                Accounts = _context.Accounts.ToList()
            };
            var role = HttpContext.Session.GetString("Role");
            if (role == null || !role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // Nếu không phải admin thì chuyển về Login
                return RedirectToAction("Login", "Account");
            }

            return View(vm);
        }
        
        //quản lý sản phẩm
        public IActionResult DanhSachSanPham()
        {
            var sanPhams = _context.SanPhams.ToList();
            return PartialView("_DanhSachSanPham", sanPhams);
        }

        // Quản lý đơn hàng
        public IActionResult DanhSachDonHang()
        {
            var donHangs = _context.HoaDons.ToList();
            return PartialView("_DanhSachDonHang", donHangs);
        }

        // Quản lý khách hàng
        public IActionResult DanhSachKhachHang()
        {
            var khachHangs = _context.KhachHangs.ToList();
            return PartialView("_DanhSachKhachHang", khachHangs);
        }

        // Quản lý nhân viên
        public IActionResult DanhSachNhanVien()
        {
            var nhanViens = _context.NhanViens.ToList();
            return PartialView("_DanhSachNhanVien", nhanViens);
        }

        // Quản lý account
        public IActionResult DanhSachAccount()
        {
            var accounts = _context.Accounts.ToList();
            return PartialView("_DanhSachAccount", accounts);
        }

    }
}
