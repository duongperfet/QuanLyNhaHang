using System;
using System.Collections.Generic;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class DatBanDAL
    {
        private static DatBanDAL? instance;
        public static DatBanDAL Instance
        {
            get => instance ??= new DatBanDAL();
            private set => instance = value;
        }

        private DatBanDAL() { }

        // Thêm phiếu đặt bàn mới
        public bool ThemDatBan(DatBanDTO datBan)
        {
            string query = @"INSERT INTO DatBan (MaBan, TenKhach, SoDienThoai, ThoiGianDat, SoNguoi, GhiChu, TrangThai)
                             VALUES ( @maBan , @tenKhach , @sdt , @thoiGian , @soNguoi , @ghiChu , N'Đã đặt' )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {
                datBan.MaBan,
                datBan.TenKhach,
                datBan.SoDienThoai,
                datBan.ThoiGianDat,
                datBan.SoNguoi,
                datBan.GhiChu ?? ""
            });

            if (result > 0)
            {
                // Cập nhật trạng thái bàn sang "Đã đặt"
                BanAnDAL.Instance.CapNhatTrangThaiBan(datBan.MaBan, "Đã đặt");
                return true;
            }
            return false;
        }

        // Lấy phiếu đặt bàn đang chờ của bàn
        public DatBanDTO? GetPhieuDatBanHienTai(int maBan)
        {
            string query = "SELECT TOP 1 * FROM DatBan WHERE MaBan = @maBan AND TrangThai = N'Đã đặt' ORDER BY MaDatBan DESC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maBan });

            if (data.Rows.Count > 0)
            {
                return new DatBanDTO(data.Rows[0]);
            }
            return null;
        }

        // Nhận bàn: Khách đã đến -> Chuyển trạng thái phiếu đặt và bàn thành "Có người"
        public bool NhanBan(int maDatBan, int maBan)
        {
            string query = "UPDATE DatBan SET TrangThai = N'Đã nhận bàn' WHERE MaDatBan = @maDatBan";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDatBan });

            if (result > 0)
            {
                BanAnDAL.Instance.CapNhatTrangThaiBan(maBan, "Có người");
                return true;
            }
            return false;
        }

        // Hủy đặt bàn
        public bool HuyDatBan(int maDatBan, int maBan)
        {
            string query = "UPDATE DatBan SET TrangThai = N'Đã hủy' WHERE MaDatBan = @maDatBan";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maDatBan });

            if (result > 0)
            {
                BanAnDAL.Instance.CapNhatTrangThaiBan(maBan, "Trống");
                return true;
            }
            return false;
        }
    }
}
