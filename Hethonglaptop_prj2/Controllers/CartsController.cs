using Hethonglaptop_prj2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Hethonglaptop_prj2.Helpers;


namespace Hethonglaptop_prj2.Controllers
{
    public class CartsController : Controller
    {
        private readonly Project2HthonglaptopvaphukienmaytinhContext _context;

        public CartsController(Project2HthonglaptopvaphukienmaytinhContext context)
        {
            _context = context;
        }

        // Xem giỏ hàng
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<SanPham>>("Cart") ?? new List<SanPham>();
            return View(cart);
        }

        // Thêm vào giỏ
        public IActionResult AddToCart(string id)
        {
            var sp = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == id);
            if (sp == null) return NotFound();

            var cart = HttpContext.Session.GetObjectFromJson<List<SanPham>>("Cart") ?? new List<SanPham>();

            var existing = cart.FirstOrDefault(x => x.MaSp == id);
            if (existing != null)
            {
                existing.SoLuong += 1;  // số nguyên
            }
            else
            {
                sp.SoLuong = 1;  // số nguyên
                cart.Add(sp);
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }
        

        // Xóa sản phẩm
        public IActionResult RemoveFromCart(string id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<SanPham>>("Cart");
            if (cart != null)
            {
                var item = cart.FirstOrDefault(x => x.MaSp == id);
                if (item != null) cart.Remove(item);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}
