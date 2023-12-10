using Shop_Mobile.Models.BUS;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Mobile.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    //kiem tra request da co file gui len chua
                    if (HttpContext.Request.Files.Count > i)
                    {
                        var hpf = HttpContext.Request.Files[i];
                        //kiem tra requst > 0 hay khong
                        if (hpf.ContentLength > 0)
                        {
                            string fileName = MakeValidFileName(sp.TenSanPham) + "_Images" + (i + 1);
                            string directoryPath = Server.MapPath("~/Asset/img/");

                            // kiem tra xem thu muc co ton tai khong neu khong tao moi

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            string fullName = Path.Combine(directoryPath, fileName + ".png");

                            hpf.SaveAs(fullName);

                            switch (i)
                            {
                                case 0:
                                    sp.HinhChinh = fileName + ".png";
                                    break;

                                case 1:
                                    sp.Hinh1 = fileName + ".png";
                                    break;
                                case 2:
                                    sp.Hinh2 = fileName + ".png";
                                    break;
                                case 3:
                                    sp.Hinh3 = fileName + ".png";
                                    break;
                                case 4:
                                    sp.Hinh4 = fileName + ".png";
                                    break;

                            }

                        }
                    }
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
            catch (Exception ex)
            {
                Console.WriteLine("lỗi" + ex.ToString());
                Console.WriteLine("Lỗi xử lý tệp tin: " + ex.Message);
            }
            return View(sp);
        }
        // hàm loại bỏ các kí tự đặc biệt
        private string MakeValidFileName(string name)
        {
            // Loại bỏ các ký tự không hợp lệ
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char invalidChar in invalidChars)
            {
                name = name.Replace(invalidChar.ToString(), "");
            }

            // Thay thế khoảng trắng bằng dấu gạch dưới
            name = name.Replace(" ", "_");

            return name;
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(string id)
        {
            var loaiSanPhamList = LoaiSanPhamBUS.DanhSachAdmin();
            var maLoaiSanPham = ShopOnlineBUS.ChitietSPAdmin(id).MaLoaiSanPham;
            ViewBag.MaLoaiSanPham = new SelectList(loaiSanPhamList, "MaLoaiSanPham", "TenLoaiSanPham", maLoaiSanPham);

            var nhaSanXuatList = NhaSanXuatBUS.DanhSachAdmin();
            var maNhaSanXuat = ShopOnlineBUS.ChitietSPAdmin(id).MaNhaSanXuat;
            ViewBag.MaNhaSanXuat = new SelectList(nhaSanXuatList, "MaNhaSanXuat", "TenNhaSanXuat", maNhaSanXuat);

            var db = ShopOnlineBUS.ChitietSPAdmin(id);
            return View(db);
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, SanPham sp)
        {
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    //kiểm tra có file được gửi lên Request ko
                    if (HttpContext.Request.Files.Count > i)
                    {
                        //lấy file về
                        var hpf = HttpContext.Request.Files[i];

                        //kiểm tra xem request có nội dung hay không
                        if (hpf.ContentLength > 0)
                        {
                            string fileName = MakeValidFileName(sp.TenSanPham) + "_img" + (i + 1);
                            string directoryPath = Server.MapPath("~/Asset/img");

                            string fullName = Path.Combine(directoryPath, fileName + ".png");

                            hpf.SaveAs(fullName);

                            switch (i)
                            {
                                case 0:
                                    sp.HinhChinh = fileName + ".png";
                                    break;

                                case 1:
                                    sp.Hinh1 = fileName + ".png";
                                    break;
                                case 2:
                                    sp.Hinh2 = fileName + ".png";
                                    break;
                                case 3:
                                    sp.Hinh3 = fileName + ".png";
                                    break;
                                case 4:
                                    sp.Hinh4 = fileName + ".png";
                                    break;
                            }
                        }
                    }
                }

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
            var sanPham = ShopOnlineBUS.XoaSP(id);
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                var db = new ShopConnectionDB();
                ShopOnlineBUS.XoaSP(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa sản phẩm" + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
    
    
}
