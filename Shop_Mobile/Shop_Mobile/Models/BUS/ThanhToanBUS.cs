using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class HoaDonDeitails
    {
        public int IdGH { get; set; }
        public string UserID { get; set; }
        public int HoaDonID { get; set; }
        public string NguoiDat { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
        public string MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public int? TongTien { get; set; }
        public string TenSanPham { get; set; }
        public string HinhChinh { get; set; }
        public int? Gia { get; set; }
    }

    
    public class ThanhToanBUS
    {
        
       
        public static IEnumerable<GioHang> HoaDonDeitails(GioHang gioHangItem)
        {
            var db = new ShopConnectionDB();
            var query = "select * from GioHang where MaSanPham = @MaSanPham and UserID = @UserID";
            var paramerters = new { MaSanPham = gioHangItem.MaSanPham, UserID = gioHangItem.UserID };
            var result = db.Query<GioHang>(query, paramerters);
            return result ;
        }
        public static void AddThongTinKhachHang(ChiTietHoaDon HD)
        {
            var db = new ShopConnectionDB();
            db.Insert(HD);
        }

        public static IEnumerable<HoaDonDeitails> ChiTietHoaDon(string userId)
        {
            var db = new ShopConnectionDB();

            try
            {
                var sql = @"
       SELECT
            GH.IdGH,
            GH.UserID,
            GH.MaSanPham,
            GH.SoLuong,
            GH.TongTien,
            SP.*,
            CTHD.SoLuong,
            CTHD.Gia
        FROM
            GioHang GH
        JOIN
            SanPham SP ON GH.MaSanPham = SP.MaSanPham
        LEFT JOIN
            ChiTietHoaDon CTHD ON GH.MaSanPham = CTHD.MaSanPham
        WHERE
            UserID = @UserID
        ";
                var parameters = new { UserID = userId };
                var result = db.Query<HoaDonDeitails>(sql,parameters).ToList();

                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error executing query: {ex.Message}");
                throw; // Re-throw ngoại lệ để giữ nguyên thông báo lỗi
            }
           
        }

    }
}