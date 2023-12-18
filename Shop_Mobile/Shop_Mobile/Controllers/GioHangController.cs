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
            
            return View();
        }
        [HttpPost]
        public ActionResult HienThiThongTinSanPham(string maSanPham, GioHang gioHangItem)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                var dbGetCart = GioHangBUS.GetCartItem(maSanPham, userId);
                int tongSoLuong = GioHangBUS.TinhTongSoLuongGioHang(userId);
                ViewBag.TongSoLuong = tongSoLuong;
                if (dbGetCart == null)
                {
                    GioHangBUS.AddOrUpdateCartItem(gioHangItem, userId);
                }

                var gioHangDetails = GioHangBUS.GetGioHangDetails(userId);
                if (gioHangDetails!=null)
                {
                    var gioHangViewModels = gioHangDetails.Select(g => new GioHangViewModel
                    {
                        IdGH = g.IdGH,
                        UserID = g.UserID,
                        MaSanPham = g.MaSanPham,
                        SoLuong = g.SoLuong,
                        TongTien = g.TongTien,
                        MaLoaiSanPham = g.MaLoaiSanPham,
                        MaNhaSanXuat = g.MaNhaSanXuat,
                        TenSanPham = g.TenSanPham,
                        CauHinh = g.CauHinh,
                        HinhChinh = g.HinhChinh,
                        Hinh1 = g.Hinh1,
                        Hinh2 = g.Hinh2,
                        Hinh3 = g.Hinh3,
                        Hinh4 = g.Hinh4,
                        Gia = g.Gia,
                        SoLuongDaBan = g.SoLuongDaBan,
                        LuotView = g.LuotView,
                        TinhTrang = g.TinhTrang,
                        GhiChu = g.GhiChu
                    });

                    ViewBag.UserId = userId;
                    return View(gioHangViewModels); // Chuyển hướng đến action Index của controller GioHang

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
            Debug.WriteLine($"AddOrUpdateCartItem - UserID: {userId}");
            // Gọi phương thức CapNhat từ GioHangBUS
            GioHangBUS.CapNhat(gioHangItem, userId);
           

            // Tính tổng số lượng sau khi cập nhật
            int tongSoLuong = GioHangBUS.TinhTongSoLuongGioHang(userId);

            // Gán giá trị cho ViewBag để truyền vào view
            ViewBag.TongSoLuong = tongSoLuong;
           

            // Chuyển hướng đến action "HienThiThongTinSanPham" trong controller "GioHang"
            return RedirectToAction("Index", "GioHang");
        }
        [HttpPost]
        public ActionResult XoaGioHang(string maSanPham, string userId)
        {
            GioHang gioHangItem = new GioHang { MaSanPham = maSanPham };

            GioHangBUS.XoaGioHang(gioHangItem, userId);

            return RedirectToAction("Index", "GioHang");
        }
    }
}