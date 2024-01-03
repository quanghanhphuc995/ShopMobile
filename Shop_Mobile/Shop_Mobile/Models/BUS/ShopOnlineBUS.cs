using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class ViewSanPhamChiTiet
    {
        public string MaSanPham { get; set; }
        public string MaLoaiSanPham { get; set; }
        public string MaNhaSanXuat { get; set; }
        public string TenSanPham { get; set; }
        public string HinhChinh { get; set; }
        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public string Hinh4 { get; set; }
        public int? Gia { get; set; }
        public string GhiChu { get; set; }
        public int? SoLuong { get; set; }
        public string VideoSP { get; set; }
        public string ManHinh { get; set; }
        public string MaHeDieuHanh { get; set; }
        public string CameraSau { get; set; }
        public string CameraTruoc { get; set; }
        public string CPU { get; set; }
        public string MaRam { get; set; }
        public string MaBoNhoTrong { get; set; }
        public string TheSim { get; set; }
        public string DungLuongPin { get; set; }
        public string ThietKe { get; set; }
    }

    public class ShopOnlineBUS
    {

       
        public static ViewSanPhamChiTiet ChiTietSanPham(string maSanPham)
        {
            var db = new ShopConnectionDB();
            var query = @"Select
sp.MaSanPham,
sp.MaNhaSanXuat,
sp.TenSanPham,
sp.HinhChinh,
sp.Hinh1,
sp.Hinh2,
sp.Hinh3,
sp.Hinh4,
sp.Gia,
sp.SoLuong,
sp.VideoSP,
ch.ManHinh,
ch.MaHeDieuHanh,
ch.CameraSau,
ch.CameraTruoc,
ch.CPU,
ch.MaRam,
ch.MaBoNhoTrong,
ch.TheSim,
ch.DungLuongPin,
ch.ThietKe
From SanPham sp
INNER JOIN CauHinh ch ON sp.MaSanPham = ch.MaSanPham
WHERE sp.MaSanPham =@0
    ";
            return db.SingleOrDefault<ViewSanPhamChiTiet>(query, maSanPham);
        }
        //--------------------- khách hàng-----------------------------
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham");
        }
        public static SanPham ChiTietSP(String a)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<SanPham>("select * from SanPham where MaSanPham=@0",a);
        }
        //Lấy Top 4 san phẩm mới nhất
        public static IEnumerable<SanPham> TopNew()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select Top 4 * from SanPham where GhiChu = N'New'");
        }

        public static IEnumerable<SanPham> TopBanNhieuNhat()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select Top 4 * from SanPham where SoLuongDaBan = 0");
        }

       
        //----------------------- Admin Sản phẩm-------------------------------------
        public static IEnumerable<SanPham> DanhSachSPAdmin()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham");
        }

        public static void ThemSP(ViewSanPhamChiTiet spChiTiet)
        {
            var db = new ShopConnectionDB();
            db.Execute("INSERT INTO SanPham (MaSanPham, MaLoaiSanPham, MaNhaSanXuat, TenSanPham, HinhChinh, Hinh1, Hinh2, Hinh3, Hinh4, Gia, GhiChu, VideoSP) VALUES (@MaSanPham, @MaLoaiSanPham, @MaNhaSanXuat, @TenSanPham, @HinhChinh, @Hinh1, @Hinh2, @Hinh3, @Hinh4, @Gia, @GhiChu,@VideoSP)",
                 new { spChiTiet.MaSanPham, spChiTiet.MaLoaiSanPham, spChiTiet.MaNhaSanXuat, spChiTiet.TenSanPham, spChiTiet.HinhChinh, spChiTiet.Hinh1, spChiTiet.Hinh2, spChiTiet.Hinh3, spChiTiet.Hinh4, spChiTiet.Gia, spChiTiet.GhiChu,spChiTiet.VideoSP });

            db.Execute("INSERT INTO CauHinh (MaSanPham,ManHinh, MaHeDieuHanh, CameraSau, CameraTruoc, CPU, MaRam, MaBoNhoTrong, TheSim, DungLuongPin, ThietKe) VALUES (@MaSanPham, @ManHinh, @MaHeDieuHanh, @CameraSau, @CameraTruoc, @CPU, @MaRam, @MaBoNhoTrong, @TheSim, @DungLuongPin, @ThietKe)",
             new { spChiTiet.MaSanPham, spChiTiet.ManHinh, spChiTiet.MaHeDieuHanh, spChiTiet.CameraSau, spChiTiet.CameraTruoc, spChiTiet.CPU, spChiTiet.MaRam, spChiTiet.MaBoNhoTrong, spChiTiet.TheSim, spChiTiet.DungLuongPin, spChiTiet.ThietKe });
        }
        
        public static SanPham ChitietSPAdmin(string id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<SanPham>("select * from SanPham where MaSanPham = @0", id);
        }

        public static void UpdateSP(string id, SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Update(sp, id);
        }

        public static SanPham XoaSP(string id)
        {
            var db = new ShopConnectionDB();
            if (string.IsNullOrEmpty(id))
            {
                // Xử lý khi id không hợp lệ (ví dụ: trả về lỗi hoặc chuyển hướng đến trang lỗi)
                Console.WriteLine("có nó đâu đòi xóa cha");
                //...
                return null;
            }


            // Xóa sản phẩm khỏi cơ sở dữ liệu
            int rowsAffected = db.Execute("DELETE FROM SanPham WHERE MaSanPham = @0", id);

            // Nếu có ít nhất một hàng bị ảnh hưởng, thực hiện câu truy vấn SELECT
            if (rowsAffected > 0)
            {
                return db.SingleOrDefault<SanPham>("SELECT * FROM SanPham WHERE MaSanPham = @0", id);
            }

            
            return null; // hoặc có thể trả về một đối tượng SanPham mặc định, hoặc thông tin khác tùy thuộc vào trường hợp của bạn.
        }


        //------------------------Phần ad hệ điều hành------------------------

        public static IEnumerable<HeDieuHanh> DanhSachHDH()
        {
            var db = new ShopConnectionDB();
            return db.Query<HeDieuHanh>("select * from HeDieuHanh");
        }
        public static HeDieuHanh ChiTietHDH(String id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<HeDieuHanh>("select * from HeDieuHanh where MaHeDieuHanh = '" + id + "'");
        }
        public static void ThemHDH(HeDieuHanh hdh)
        {
            var db = new ShopConnectionDB();
            db.Insert(hdh);
        }

        public static void UpadateHDH(String id, HeDieuHanh hdh)
        {
            var db = new ShopConnectionDB();
            db.Update(hdh, id);
        }
        public static void XoaHDH(string maHeDieuHanh)
        {
            var db = new ShopConnectionDB();
            db.Execute("Delete From HeDieuHanh Where MaHeDieuHanh = @0", maHeDieuHanh);
            
        }

        //------------------------Phần Bộ Nhớ Trong------------------------
        public static IEnumerable<BoNhoTrong> DanhSachBNT()
        {
            var db = new ShopConnectionDB();
            return db.Query<BoNhoTrong>("select * from BoNhoTrong");
        }

        public static BoNhoTrong ChiTietBNT(string  maBoNhoTrong)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<BoNhoTrong>("Select * From BoNhoTrong Where MaBoNhoTrong = @0", maBoNhoTrong);
        }

        public static void ThemBNT(BoNhoTrong bnt)
        {
            var db = new ShopConnectionDB();
            db.Insert(bnt);
        }
        public static void UpdateBNT(string maBoNhoTrong, BoNhoTrong bnt)
        {
            var db = new ShopConnectionDB();
            db.Update(bnt, maBoNhoTrong);
        }
        public static void XoaBNT(string maBoNhoTrong)
        {
            var db = new ShopConnectionDB();
            db.Execute("Delete From BoNhoTrong Where MaBoNhoTrong = @0", maBoNhoTrong);
        }

        //------------------------Phần Ram------------------------
        public static IEnumerable<Ram> DanhSachRam()
        {
            var db = new ShopConnectionDB();
            return db.Query<Ram>("select * from Ram");
        }
        public static Ram ChiTietRam(string maRam)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<Ram>("Select * From Ram Where MaRam = @0", maRam);
        }
        public static void ThemRam( Ram ram)
        {
            var db = new ShopConnectionDB();
            db.Insert(ram);
        }
        public static void UpdateRam(string maRam, Ram ram)
        {
            var db = new ShopConnectionDB();
            db.Update(ram, maRam);
        }
        public static void XoaRam(string maRam)
        {
            var db = new ShopConnectionDB();
            db.Execute("Delete From Ram Where MaRam = @0", maRam);
        }
    }
}