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
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat");
        }
        
     
        public static IEnumerable<SanPham> Chitiet(String id)
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaNhaSanXuat = @0",id);
        }

        //------------------------Admin------------------

        //add
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
            db.Delete("NhaSanXuat","id","null",id);
        }
        //----------------hien thi danh sach nsx tat ca tinh trang------------
        public static IEnumerable<NhaSanXuat> DanhSachAdmin()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat");
        }
        //------------------- lay tat ca thong tin de truyen vao from input truyen cho view edit---------------
        public static NhaSanXuat ChitietSPAdmin( String id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<NhaSanXuat>("select * from NhaSanXuat where MaNhaSanXuat = @0", id);
        }

        
    }
}