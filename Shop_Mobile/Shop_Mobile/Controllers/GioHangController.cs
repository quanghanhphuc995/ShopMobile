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
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult HienThiThongTinSanPham(string maSanPham, GioHang gioHangItem)
        {
            int tongSoLuong = GioHangBUS.TinhTongSoLuongGioHang();
            ViewBag.TongSoLuong = tongSoLuong;

            if (User.Identity.IsAuthenticated)
            {
                var dbGetCart = GioHangBUS.GetCartItem(maSanPham);
                if (dbGetCart == null)
                {
                    GioHangBUS.AddOrUpdateCartItem(gioHangItem);
                }
               
                var gioHangDetails = GioHangBUS.GetGioHangDetails();
                var gioHangViewModels = gioHangDetails.Select(g => new GioHangViewModel
                {
                    IdGH = g.IdGH,
                    Id = g.Id,
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

                return View(gioHangViewModels);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(GioHang gioHangItem)
        {
            // Gọi phương thức CapNhat từ GioHangBUS
            GioHangBUS.CapNhat(gioHangItem);
           

            // Tính tổng số lượng sau khi cập nhật
            int tongSoLuong = GioHangBUS.TinhTongSoLuongGioHang();

            // Gán giá trị cho ViewBag để truyền vào view
            ViewBag.TongSoLuong = tongSoLuong;
            Debug.WriteLine("số luowjmg alf com,êmnra"+ $"ViewBag.TongSoLuong: {ViewBag.TongSoLuong}");


            // Chuyển hướng đến action "HienThiThongTinSanPham" trong controller "GioHang"
            return RedirectToAction("HienThiThongTinSanPham", "GioHang");
        }
    }
}