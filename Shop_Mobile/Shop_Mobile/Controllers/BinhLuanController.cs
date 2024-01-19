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
            string userName = User.Identity.GetUserName();
            ViewBag.userID = userId;
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }
            else
            {
                BinhLuanBUS.AddBinhLuan(maSanPham, userId, noiDung, userName);
                var noiDungBL = BinhLuanBUS.GetBinhLuanWithUserName(userId);
                return PartialView("_BinhLuan", noiDungBL);            }
            
        }

        [HttpGet]
        public ActionResult GetAllBinhLuan(string maSanPham)
        {
            var db = BinhLuanBUS.GetTatCaBinhLuan(maSanPham);
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
        public ActionResult PhanHoiBL(int binhLuanID, string noiDungPhanHoi)
        {
            string userId = User.Identity.GetUserId();
            string userName = User.Identity.GetUserName();
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, redirectTo = Url.Action("Login", "Account") });
            }
            else
            {
                BinhLuanBUS.AddPhanHoiBL(binhLuanID, noiDungPhanHoi, userId, userName);
                return Json(new { success = true, message = "Phản hồi đã được gửi thành công." });
               
            }
            
        }

        [HttpGet]
        public ActionResult GetAllPhanHoiBL(int binhLuanID)
        {
            var db = BinhLuanBUS.GetTatCaPhanHoiBL(binhLuanID);
            return PartialView("_GetAllPhanHoiBL", db);
        }
    }
}