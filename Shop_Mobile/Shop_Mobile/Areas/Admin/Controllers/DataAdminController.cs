using Shop_Mobile.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Areas.Admin.Controllers
{
    public class DataAdminController : Controller
    {
        // GET: Admin/DataAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Top1Comment()
        {
            var db = DataBUS.Top1Comment();
            return PartialView("_Top1Comment", db);
        }
    }
}