using ShopConnection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class GioHangViewModel
    {
        public int IdGH { get; set; }
        public string Id { get; set; }
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
        public static GioHang GetCartItem(string maSanPham)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<GioHang>("SELECT * FROM GioHang WHERE MaSanPham = @0", maSanPham);
        }


        //hàm add cart
        public static void AddOrUpdateCartItem(GioHang gioHangItem)
        {
            var db = new ShopConnectionDB(); 

            var existingCartItem = GetCartItem(gioHangItem.MaSanPham);

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
                var newProduct = db.FirstOrDefault<SanPham>("select * from SanPham where MaSanPham = @0", gioHangItem.MaSanPham);

                if (newProduct !=null)
                {
                    var gioHangItemToAdd = new GioHang
                    {
                        MaSanPham = newProduct.MaSanPham,
                        SoLuong = gioHangItem.SoLuong,
                        TongTien =newProduct.Gia*gioHangItem.SoLuong
                    };
                    db.Insert(gioHangItemToAdd);
                }
            }
            var tongSoTienCanThanhToan = db.ExecuteScalar<int>("select sum(TongTien) from GioHang");
        }


        //hàm Update
        public static void CapNhat(GioHang gioHangItem)
        {
            var db = new ShopConnectionDB();

            var existingCartItem = GetCartItem(gioHangItem.MaSanPham);

            if (existingCartItem != null)
            {

                // Nếu sản phẩm đã tồn tại, cập nhật thông tin
               
                var giaSanPham = db.ExecuteScalar<int>("SELECT Gia FROM SanPham WHERE MaSanPham = @0", existingCartItem.MaSanPham);
               //Trừ đi số lượng cũ để cập nhật giá trị mới 
                existingCartItem.TongTien -= existingCartItem.SoLuong * giaSanPham;

                //cập nhật số lượng mới
                existingCartItem.SoLuong = gioHangItem.SoLuong;
                existingCartItem.TongTien += existingCartItem.SoLuong * giaSanPham;

                db.Update(existingCartItem);
            }
        }

        // lấy tổng số lượng đang có hiện thị ra view




        public static int TinhTongSoLuongGioHang()
        {
            var db = new ShopConnectionDB();
            int tongSoLuong = db.ExecuteScalar<int>("SELECT SUM(SoLuong) FROM GioHang");

            Debug.WriteLine($"Tong so luong: {tongSoLuong}"); // Sử dụng Debug.WriteLine để hiển thị giá trị trong Output window

            return tongSoLuong;
        }




        public static IEnumerable<GioHangViewModel> GetGioHangDetails()
        {
            var db = new ShopConnectionDB();

            var sql = @"
        SELECT
            GH.IdGH,
            GH.Id,
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