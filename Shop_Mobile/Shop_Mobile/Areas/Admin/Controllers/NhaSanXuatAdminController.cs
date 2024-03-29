﻿using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NhaSanXuatAdminController : Controller
    {
        // GET: Admin/NhaSanXuat
        public ActionResult Index()
        {
            var danhSach = NhaSanXuatBUS.DanhSachAdmin();
            return View(danhSach);
        }

        // GET: Admin/NhaSanXuat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuat/Create
        [HttpPost]
        public ActionResult Create( NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add insert logic here
                NhaSanXuatBUS.ThemNSX(nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuat/Edit/5
        public ActionResult Edit(String id)
        {
            return View(NhaSanXuatBUS.ChitietSPAdmin(id));
        }

        // POST: Admin/NhaSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add update logic here
                NhaSanXuatBUS.UpadateNSX(id,nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
           
                NhaSanXuatBUS.DeleteNSX( id);
            return Json(new { success = true });

        }
    }
}
