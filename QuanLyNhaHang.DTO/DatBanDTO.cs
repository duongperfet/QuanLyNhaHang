using System;
using System.Data;

namespace QuanLyNhaHang.DTO
{
    public class DatBanDTO
    {
        public int MaDatBan { get; set; }
        public int MaBan { get; set; }
        public string TenKhach { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public DateTime ThoiGianDat { get; set; } = DateTime.Now;
        public int SoNguoi { get; set; } = 2;
        public string? GhiChu { get; set; }
        public string TrangThai { get; set; } = "Đã đặt"; // Đã đặt, Đã nhận bàn, Đã hủy

        public DatBanDTO() { }

        public DatBanDTO(DataRow row)
        {
            this.MaDatBan = (int)row["MaDatBan"];
            this.MaBan = (int)row["MaBan"];
            this.TenKhach = row["TenKhach"].ToString() ?? string.Empty;
            this.SoDienThoai = row["SoDienThoai"].ToString() ?? string.Empty;
            this.ThoiGianDat = Convert.ToDateTime(row["ThoiGianDat"]);
            this.SoNguoi = (int)row["SoNguoi"];
            this.GhiChu = row["GhiChu"]?.ToString();
            this.TrangThai = row["TrangThai"].ToString() ?? "Đã đặt";
        }
    }
}
