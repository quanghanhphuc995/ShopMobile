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
    }
}