using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopConnection;

namespace Shop_Mobile.Models.BUS
{
    public class AspNetUserss
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int LockoutEnabled { get; set; }
    }
    public class Order
    {

    }
    public class Comment
    {
        public string UserName { get; set; }
        public string NoiDung { get; set; }
        public DateTime? Ngay { get; set; }
        public string TenSanPham { get; set; }
    }
    public class DataBUS
    {
        public static IEnumerable<AspNetUserss> QuanLyTK()
        {
            var db = new ShopConnectionDB();
            return db.Query<AspNetUserss>("Select * From AspNetUsers Where LockoutEnabled = 1");
        }

        public static void XoaTKKhachHang(string id)
        {
            var db = new ShopConnectionDB();
            db.Execute("Delete From AspNetUsers Where Id = @0", id);
        }
        public static Comment Top1Comment()
        {
            var db = new ShopConnectionDB();
            var query = @"Select Top 1 b.*, s.TenSanPham From BinhLuan b Inner Join SanPham s On b.MaSanPham = s.MaSanPham
                        Order By b.Ngay Desc";
            return db.SingleOrDefault<Comment>(query);
        }
    }
}