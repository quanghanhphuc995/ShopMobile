using ShopConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        //-------------------Khách hàng--------------------
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham where TinhTrang = 0");
        }

        public static IEnumerable<SanPham> LoaiSanPham(String id)
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaLoaiSanPham ='"+id+"'");
        }

        //-----------------------Admin-----------------------------
        //--------------Load Danh Sách Loại Sản Phẩm lên trang Index----------------
        public static IEnumerable<LoaiSanPham> DanhSachAdmin()
        {
            var db = new ShopConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham");
        }
        //-------------Thêm mới Loại sản phẩm------------------
        public static void ThemLSP(LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Insert(lsp);
        }
        //-----------------Update Loại Sản phẩm----------------
        public static void UpdateLSP(string id, LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Update(lsp, id);
        }

        //--------------- hiển thị trang chi tiết Edit------------------
        public static LoaiSanPham ChitietLSPAdmin(String id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<LoaiSanPham>("select * from LoaiSanPham where MaLoaiSanPham = '" + id + "'");
        }

       
    }
}