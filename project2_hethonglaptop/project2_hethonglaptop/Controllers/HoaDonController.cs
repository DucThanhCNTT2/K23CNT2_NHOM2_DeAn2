using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project2_hethonglaptop.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDonController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: HoaDonController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HoaDonController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoaDonController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HoaDonController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HoaDonController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HoaDonController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HoaDonController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
