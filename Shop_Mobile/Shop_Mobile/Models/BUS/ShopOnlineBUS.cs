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

        
    }
}