using Hethonglaptop_prj2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Hethonglaptop_prj2.Helpers;
using Newtonsoft.Json;


namespace Hethonglaptop_prj2.Controllers
{
    public class CartsController : Controller
    {
        private readonly Project2HthonglaptopvaphukienmaytinhContext _context;

        public CartsController(Project2HthonglaptopvaphukienmaytinhContext context)
        {
            _context = context;
        }

        // Lấy giỏ hàng từ Session
        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cart))
            {
                return new List<CartItem>();
            }
            return JsonConvert.DeserializeObject<List<CartItem>>(cart);
        }

        // Lưu giỏ hàng vào Session
        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }

        // Thêm vào giỏ hàng
        public IActionResult Add(string id)
        {
            var sp = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == id);
            if (sp == null) return NotFound();

            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.MaSP == sp.MaSp);

            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    MaSP = sp.MaSp,
                    TenSP = sp.TenSp,
                    Gia = sp.Gia,
                    Anh = sp.Anh,
                    SoLuong = 1
                });
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        // Hiển thị giỏ hàng
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        // Xóa sản phẩm khỏi giỏ
        public IActionResult Remove(string id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.MaSP == id);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        // 🧩 Hàm tự động sinh mã hóa đơn (HDxx)
        private string GenerateMaHD()
        {
            var last = _context.HoaDons
                .OrderByDescending(h => h.MaHd)
                .Select(h => h.MaHd)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(last))
                return "HD01";

            string numberPart = last.Substring(2);
            int number = int.Parse(numberPart) + 1;

            return "HD" + number.ToString("D2"); // HD01, HD02,...
        }

        // Thanh toán
        public IActionResult Checkout()
        {
            var cart = Helpers.SessionExtensions.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            if (cart == null || !cart.Any())
            {
                ViewBag.Message = "Giỏ hàng của bạn đang trống!";
                return View("Index");
            }

            // 🧩 Sinh mã hóa đơn tự động
            string maHD = GenerateMaHD();

            // Tính tổng tiền
            decimal tongTien = cart.Sum(i => i.Gia * i.SoLuong);

            // Tạo hóa đơn mới
            var hoaDon = new HoaDon
            {
                MaHd = maHD,
                NgayLap = DateOnly.FromDateTime(DateTime.Now),
                TongTien = tongTien,
                MaKh = "KH01", // ✅
            };
            _context.HoaDons.Add(hoaDon);
            _context.SaveChanges();

            // Thêm chi tiết hóa đơn
            foreach (var item in cart)
            {
                var ct = new CthoaDon
                {
                    MaHd = maHD,
                    MaSp = item.MaSP,
                    SoLuong = item.SoLuong,
                    DonGia = item.Gia
                };
                _context.CthoaDons.Add(ct);
            }

            _context.SaveChanges();

            // Xóa giỏ hàng sau thanh toán
            HttpContext.Session.Remove("Cart");

            ViewBag.Message = "Thanh toán thành công!";
            return View("Success");
        }
        // Trang cảm ơn
        public IActionResult Success()
        {
            return View();
        }

    }
}
