using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Areas.Admin.Controllers
{
    [Authorize]
    public class RamHDHBNTController : Controller
    {
        public class ViewModel
        {
            public IEnumerable<HeDieuHanh> DanhSachHDH { get; set; }
            public IEnumerable<BoNhoTrong> DanhSachBNT { get; set; }
            public IEnumerable<Ram> DanhSachRam { get; set; }
        }
        
        public ActionResult Index()
        {
            ViewModel vieModel = new ViewModel
            {
                DanhSachHDH = ShopOnlineBUS.DanhSachHDH(),
                DanhSachBNT = ShopOnlineBUS.DanhSachBNT(),
                DanhSachRam = ShopOnlineBUS.DanhSachRam()
            };
            
            return View(vieModel);
        }
        //--------------------------Phan He Dieu Hanh------------------------
        public ActionResult CreateHDH()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHDH(HeDieuHanh hdh)
        {
            ShopOnlineBUS.ThemHDH(hdh);
            return RedirectToAction("Index");
        }

        public ActionResult EditHDH(String id)
        {
            var db = ShopOnlineBUS.ChiTietHDH(id);
            return View(db);
        }

        
        [HttpPost]
        public ActionResult EditHDH(String id, HeDieuHanh hdh)
        {
            try
            {
                
                ShopOnlineBUS.UpadateHDH(id, hdh);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult DeleteHDH(string maHeDieuHanh)
        {
            ShopOnlineBUS.XoaHDH(maHeDieuHanh);
            return Json(new { success = true });
        }

        //--------------------------Phan Bo Nho trong------------------------
        public ActionResult CreateBNT()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBNT(BoNhoTrong bnt) 
        {
            ShopOnlineBUS.ThemBNT(bnt);
            return RedirectToAction("Index");
        }

        public ActionResult EditBNT(string maBoNhoTrong)
        {
            var db = ShopOnlineBUS.ChiTietBNT(maBoNhoTrong);
            return View(db);
        }
        [HttpPost]
        public ActionResult EditBNT(string maBoNhoTrong, BoNhoTrong bnt)
        {
            ShopOnlineBUS.UpdateBNT(maBoNhoTrong, bnt);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBNT(String maBoNhoTrong)
        {
            ShopOnlineBUS.XoaBNT(maBoNhoTrong);
            return Json(new { success = true });
        }

        //--------------------------Phan Ram------------------------

        public ActionResult CreateRam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRam(Ram ram)
        {
            ShopOnlineBUS.ThemRam(ram);
            return RedirectToAction("Index");
        }
        public ActionResult EditRam(string maRam)
        {
            var db = ShopOnlineBUS.ChiTietRam(maRam);
            return View(db);
        }
        [HttpPost]
        public ActionResult EditRam(string maRam, Ram ram)
        {
            ShopOnlineBUS.UpdateRam(maRam, ram);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRam(String maRam)
        {
            ShopOnlineBUS.XoaRam(maRam);
            return Json(new { success = true });
        }
    }
}


