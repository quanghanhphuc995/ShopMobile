using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class NhaSanXuatBUS
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat where TinhTrang = 0");
        }

        public static IEnumerable<SanPham> Chitiet(String id)
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaNhaSanXuat ='"+id+"'");
        }
    }
}