using System;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class HoaDonDAL
    {
        private static HoaDonDAL? _instance;
        public static HoaDonDAL Instance
        {
            get
            {
                if (_instance == null) _instance = new HoaDonDAL();
                return _instance;
            }
        }

        private HoaDonDAL() { }

        // Lấy mã hóa đơn chưa thanh toán (TrangThai = 0) của một bàn
        public int GetMaHoaDonChuaThanhToanTheoBan(int maBan)
        {
            string query = "SELECT MaHoaDon FROM HoaDon WHERE MaBan = @maBan AND TrangThai = 0";
            object? result = DataProvider.Instance.ExecuteScalar(query, new object[] { maBan });
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Tạo hóa đơn mới cho bàn khi có khách gọi món
        public int ThemHoaDon(int maBan)
        {
            string query = "INSERT INTO HoaDon (MaBan, NgayVao, TrangThai) OUTPUT INSERTED.MaHoaDon VALUES ( @maBan , GETDATE(), 0)";
            object? result = DataProvider.Instance.ExecuteScalar(query, new object[] { maBan });
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Lấy thông tin hóa đơn theo mã
        public int GetMaBanTheoHoaDon(int maHoaDon)
        {
            string query = "SELECT MaBan FROM HoaDon WHERE MaHoaDon = @maHoaDon";
            object? result = DataProvider.Instance.ExecuteScalar(query, new object[] { maHoaDon });
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Thanh toán hóa đơn (hỗ trợ lưu Phương thức thanh toán: Tiền mặt hoặc Chuyển khoản QR)
        public bool ThanhToanHoaDon(int maHoaDon, int giamGia, decimal tongTien, string phuongThuc = "Tiền mặt")
        {
            try
            {
                string query = "UPDATE HoaDon SET NgayRa = GETDATE(), GiamGia = @giamGia , TongTien = @tongTien , TrangThai = 1, PhuongThucThanhToan = @phuongThuc WHERE MaHoaDon = @maHoaDon";
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { giamGia, tongTien, phuongThuc, maHoaDon });
                return result > 0;
            }
            catch
            {
                string fallbackQuery = "UPDATE HoaDon SET NgayRa = GETDATE(), GiamGia = @giamGia , TongTien = @tongTien , TrangThai = 1 WHERE MaHoaDon = @maHoaDon";
                int result = DataProvider.Instance.ExecuteNonQuery(fallbackQuery, new object[] { giamGia, tongTien, maHoaDon });
                return result > 0;
            }
        }

        public DataTable GetDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"SELECT h.MaHoaDon AS [Mã HĐ], b.TenBan AS [Bàn], h.NgayVao AS [Ngày vào], h.NgayRa AS [Ngày ra], 
                                    ISNULL(h.PhuongThucThanhToan, N'Tiền mặt') AS [Phương thức],
                                    h.GiamGia AS [Giảm giá (%)], h.TongTien AS [Tổng tiền (VNĐ)]
                             FROM HoaDon AS h
                             JOIN BanAn AS b ON h.MaBan = b.MaBan
                             WHERE h.TrangThai = 1 AND h.NgayRa >= @tuNgay AND h.NgayRa <= @denNgay
                             ORDER BY h.NgayRa DESC";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { tuNgay, denNgay });
            }
            catch
            {
                string fallback = @"SELECT h.MaHoaDon AS [Mã HĐ], b.TenBan AS [Bàn], h.NgayVao AS [Ngày vào], h.NgayRa AS [Ngày ra], h.GiamGia AS [Giảm giá (%)], h.TongTien AS [Tổng tiền (VNĐ)]
                                   FROM HoaDon AS h
                                   JOIN BanAn AS b ON h.MaBan = b.MaBan
                                   WHERE h.TrangThai = 1 AND h.NgayRa >= @tuNgay AND h.NgayRa <= @denNgay
                                   ORDER BY h.NgayRa DESC";
                return DataProvider.Instance.ExecuteQuery(fallback, new object[] { tuNgay, denNgay });
            }
        }
    }
}
