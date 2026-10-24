using System;

namespace QuanLyNhaHang.DTO
{
    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public int LoaiTaiKhoan { get; set; } // 1: Quản lý, 0: Nhân viên
    }
}
