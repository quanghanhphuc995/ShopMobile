using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class ShopOnlineBUS
    {
        //--------------------- khách hàng-----------------------------
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham where TinhTrang=0");
        }
        public static SanPham ChiTietSP(String a)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<SanPham>("select * from SanPham where MaSanPham=@0",a);
        }

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

        public static void ThemSP(SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Insert(sp);
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

            public static int XoaSP(string id)
            {
                var db = new ShopConnectionDB();
                return db.Execute("delete from SanPham where MaSanPham = @0", id);
            }
    }
}