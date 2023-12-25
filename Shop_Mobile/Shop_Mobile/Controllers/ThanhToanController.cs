﻿using Shop_Mobile.Models.BUS;
using ShopConnection;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var tongTien = GioHangBUS.TinhTongTienGH(userId);
            ViewBag.TongTien = tongTien;
            ViewBag.UserID = userId;
            IEnumerable<HoaDonProduct> hoaDonProduct = null;
            if (User.Identity.IsAuthenticated)
            {
                hoaDonProduct = ThanhToanBUS.ChiTietHoaDon(userId);
            }
           

            return View(hoaDonProduct);
        }

       [HttpGet]
        public JsonResult HasThongTinKhachHang()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                bool hasThongTin = ThanhToanBUS.HasThongTinKhachHang(userId);
               return Json(hasThongTin, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in HasThongTinKhachHang: {ex.Message}");
                return Json(false);
            }
        }

        // GET: ThanhToan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThanhToan/Create
        [HttpPost]
        public ActionResult Create(ThongTinKhachHang KH)
        {
            var userId = User.Identity.GetUserId();
            try
            {
                if (KH!=null)
                {
                    KH.UserID = userId;
                    ThanhToanBUS.AddThongTinKhachHang(KH);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThanhToan/Edit/5
        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            var db = ThanhToanBUS.GetThongTinKH(userId);
            return View(db);
        }

        // POST: ThanhToan/Edit/5
        [HttpPost]
        public ActionResult Edit(ThongTinKhachHang KH)
        {
            var userId = User.Identity.GetUserId();
            try
            {
                KH.UserID = userId;
                ThanhToanBUS.UpdateThongTinKhachHang(KH);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThanhToan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThanhToan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
