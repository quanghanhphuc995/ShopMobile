using Microsoft.AspNet.Identity;
using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Areas.Admin.Controllers
{
    public class HoaDonAdminController : Controller
    {
        // GET: Admin/HoaDonAdmin
        public ActionResult Index()
        {
            
            var db = HoaDonBUS.GetHoaDonAdmin();
            return View(db);
        }
        public ActionResult ChiTieHoaDonAdmin(HoaDon hD)
        {
            var db = HoaDonBUS.DanhSachGH(hD);
            return View(db);
        }

        public ActionResult SoLuongSauKhiXL(string maSanPhams)
        {
            HoaDonBUS.UpdateSoLuongSanPham(maSanPhams);
            return RedirectToAction("Index");
        }
    }
}