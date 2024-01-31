using PetaPoco;
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
        public static void AddHoaDon(string userId)
        {
            var db = new ShopConnectionDB();
            var existingHoaDons = GetHoaDon(userId);
            if (!existingHoaDons.Any())
            {
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
                var query = "Delete From GioHang Where UserID = @UserID";
                var parameters = new { UserID = userId };
                db.Execute(query, parameters);
            }
            else
            {
               
            }
                
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
                            SDT,
                            Sum(SoLuong),
                            Sum(TongTien)
                        FROM
                            HoaDon
                        GROUP BY
                            UserID, ThongTinKHID, NguoiDat, DiaChi, SDT";
            
            var result = db.Query<HoaDon>(query);
            return result;
        }

        public static IEnumerable<HoaDon> DanhSachGH(HoaDon hD)
        {
            var db = new ShopConnectionDB();
            var query = "Select * From HoaDon Where UserID = @UserID";
            var parameters = new { UserID = hD.UserID };
            var result = db.Query<HoaDon>(query, parameters);
            return result;
        }

        public static void UpdateSoLuongSanPham(string maSanPhams)
        {
            var db = new ShopConnectionDB(); // Thay thế bằng tên kết nối cơ sở dữ liệu của bạn

            // Lấy danh sách sản phẩm dựa trên danh sách mã sản phẩm
            var sqlSelect = new Sql("SELECT * FROM SanPham WHERE MaSanPham IN (@MaSanPham)", new { MaSanPham = maSanPhams.Split(',') });
            var sanPhams = db.Fetch<SanPham>(sqlSelect);

            foreach (var sanPham in sanPhams)
            {
                // Lấy số lượng hóa đơn hiện tại
                var sqlCountHoaDon = new Sql("SELECT COUNT(*) FROM HoaDon WHERE MaSanPham = @MaSanPham", new { MaSanPham = sanPham.MaSanPham });
                int? soLuongHoaDonNullable = db.ExecuteScalar<int?>(sqlCountHoaDon);

                // Kiểm tra và gán giá trị cho biến soLuongHoaDon
                int soLuongHoaDon = soLuongHoaDonNullable.HasValue ? soLuongHoaDonNullable.Value : 0;

                // Trừ số lượng hóa đơn từ số lượng sản phẩm
                int soLuongMoi = (int)sanPham.SoLuong - (soLuongHoaDonNullable ?? 0);

                // Cập nhật số lượng mới trong cơ sở dữ liệu
                var sqlUpdate = new Sql("UPDATE SanPham SET SoLuong = @SoLuongMoi WHERE MaSanPham = @MaSanPham",
                                        new { SoLuongMoi = soLuongMoi, MaSanPham = sanPham.MaSanPham });

                db.Execute(sqlUpdate);
            }
        }



    }
}