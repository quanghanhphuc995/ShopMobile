using Microsoft.AspNet.Identity;
using Shop_Mobile.Models.BUS;
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
            string userId = User.Identity.GetUserId();
            var db = HoaDonBUS.GetHoaDonAdmin();
            return View(db);
        }
    }
}