using Microsoft.AspNet.Identity;
using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Controllers
{
    public class BinhLuanController : Controller
    {
        // GET: BinhLuan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string maSanPham, string noiDung)
        {
            string userId = User.Identity.GetUserId();
            ViewBag.userID = userId;
            if (User.Identity.IsAuthenticated)
            {
                 BinhLuanBUS.AddBinhLuan(maSanPham, userId, noiDung);
                var noiDungBL = BinhLuanBUS.GetBinhLuan(userId);
                return PartialView("_BinhLuan", noiDungBL );
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        [HttpGet]
        public ActionResult GetAllBinhLuan()
        {
            var db = BinhLuanBUS.GetTatCaBinhLuan();
            return PartialView("_GetAllBinhLuan", db);
        }

        [HttpPost]
        public ActionResult LuotLike(int binhluanID)
        {
            bool result = BinhLuanBUS.TangLuotLike(binhluanID);
            if (result)
            {
                var binhluan = BinhLuanBUS.FindById(binhluanID); // Giả định có phương thức FindById
                return Json(new { success = true, newLikeCount = binhluan.LuotLike });
            }
            else
            {
                return Json(new { success = false, message = "Không tìm thấy bình luận" });
            }
        }
        [HttpPost]
        public ActionResult PhanHoiBL(int binhLuanID, string noidungPhanHoi, string userId)
        {
            BinhLuanBUS.AddPhanHoiBL(binhLuanID,noidungPhanHoi, userId);
            return Json(new { success = true, message = "Phản hồi đã được gửi thành công." });
        }
    }
}