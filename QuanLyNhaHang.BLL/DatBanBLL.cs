using System;
using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class DatBanBLL
    {
        private static DatBanBLL? instance;
        public static DatBanBLL Instance => instance ??= new DatBanBLL();

        private DatBanBLL() { }

        public bool DatBan(int maBan, string tenKhach, string sdt, DateTime thoiGian, int soNguoi, string ghiChu, out string message)
        {
            if (string.IsNullOrWhiteSpace(tenKhach))
            {
                message = "Vui lòng nhập tên khách hàng!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sdt))
            {
                message = "Vui lòng nhập số điện thoại khách hàng!";
                return false;
            }

            if (soNguoi <= 0)
            {
                message = "Số lượng người phải lớn hơn 0!";
                return false;
            }

            DatBanDTO phieu = new DatBanDTO
            {
                MaBan = maBan,
                TenKhach = tenKhach.Trim(),
                SoDienThoai = sdt.Trim(),
                ThoiGianDat = thoiGian,
                SoNguoi = soNguoi,
                GhiChu = ghiChu?.Trim()
            };

            bool result = DatBanDAL.Instance.ThemDatBan(phieu);
            if (result)
            {
                message = "Đặt bàn thành công!";
                return true;
            }

            message = "Đặt bàn thất bại!";
            return false;
        }

        public DatBanDTO? GetPhieuDatBanHienTai(int maBan)
        {
            return DatBanDAL.Instance.GetPhieuDatBanHienTai(maBan);
        }

        public bool NhanBan(int maDatBan, int maBan)
        {
            return DatBanDAL.Instance.NhanBan(maDatBan, maBan);
        }

        public bool HuyDatBan(int maDatBan, int maBan)
        {
            return DatBanDAL.Instance.HuyDatBan(maDatBan, maBan);
        }
    }
}
