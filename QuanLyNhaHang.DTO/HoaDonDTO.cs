using System;
using System.Data;

namespace QuanLyNhaHang.DTO
{
    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public int MaBan { get; set; }
        public DateTime NgayVao { get; set; }
        public DateTime? NgayRa { get; set; }
        public int GiamGia { get; set; } = 0;
        public decimal TongTien { get; set; } = 0;
        public int TrangThai { get; set; } // 0: Chưa thanh toán, 1: Đã thanh toán

        public HoaDonDTO() { }

        public HoaDonDTO(DataRow row)
        {
            this.MaHoaDon = (int)row["MaHoaDon"];
            this.MaBan = (int)row["MaBan"];
            this.NgayVao = Convert.ToDateTime(row["NgayVao"]);
            if (row["NgayRa"] != DBNull.Value)
            {
                this.NgayRa = Convert.ToDateTime(row["NgayRa"]);
            }
            this.GiamGia = (int)row["GiamGia"];
            this.TongTien = Convert.ToDecimal(row["TongTien"]);
            this.TrangThai = (int)row["TrangThai"];
        }
    }
}
