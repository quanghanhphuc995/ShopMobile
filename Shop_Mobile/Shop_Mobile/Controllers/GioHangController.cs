using Microsoft.AspNet.Identity;
using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Controllers
{
    [Authorize]
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<GioHangViewModel> gioHangDetails = null;
            if (User.Identity.IsAuthenticated)
            {
                gioHangDetails = GioHangBUS.ChiTietGioHang(userId);
               
            }
            return View(gioHangDetails);
        }
        [HttpPost]
        public ActionResult ThemVaoGioHang(string maSanPham, GioHang gioHangItem)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                GioHangBUS.TaoMoiVaThemVaoGioHang(userId, maSanPham, gioHangItem);
                var GioHangDetails = GioHangBUS.ChiTietGioHang(userId);
                AccountController accountController = new AccountController();
                int carItemCount = accountController.GetCartItemCount(userId);
                Session["CartItemCount"] = carItemCount;

                if (GioHangDetails.Any())
                {
                    
                    ViewBag.UserId = userId;
                    return View("Index",GioHangDetails); // Chuyển hướng đến action Index của controller GioHang

                }
                else
                {
                    return View("Error");
                }

            }
            else
            {
              return RedirectToAction("Login", "Account");
            }
           
        }

        [HttpPost]
        public ActionResult CapNhat(GioHang gioHangItem)
        {
            string userId = User.Identity.GetUserId();
            GioHangBUS.SanPhamUpdate(userId, gioHangItem);
            AccountController accountController = new AccountController();
            int carItemCount = accountController.GetCartItemCount(userId);
            Session["CartItemCount"] = carItemCount;
            return RedirectToAction("Index", "GioHang");
        }
        [HttpPost]
        public JsonResult XoaGioHang(GioHang gioHangItem)
        {
            string userId = User.Identity.GetUserId();
            GioHangBUS.XoaSanPhamGH(userId, gioHangItem);
            var GioHangDetails = GioHangBUS.ChiTietGioHang(userId);
            return Json(new { success = true });
           
        }
        public ActionResult DeleteAllGH()
        {
            string userId = User.Identity.GetUserId();
            GioHangBUS.XoaTatCaGH(userId);
            return Json(new { success = true });

        }
    }
}