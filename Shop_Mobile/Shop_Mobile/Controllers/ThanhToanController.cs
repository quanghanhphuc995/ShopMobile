using Shop_Mobile.Models.BUS;
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
            IEnumerable<HoaDonDeitails> hoaDonDeitails = null;
            if (User.Identity.IsAuthenticated)
            {
                hoaDonDeitails = ThanhToanBUS.ChiTietHoaDon(userId);
            }
           

            return View(hoaDonDeitails);
        }

        // GET: ThanhToan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThanhToan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThanhToan/Create
        [HttpPost]
        public ActionResult Create(ChiTietHoaDon HD)
        {
            try
            {
                // TODO: Add insert logic here
                ThanhToanBUS.AddThongTinKhachHang(HD);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThanhToan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ThanhToan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
