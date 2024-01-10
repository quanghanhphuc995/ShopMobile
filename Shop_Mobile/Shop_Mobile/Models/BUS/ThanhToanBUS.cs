using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class HoaDonViewModel
    {
        public int IdGH { get; set; }
        public string UserID { get; set; }
        public int HoaDonID { get; set; }
        public string NguoiDat { get; set; }
        public double? SDT { get; set; }
        public string DiaChi { get; set; }
        public string Content { get; set; }
        public string MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public int? TongTien { get; set; }
        public string TenSanPham { get; set; }
        public string HinhChinh { get; set; }
        public int? Gia { get; set; }
    }

    public class HoaDonViewModelAdmin
    {
        public string UserID { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhatCuoiCung { get; set; }
        public string NguoiDat { get; set; }
        public string DiaChi { get; set; }
        public double? SDT { get; set; }
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        public int? TongTien { get; set; }
        public string HinhChinh { get; set; }
    }

    public class ThanhToanBUS
    {

        public static bool HasThongTinKhachHang(string userId)
        {
            var db = new ShopConnectionDB();

            // Kiểm tra xem có dòng dữ liệu nào với UserID tương ứng hay không
            var sql = "SELECT COUNT(*) FROM ThongTinKhachHang WHERE UserID = @UserID";
            var parameters = new { UserID = userId };
            var count = db.ExecuteScalar<int>(sql, parameters);

            // Trả về true nếu có ít nhất một dòng dữ liệu, ngược lại là false
            return count > 0;
        }

        public static ThongTinKhachHang GetThongTinKH(string userId)
        {
            var db = new ShopConnectionDB();
            var query = "select * from ThongTinKhachHang where UserID = @UserID";
            var parameter = new { UserID = userId };
            var result = db.FirstOrDefault<ThongTinKhachHang>(query, parameter);
            return result;
        }

        //public static IEnumerable<GioHang> HoaDonProduct( GioHang gioHangItem)
        //{
        //    var db = new ShopConnectionDB();
        //    var query = "select * from GioHang where MaSanPham = @MaSanPham and UserID = @UserID";
        //    var paramerters = new { MaSanPham = gioHangItem.MaSanPham, UserID = gioHangItem.UserID };
        //    var result = db.Query<GioHang>(query, paramerters);
        //    return result ;
        //}
        public static void AddThongTinKhachHang(string userID, string nguoiDat, string diaChi, string soDT)
        {
            var db = new ShopConnectionDB();
            if (!string.IsNullOrEmpty(nguoiDat) && !string.IsNullOrWhiteSpace(diaChi) && !string.IsNullOrEmpty(soDT))
            {
                var thongTinKhachHang = new ThongTinKhachHang
                {
                    UserID = userID,
                    NguoiDat = nguoiDat,
                    DiaChi = diaChi,
                    SDT = soDT
                };
                db.Insert(thongTinKhachHang);
            }



        }

        public static void UpdateThongTinKhachHang(ThongTinKhachHang KH)
        {
            try
            {
                var db = new ShopConnectionDB();
                db.Update(KH);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data: {ex.Message}");
                throw;
            }
           
        }
        public static IEnumerable<HoaDonViewModel> HoaDon(string userId)
        {
            var db = new ShopConnectionDB();

            try
            {
                var sql = @"
       SELECT
            GH.IdGH,
            GH.UserID AS GioHangUserID,
            GH.MaSanPham,
            GH.SoLuong,
            GH.TongTien,
            SP.TenSanPham,
            SP.Gia,
            SP.HinhChinh
        FROM
            GioHang GH
        JOIN
            SanPham SP ON GH.MaSanPham = SP.MaSanPham
       
        WHERE
            GH.UserID = @UserID
        ";
                var parameters = new { UserID = userId };
                var result = db.Query<HoaDonViewModel>(sql, parameters).ToList();

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