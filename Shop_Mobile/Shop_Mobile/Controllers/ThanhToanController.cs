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
            return View();
        }

        

        // GET: ThanhToan/Create
        public ActionResult Order()
        {
            return View();
        }

        // POST: ThanhToan/Create
        [HttpPost]
        public ActionResult Order(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
