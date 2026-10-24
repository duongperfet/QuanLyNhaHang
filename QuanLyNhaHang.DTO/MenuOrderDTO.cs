using System;
using System.Data;

namespace QuanLyNhaHang.DTO
{
    public class MenuOrderDTO
    {
        public string TenMon { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public MenuOrderDTO() { }

        public MenuOrderDTO(string tenMon, int soLuong, decimal donGia, decimal thanhTien = 0)
        {
            this.TenMon = tenMon;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public MenuOrderDTO(DataRow row)
        {
            this.TenMon = row["TenMon"].ToString() ?? string.Empty;
            this.SoLuong = (int)row["SoLuong"];
            this.DonGia = Convert.ToDecimal(row["DonGia"]);
            this.ThanhTien = Convert.ToDecimal(row["ThanhTien"]);
        }
    }
}
