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
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            HoaDonBUS.AddHoaDon(userId);
            AccountController accountController = new AccountController();
            Session["CartItemCount"] = "";
            return View();
        }
    }
}