using PagedList;
using Shop_Mobile.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        public ActionResult Index(String id, int page = 1, int pagesize = 3)
        {
            var danhSach = LoaiSanPhamBUS.LoaiSanPham(id).ToPagedList(page, pagesize);
            return View(danhSach);
        }
    }
}