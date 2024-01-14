using ShopConnection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;


namespace Shop_Mobile.Models.BUS
{
   

    public class GioHangViewModel
    {
        public string UserID { get; set; }
        public int IdGH { get; set; }
        public string MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public int? TongTien { get; set; }
        public string TenSanPham { get; set; }
        public string HinhChinh { get; set; }
        public int? Gia { get; set; }
        public int? SoLuongDaBan { get; set; }
        public int TongSoLuong { get; set; }
    }
    public class GioHangBUS
    {


        public static GioHang LaySanPhamGH(string userId, GioHang gioHangItem)
        {
            var db = new ShopConnectionDB();

            var query = "SELECT * FROM GioHang WHERE MaSanPham = @MaSanPham AND UserID = @UserID";
            var parameters = new { MaSanPham = gioHangItem.MaSanPham, UserID = userId };
            var result = db.FirstOrDefault<GioHang>(query, parameters);

            return result;
        }


        public static void TaoMoiVaThemVaoGioHang(string userId, string maSanPham, GioHang gioHangItem)
        {
            var db = new ShopConnectionDB();


            if (!string.IsNullOrEmpty(userId))
            {
                var existingCartItem = LaySanPhamGH(userId, gioHangItem);

                if (existingCartItem == null)
                {

                    // Nếu sản phẩm chưa tồn tại, thêm mới vào giỏ hàng
                    var newProduct = db.FirstOrDefault<SanPham>("SELECT * FROM SanPham WHERE MaSanPham = @MaSanPham ", new { MaSanPham = gioHangItem.MaSanPham });
                    var gioHangItemToAdd = new GioHang
                    {
                        MaSanPham = newProduct.MaSanPham,
                        UserID = userId,
                        SoLuong = gioHangItem.SoLuong,
                        TongTien = newProduct.Gia * gioHangItem.SoLuong
                    };
                    db.Insert(gioHangItemToAdd);
                }
                else
                {
                    // Nếu sản phẩm đã tồn tại, cập nhật thông tin
                    existingCartItem.SoLuong += gioHangItem.SoLuong;
                    var giaSanPham = db.ExecuteScalar<int>("SELECT Gia FROM SanPham WHERE MaSanPham = @0", existingCartItem.MaSanPham);
                    existingCartItem.TongTien = giaSanPham * existingCartItem.SoLuong;
                    db.Update(existingCartItem);
                }
            }
            else
            {
                // Người dùng chưa đăng nhập, có thể xử lý theo cách nào đó (hoặc báo lỗi)
                Debug.WriteLine("Người dùng chưa đăng nhập. Không thể thêm sản phẩm vào giỏ hàng.");
            }

        }

        public static void SanPhamUpdate(string userId, GioHang gioHangItem)
        {
            var db = new ShopConnectionDB();
            var existingCartItem = LaySanPhamGH(userId, gioHangItem);
            if (existingCartItem != null)
            {
                var newProduct = db.FirstOrDefault<SanPham>("SELECT * FROM SanPham WHERE MaSanPham = @0", gioHangItem.MaSanPham);

                existingCartItem.SoLuong = gioHangItem.SoLuong;
                existingCartItem.TongTien = newProduct.Gia * gioHangItem.SoLuong;
                db.Update(existingCartItem);

            }
        }
        public static void XoaSanPhamGH(string userId, GioHang gioHangItem)
        {
            var db = new ShopConnectionDB();

            var query = "DELETE FROM GioHang WHERE MaSanPham = @MaSanPham";
            var parameters = new { MaSanPham = gioHangItem.MaSanPham };
            db.Execute(query, parameters);
        }
        public static void XoaTatCaGH(string userId)
        {
            var db = new ShopConnectionDB();

            var query = "DELETE FROM GioHang WHERE UserID = @UserID";
            var parameters = new { UserID = userId };
            db.Execute(query, parameters);
        }
        public static decimal TinhTongTienGH(string userId)
        {
            var db = new ShopConnectionDB();

            var parameters = new { UserId = userId };
            var tongTien = db.FirstOrDefault<decimal>(
                "SELECT SUM(TongTien) FROM GioHang WHERE UserID = @UserId",
                parameters);


            return tongTien;
        }


        public static IEnumerable<GioHangViewModel> ChiTietGioHang(string userId)
        {
            var db = new ShopConnectionDB();

            var sql = @"
        SELECT
            GH.IdGH,
            GH.UserID,
            GH.MaSanPham,
            GH.SoLuong,
            GH.TongTien,
            SP.TenSanPham,
            SP.HinhChinh,
            SP.Gia
        FROM
            GioHang GH
        JOIN
            SanPham SP ON GH.MaSanPham = SP.MaSanPham
        WHERE 
            GH.UserID = @UserID
    ";
            var parameters = new { UserID = userId };
            var result = db.Query<GioHangViewModel>(sql, parameters).ToList();

            return result;
        }
        public static int TongSanPham(string userId)
        {
            using (var db = new ShopConnectionDB())
            {
                var query = "SELECT SUM(SoLuong) FROM GioHang WHERE UserId = @0";
                var totalQuantity = db.ExecuteScalar<int?>(query, userId);
                return totalQuantity ?? 0;
            }
        }
    }
}