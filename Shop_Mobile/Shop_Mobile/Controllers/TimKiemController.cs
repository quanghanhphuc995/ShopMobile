using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult TimKiemSP(string tuKhoa)
        {
            var db = TimKiemSanPham(tuKhoa);
            return View(db);
        }

        public IEnumerable<SanPham> TimKiemSanPham(string tuKhoa)
        {
            var db = new ShopConnectionDB();
            string sqlQuery = "SELECT * FROM SanPham WHERE TenSanPham LIKE @TuKhoa";
            return db.Query<SanPham>(sqlQuery, new { TuKhoa = "%" + tuKhoa + "%" });

        }
    }
}