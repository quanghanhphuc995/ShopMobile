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
        public ActionResult Details(string maSanPham)
        {
            var db =  ShopOnlineBUS.ChiTietSanPham(maSanPham);
            if (db!=null && db.GetType()==typeof(ViewSanPhamChiTiet))
            {
                return View(db);
            }
            else
            {
                // Nếu kiểu dữ liệu không đúng, xử lý theo ý bạn
                return Content("Không tìm thấy thông tin sản phẩm.");
            }
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

            var DanhSachRamList = ShopOnlineBUS.DanhSachRam();
            var ListDanhSachRam = new SelectList(DanhSachRamList, "MaRam", "DungLuongRam");
            ViewBag.MaRam = ListDanhSachRam;

            var DanhSachBNTList = ShopOnlineBUS.DanhSachBNT();
            var ListDanhSachBNT = new SelectList(DanhSachBNTList, "MaBoNhoTrong", "DungLuongBoNho");
            ViewBag.MaBoNhoTrong = ListDanhSachBNT;

            var DanhSachHDHList = ShopOnlineBUS.DanhSachHDH();
            var ListDanhSachHDH = new SelectList(DanhSachHDHList, "MaHeDieuHanh", "TenHeDieuHanh");
            ViewBag.MaHeDieuHanh = ListDanhSachHDH;

            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ViewSanPhamChiTiet spChiTiet)
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
                            string fileName = MakeValidFileName(spChiTiet.TenSanPham) + "_Images" + (i + 1);
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
                                    spChiTiet.HinhChinh = fileName + ".png";
                                    break;

                                case 1:
                                    spChiTiet.Hinh1 = fileName + ".png";
                                    break;
                                case 2:
                                    spChiTiet.Hinh2 = fileName + ".png";
                                    break;
                                case 3:
                                    spChiTiet.Hinh3 = fileName + ".png";
                                    break;
                                case 4:
                                    spChiTiet.Hinh4 = fileName + ".png";
                                    break;

                            }

                        }
                    }
                }       
                var loaiSanPhamList = LoaiSanPhamBUS.DanhSachAdmin();
                ViewBag.MaLoaiSanPham = new SelectList(loaiSanPhamList, "MaLoaiSanPham", "TenLoaiSanPham");

                var nhaSanXuatList = NhaSanXuatBUS.DanhSachAdmin();
                ViewBag.MaNhaSanXuat = new SelectList(nhaSanXuatList, "MaNhaSanXuat", "TenNhaSanXuat");

                var DanhSachRamList = ShopOnlineBUS.DanhSachRam();
                var ListDanhSachRam = new SelectList(DanhSachRamList, "MaRam", "DungLuongRam");
               

                var DanhSachBNTList = ShopOnlineBUS.DanhSachBNT();
                var ListDanhSachBNT = new SelectList(DanhSachBNTList, "MaBoNhoTrong", "DungLuongBoNho");
                

                var DanhSachHDHList = ShopOnlineBUS.DanhSachHDH();
                var ListDanhSachHDH = new SelectList(DanhSachHDHList, "MaHeDieuHanh", "TenHeDieuHanh");
               

                if (ModelState.IsValid)
                {
                    // Thêm sản phẩm vào cơ sở dữ liệu
                    ShopOnlineBUS.ThemSP(spChiTiet);
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("lỗi" + ex.ToString());
                Console.WriteLine("Lỗi xử lý tệp tin: " + ex.Message);
            }
            return View(spChiTiet);
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
            var maLoaiSanPham = ShopOnlineBUS.ChiTietSanPham(id).MaLoaiSanPham;
            ViewBag.MaLoaiSanPham = new SelectList(loaiSanPhamList, "MaLoaiSanPham", "TenLoaiSanPham", maLoaiSanPham);

            var nhaSanXuatList = NhaSanXuatBUS.DanhSachAdmin();
            var maNhaSanXuat = ShopOnlineBUS.ChiTietSanPham(id).MaNhaSanXuat;
            ViewBag.MaNhaSanXuat = new SelectList(nhaSanXuatList, "MaNhaSanXuat", "TenNhaSanXuat", maNhaSanXuat);

            var DanhSachRamList = ShopOnlineBUS.DanhSachRam();
            var danhSachRam = ShopOnlineBUS.ChiTietSanPham(id).MaRam;
            ViewBag.MaRam = new SelectList(DanhSachRamList, "MaRam", "DungLuongRam",danhSachRam);


            var DanhSachBNTList = ShopOnlineBUS.DanhSachBNT();
            var danhSachBNT = ShopOnlineBUS.ChiTietSanPham(id).MaBoNhoTrong;
            ViewBag.MaBoNhoTrong = new SelectList(DanhSachBNTList, "MaBoNhoTrong", "DungLuongBoNho", danhSachBNT);


            var DanhSachHDHList = ShopOnlineBUS.DanhSachHDH();
            var danhSachHDH = ShopOnlineBUS.ChiTietSanPham(id).MaHeDieuHanh;
            ViewBag.MaHeDieuHanh = new SelectList(DanhSachHDHList, "MaHeDieuHanh", "TenHeDieuHanh", danhSachHDH);

            var db = ShopOnlineBUS.ChiTietSanPham(id);
            return View(db);
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ViewSanPhamChiTiet spChiTiet)
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
                            string fileName = MakeValidFileName(spChiTiet.TenSanPham) + "_img" + (i + 1);
                            string directoryPath = Server.MapPath("~/Asset/img");

                            string fullName = Path.Combine(directoryPath, fileName + ".png");

                            hpf.SaveAs(fullName);

                            switch (i)
                            {
                                case 0:
                                    spChiTiet.HinhChinh = fileName + ".png";
                                    break;

                                case 1:
                                    spChiTiet.Hinh1 = fileName + ".png";
                                    break;
                                case 2:
                                    spChiTiet.Hinh2 = fileName + ".png";
                                    break;
                                case 3:
                                    spChiTiet.Hinh3 = fileName + ".png";
                                    break;
                                case 4:
                                    spChiTiet.Hinh4 = fileName + ".png";
                                    break;
                            }
                        }
                    }
                }

                // TODO: Add update logic here
                ShopOnlineBUS.CapNhatSP(spChiTiet);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        [HttpPost, ActionName("Delete")]
       
        public ActionResult Delete(string id, FormCollection collection)
        {
            
                
                ShopOnlineBUS.XoaSP(id);
            

            return RedirectToAction("Index");
        }
    }
    
    
}
