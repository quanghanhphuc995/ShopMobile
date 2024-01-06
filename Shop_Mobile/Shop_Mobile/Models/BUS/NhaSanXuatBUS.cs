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