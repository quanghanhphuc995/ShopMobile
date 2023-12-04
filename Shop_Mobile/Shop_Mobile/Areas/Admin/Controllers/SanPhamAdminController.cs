using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View(ShopOnlineBUS.DanhSachSPAdmin());
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            var loaiSanPhamList = LoaiSanPhamBUS.DanhSachAdmin();
            var listLoaiSanPham = new SelectList(loaiSanPhamList, "MaLoaiSanPham", "TenLoaiSanPham");
            ViewBag.MaLoaiSanPham = listLoaiSanPham;

            var nhaSanXuatList = NhaSanXuatBUS.DanhSachAdmin();
            var listMaNhaSanXuat = new SelectList(nhaSanXuatList, "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaNhaSanXuat = listMaNhaSanXuat;
            //ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSachAdmin(), "MaNhaSanXuat", "TenNhaSanXuat");
            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength>0)
                {
                    string fileName = sp.MaSanPham;
                    string savelinkImg = "~Asset/images/" + fileName + ".png, .jpg";
                    hpf.SaveAs(Server.MapPath(savelinkImg));
                    sp.HinhChinh = sp.MaSanPham + ".png, .jpg";
                }
                sp.TinhTrang = "0";
                sp.SoLuongDaBan = 0;


                var loaiSanPhamList = LoaiSanPhamBUS.DanhSachAdmin();
                ViewBag.MaLoaiSanPham = new SelectList(loaiSanPhamList, "MaLoaiSanPham", "TenLoaiSanPham");

                var nhaSanXuatList = NhaSanXuatBUS.DanhSachAdmin();
                ViewBag.MaNhaSanXuat = new SelectList(nhaSanXuatList, "MaNhaSanXuat", "TenNhaSanXuat");

                if (ModelState.IsValid)
                {
                    // Thêm sản phẩm vào cơ sở dữ liệu
                    ShopOnlineBUS.ThemSP(sp);
                    return RedirectToAction("Index");
                }

                
            }
            catch
            {
                Console.WriteLine("lỗi");
            }
            return View(sp);
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(string id)
        {
            var db = ShopOnlineBUS.ChitietSPAdmin(id);
            return View(db);
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SanPham sp)
        {
            try
            {
                // TODO: Add update logic here
                ShopOnlineBUS.UpdateSP(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var db = new ShopConnectionDB();
                db.Delete("SanPham", "MaSanPham", null, id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
