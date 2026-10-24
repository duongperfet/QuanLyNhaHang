using System;
using System.Data;

namespace QuanLyNhaHang.DTO
{
    public class MonAnDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = string.Empty;
        public int MaDanhMuc { get; set; }
        public decimal DonGia { get; set; }
        public string DonViTinh { get; set; } = "Đĩa";

        public MonAnDTO() { }

        public MonAnDTO(int maMon, string tenMon, int maDanhMuc, decimal donGia, string donViTinh)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.MaDanhMuc = maDanhMuc;
            this.DonGia = donGia;
            this.DonViTinh = donViTinh;
        }

        public MonAnDTO(DataRow row)
        {
            this.MaMon = (int)row["MaMon"];
            this.TenMon = row["TenMon"].ToString() ?? string.Empty;
            this.MaDanhMuc = (int)row["MaDanhMuc"];
            this.DonGia = Convert.ToDecimal(row["DonGia"]);
            this.DonViTinh = row["DonViTinh"].ToString() ?? "Đĩa";
        }
    }
}
