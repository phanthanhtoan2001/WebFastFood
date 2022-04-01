using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFood.Models
{
    public class GioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string HinhAnh { get; set; }
        public string size { get; set; }
       
        public GioHang(int iMaSP)
        {
            using (Mydata db = new Mydata())
            {
                this.MaSP = iMaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
                this.TenSP = sp.Tensp;
                this.HinhAnh = sp.Hinhanh;
                this.DonGia = sp.Dongia.Value;
                this.SoLuong = 1;
                this.ThanhTien = DonGia * SoLuong;
            }
        }
        public GioHang(int iMaSP, int sl)
        {
            using (Mydata db = new Mydata())
            {
                this.MaSP = iMaSP;
                SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
                this.TenSP = sp.Tensp;
                this.HinhAnh = sp.Hinhanh;
                this.DonGia = sp.Dongia.Value;
                this.SoLuong = sl;
                this.ThanhTien = DonGia * SoLuong;
            }
        }
    }
}