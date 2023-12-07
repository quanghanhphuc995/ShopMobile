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
                
                    if (HttpContext.Request.Files.Count > 0 && HttpContext.Request.Files[0] != null)
                    {
                        var hpf = HttpContext.Request.Files[0];

                        if (hpf.ContentLength > 0)
                        {
                        string fileName = MakeValidFileName(sp.TenSanPham);
                            string directoryPath = Server.MapPath("~/Asset/img/");

                            // Đảm bảo thư mục lưu trữ tồn tại, nếu không tạo mới
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            string fullNameImage = Path.Combine(directoryPath, fileName + ".png");

                            // Lưu tệp tin
                            hpf.SaveAs(fullNameImage);

                            // Cập nhật thuộc tính HinhChinh
                            sp.HinhChinh = fileName + ".png";
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
            catch(Exception ex)
            {
                Console.WriteLine("lỗi");
                // Xử lý ngoại lệ nếu có
                // Ví dụ: log lỗi, thông báo người dùng, ...
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
            var maLoaiSanPham = ShopOnlineBUS.ChiTietSP(id).MaLoaiSanPham;
            ViewBag.MaLoaiSanPham = new SelectList(loaiSanPhamList, "MaLoaiSanPham", maLoaiSanPham);

            var nhaSanXuatList = NhaSanXuatBUS.DanhSachAdmin();
            var maNhaSanXuat = ShopOnlineBUS.ChiTietSP(id).MaNhaSanXuat;
            ViewBag.MaNhaSanXuat = new SelectList(nhaSanXuatList, "MaNhaSanXuat", maNhaSanXuat);

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
        var db = new ShopConnectionDB();

        // Kiểm tra tồn tại của đối tượng
        var existingItem = db.FindSanPhamById(id);
        if (existingItem == null)
        {
            return HttpNotFound(); // Hoặc trả về ActionResult khác tùy thuộc vào yêu cầu của bạn
        }

        // Tiến hành xóa
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
