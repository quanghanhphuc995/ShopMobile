using Shop_Mobile.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Areas.Admin.Controllers
{
    public class QuanLyTaiKhoanKhachHangController : Controller
    {
        // GET: Admin/QuanLyTaiKhoanKhachHang
        public ActionResult Index()
        {
            var db = DataBUS.QuanLyTK();
            return View(db);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            DataBUS.XoaTKKhachHang(id);
            return Json(new { success = true });
        }
    }
}