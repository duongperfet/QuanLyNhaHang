using System;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class HoaDonDAL
    {
        private static HoaDonDAL? instance;
        public static HoaDonDAL Instance
        {
            get => instance ??= new HoaDonDAL();
            private set => instance = value;
        }

        private HoaDonDAL() { }

        // Lấy mã hóa đơn chưa thanh toán của bàn (TrangThai = 0)
        public int GetMaHoaDonChuaThanhToanTheoBan(int maBan)
        {
            string query = "SELECT * FROM HoaDon WHERE MaBan = @maBan AND TrangThai = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maBan });

            if (data.Rows.Count > 0)
            {
                return (int)data.Rows[0]["MaHoaDon"];
            }
            return -1; // Không có hóa đơn chưa thanh toán
        }

        // Tạo hóa đơn mới cho bàn
        public int ThemHoaDon(int maBan)
        {
            string query = "INSERT INTO HoaDon (MaBan, NgayVao, TrangThai) VALUES ( @maBan , GETDATE(), 0); SELECT SCOPE_IDENTITY();";
            object? result = DataProvider.Instance.ExecuteScalar(query, new object[] { maBan });
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Thanh toán hóa đơn
        public bool ThanhToanHoaDon(int maHoaDon, int giamGia, decimal tongTien)
        {
            string query = "UPDATE HoaDon SET NgayRa = GETDATE(), GiamGia = @giamGia , TongTien = @tongTien , TrangThai = 1 WHERE MaHoaDon = @maHoaDon";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { giamGia, tongTien, maHoaDon });
            return result > 0;
        }

        public DataTable GetDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"SELECT h.MaHoaDon AS [Mã HĐ], b.TenBan AS [Bàn], h.NgayVao AS [Ngày vào], h.NgayRa AS [Ngày ra], h.GiamGia AS [Giảm giá (%)], h.TongTien AS [Tổng tiền (VNĐ)]
                             FROM HoaDon AS h
                             JOIN BanAn AS b ON h.MaBan = b.MaBan
                             WHERE h.TrangThai = 1 AND h.NgayRa >= @tuNgay AND h.NgayRa <= @denNgay
                             ORDER BY h.NgayRa DESC";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { tuNgay, denNgay });
        }
    }
}
