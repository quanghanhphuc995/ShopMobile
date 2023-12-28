using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class HoaDonBUS
    {
        
        //Phần Khách hàng
        public static void AddHoaDon( string userId)
        {
            var db = new ShopConnectionDB();
                var sql = @"
                INSERT INTO HoaDon (UserID, ThongTinKHID, NguoiDat, DiaChi, SDT, MaSanPham, SoLuong, TongTien, Gia, TenSanPham, HinhChinh)
            SELECT 
                    ttkh.UserID,
                    ttkh.ThongTinKHID, 
                    ttkh.NguoiDat, 
                    ttkh.DiaChi, 
                    ttkh.SDT, 
                    sp.MaSanPham, 
                    gh.SoLuong, 
                    gh.TongTien, 
                    sp.Gia, 
                    sp.TenSanPham, 
                    sp.HinhChinh
            FROM GioHang gh
            JOIN SanPham sp ON gh.MaSanPham = sp.MaSanPham
            LEFT JOIN ThongTinKhachHang ttkh ON gh.UserID = ttkh.UserID
            WHERE ttkh.UserID = @0

            ";
                db.Execute(sql, new object[] { userId });
        }

        public static IEnumerable<HoaDon> GetHoaDon(string userId)
        {
            var db = new ShopConnectionDB();
            var query = "Select * From HoaDon Where UserID = @UserID";
            var parameters = new { UserID = userId };
            var result = db.Query<HoaDon>(query, parameters);
            return result;
        }


        //Phần admin

        public static IEnumerable<HoaDon> GetHoaDonAdmin()
        {
            var db = new ShopConnectionDB();
            var query = @"SELECT 
                            UserID, 
                            ThongTinKHID, 
                            NguoiDat, 
                            DiaChi, 
                            SDT
                        FROM
                            HoaDon
                        GROUP BY
                            UserID, ThongTinKHID, NguoiDat, DiaChi, SDT";
            
            var result = db.Query<HoaDon>(query);
            return result;
        }
    }
}