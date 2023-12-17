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
        public int IdGH { get; set; }
        public string UserID { get; set; }
        public string MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public int? TongTien { get; set; }
        public string MaLoaiSanPham { get; set; }
        public string MaNhaSanXuat { get; set; }
        public string TenSanPham { get; set; }
        public string CauHinh { get; set; }
        public string HinhChinh { get; set; }
        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public string Hinh4 { get; set; }
        public int? Gia { get; set; }
        public int? SoLuongDaBan { get; set; }
        public int? LuotView { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
        public int TongSoLuong { get; set; }
    }
    public class GioHangBUS
    {
        public static GioHang GetCartItem(string maSanPham, string userId)
        {
            var db = new ShopConnectionDB();

            // Sử dụng tham số hóa trong câu truy vấn SQL
            var query = "SELECT * FROM GioHang WHERE MaSanPham = @MaSanPham AND UserID = @UserID";

            // Tạo đối tượng tham số và thêm giá trị cho mỗi tham số
            var parameters = new { MaSanPham = maSanPham, UserID = userId };

            // Sử dụng Query<T> với tham số
            return db.SingleOrDefault<GioHang>(query, parameters);
        }



        //hàm add cart
        public static void AddOrUpdateCartItem(GioHang gioHangItem, string userId)
        {
            var db = new ShopConnectionDB();

           
            Debug.WriteLine($"AddOrUpdateCartItem - UserID: {userId}");

            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (!string.IsNullOrEmpty(userId))
            {
                var existingCartItem = GetCartItem(gioHangItem.MaSanPham, userId);

                if (existingCartItem != null)
                {
                    // Nếu sản phẩm đã tồn tại, cập nhật thông tin
                    existingCartItem.SoLuong += gioHangItem.SoLuong;
                    var giaSanPham = db.ExecuteScalar<int>("SELECT Gia FROM SanPham WHERE MaSanPham = @0", existingCartItem.MaSanPham);
                    existingCartItem.TongTien = existingCartItem.SoLuong * giaSanPham;

                    db.Update(existingCartItem);
                }
                else
                {
                    // Nếu sản phẩm chưa tồn tại, thêm mới vào giỏ hàng
                    var newProduct = db.FirstOrDefault<SanPham>("SELECT * FROM SanPham WHERE MaSanPham = @0", gioHangItem.MaSanPham);

                    if (newProduct != null)
                    {
                        var gioHangItemToAdd = new GioHang
                        {
                            MaSanPham = newProduct.MaSanPham,
                            UserID = userId,
                            SoLuong = gioHangItem.SoLuong,
                            TongTien = newProduct.Gia * gioHangItem.SoLuong
                        };
                        db.Insert(gioHangItemToAdd);
                    }
                }

                // Tính tổng số tiền cần thanh toán
                var tongSoTienCanThanhToan = db.ExecuteScalar<int>("SELECT SUM(TongTien) FROM GioHang WHERE UserID = @0", userId);
            }
            else
            {
                // Người dùng chưa đăng nhập, có thể xử lý theo cách nào đó (hoặc báo lỗi)
                Debug.WriteLine("Người dùng chưa đăng nhập. Không thể thêm sản phẩm vào giỏ hàng.");
            }
        }


        //hàm Update
        public static void CapNhat(GioHang gioHangItem, string userId)
        {
            var db = new ShopConnectionDB();

            var existingCartItem = GetCartItem(gioHangItem.MaSanPham, userId);

            if (existingCartItem != null)
            {

                // Nếu sản phẩm đã tồn tại, cập nhật thông tin
               
                var giaSanPham = db.ExecuteScalar<int>("SELECT Gia FROM SanPham WHERE MaSanPham = @0", existingCartItem.MaSanPham);
               //Trừ đi số lượng cũ để cập nhật giá trị mới 
                existingCartItem.TongTien -= existingCartItem.SoLuong * giaSanPham;

                //cập nhật số lượng mới
                existingCartItem.SoLuong = gioHangItem.SoLuong;
                existingCartItem.TongTien += existingCartItem.SoLuong * giaSanPham;
                existingCartItem.UserID = userId;
                Debug.WriteLine($"AddOrUpdateCartItem - UserID: {userId}");
                db.Update(existingCartItem);
            }
        }

        // lấy tổng số lượng đang có hiện thị ra view




        public static int TinhTongSoLuongGioHang(string userId)
        {
            var db = new ShopConnectionDB();
            int tongSoLuong = db.ExecuteScalar<int>("SELECT COALESCE(SUM(SoLuong), 0) FROM GioHang WHERE UserID = @0", userId);


            Debug.WriteLine($"Tong so luong: {tongSoLuong}"); // Sử dụng Debug.WriteLine để hiển thị giá trị trong Output window

            return tongSoLuong;
        }


        public static void XoaGioHang(GioHang gioHangItem, string userId)
        {
            var db = new ShopConnectionDB();

             db.Delete<GioHang>("where MaSanPham = @0", gioHangItem.MaSanPham);
            CapNhat(gioHangItem,userId);
        }

        public static IEnumerable<GioHangViewModel> GetGioHangDetails()
        {
            var db = new ShopConnectionDB();

            var sql = @"
        SELECT
            GH.IdGH,
            GH.UserID,
            GH.MaSanPham,
            GH.SoLuong,
            GH.TongTien,
            SP.MaLoaiSanPham,
            SP.MaNhaSanXuat,
            SP.TenSanPham,
            SP.CauHinh,
            SP.HinhChinh,
            SP.Hinh1,
            SP.Hinh2,
            SP.Hinh3,
            SP.Hinh4,
            SP.Gia,
            SP.SoLuongDaBan,
            SP.LuotView,
            SP.TinhTrang,
            SP.GhiChu
        FROM
            GioHang GH
        JOIN
            SanPham SP ON GH.MaSanPham = SP.MaSanPham
    ";

            var result = db.Query<GioHangViewModel>(sql).ToList();
            // Do something with the result, or return it as needed
            return result;
        }
    }
}