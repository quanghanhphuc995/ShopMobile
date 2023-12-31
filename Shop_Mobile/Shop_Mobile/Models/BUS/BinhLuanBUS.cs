﻿using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Mobile.Models.BUS
{
    public class BinhLuanBUS
    {
        //-----------------------Insert Bình luận-----------------------------------
        public static void AddBinhLuan(string maSanPham, string userId, string noiDung, string userName )
        {
            var db = new ShopConnectionDB();
            var binhLuan = new BinhLuan
            {
                MaSanPham = maSanPham,
                UserID = userId,
                NoiDung = noiDung,
                UserName = userName,
                Ngay = DateTime.Now
            };
            db.Insert(binhLuan);
        }
        //-----------------------Get Bình luận-----------------------------------
        public static BinhLuan GetBinhLuan(string userId)
        {
            var db = new ShopConnectionDB();
            var query = "SELECT TOP 1 * FROM BinhLuan WHERE UserID = @UserID ORDER BY Ngay DESC";
            var parameters = new { UserID = userId};
            var resul = db.FirstOrDefault<BinhLuan>(query, parameters);
            return resul;

        }
        public static List<BinhLuan> GetTatCaBinhLuan(string maSanPham)
        {
            var db = new ShopConnectionDB();
            var query = "SELECT * FROM BinhLuan WHERE MaSanPham = @MaSanPham ORDER BY Ngay DESC";
            var parameters = new { MaSanPham = maSanPham };
            var result = db.Query<BinhLuan>(query,parameters).ToList();
            return result;
        }
        public static BinhLuan FindById(int binhluanID)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<BinhLuan>("WHERE BinhLuanID = @0", binhluanID);    
        }

        public static bool TangLuotLike(int binhluanID)
        {
            var db = new ShopConnectionDB();
            var binhluan = db.SingleOrDefault<BinhLuan>("where BinhLuanID = @0", binhluanID);

            if (binhluan!=null)
            {
                if (binhluan.LuotLike==null)
                {
                    binhluan.LuotLike = 0;
                }
                binhluan.LuotLike++;
                db.Update(binhluan);
                return true;
            }
            return false;
        }
        public static void AddPhanHoiBL(int binhLuanID, string noiDungPhanHoi, string userId, string userName)
        {
            var db = new ShopConnectionDB();
            var phanhoiBL = new PhanHoiBL
            {
                
                BinhLuanID = binhLuanID,
                NoiDungPhanHoi = noiDungPhanHoi,
                UserID = userId,
                UserName = userName,
                Ngay = DateTime.Now
            };
            db.Insert(phanhoiBL);
            
        }

        public static List<PhanHoiBL> GetTatCaPhanHoiBL(int binhLuanID)
        {
            var db = new ShopConnectionDB();
            var query = "Select * From PhanHoiBL Where BinhLuanID = @BinhLuanID ORDER BY Ngay DESC";
            var parameters = new { BinhLuanID = binhLuanID };
            var result = db.Query<PhanHoiBL>(query, parameters).ToList();
            return result;
        }
    }
}