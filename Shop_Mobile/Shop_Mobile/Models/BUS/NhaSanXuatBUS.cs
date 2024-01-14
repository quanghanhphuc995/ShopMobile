using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    
    public class NhaSanXuatBUS
    {
        //---------------------------khach hang-----------------------
        public static IEnumerable<NhaSanXuat> DanhSachNSX()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("Select * From NhaSanXuat");
        }
        //------------------------Admin------------------
        public static IEnumerable<SanPham> SanPhamChiTietNSX(String id)
        {
            var db = new ShopConnectionDB();

            // Sử dụng INNER JOIN để nối bảng SanPham và NhaSanXuat dựa trên MaNhaSanXuat
            var query = "SELECT SanPham.* FROM SanPham INNER JOIN NhaSanXuat ON SanPham.MaNhaSanXuat = NhaSanXuat.MaNhaSanXuat WHERE NhaSanXuat.MaNhaSanXuat = @0";

            return db.Query<SanPham>(query, id);
        }

        public static IEnumerable<NhaSanXuat> DanhSachAdmin()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("Select * From NhaSanXuat");
        }
        public static void ThemNSX(NhaSanXuat nsx)
        {
            var db = new ShopConnectionDB();
            db.Insert(nsx);
        }
        
        //Update
        public static void UpadateNSX(String id, NhaSanXuat nsx) 
        {
            var db = new ShopConnectionDB();
            db.Update(nsx, id);
        }

        public static void DeleteNSX(string id)
        {
            var db = new ShopConnectionDB();
            db.Execute("Delete From NhaSanXuat Where MaNhaSanXuat = @0", id);
        }
        
        
        //------------------- lay tat ca thong tin de truyen vao from input truyen cho view edit---------------
        public static NhaSanXuat ChitietSPAdmin( String id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<NhaSanXuat>("select * from NhaSanXuat where MaNhaSanXuat = @0", id);
        }
    }
}