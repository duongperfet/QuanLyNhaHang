using System.Collections.Generic;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class BanAnDAL
    {
        private static BanAnDAL? instance;
        public static BanAnDAL Instance
        {
            get => instance ??= new BanAnDAL();
            private set => instance = value;
        }

        private BanAnDAL() { }

        public List<BanAnDTO> GetDanhSachBanAn()
        {
            List<BanAnDTO> list = new List<BanAnDTO>();
            string query = "SELECT * FROM BanAn ORDER BY MaBan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BanAnDTO table = new BanAnDTO(item);
                list.Add(table);
            }
            return list;
        }

        public bool CapNhatTrangThaiBan(int maBan, string trangThai)
        {
            string query = "UPDATE BanAn SET TrangThai = @trangThai WHERE MaBan = @maBan";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { trangThai, maBan });
            return result > 0;
        }

        public bool ChuyenBan(int maBanCu, int maBanMoi)
        {
            // 1. Lấy mã hóa đơn chưa thanh toán của bàn cũ
            int maHoaDon = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBanCu);
            if (maHoaDon == -1) return false;

            // 2. Chuyển mã bàn trong hóa đơn sang bàn mới
            string queryUpdateHD = "UPDATE HoaDon SET MaBan = @maBanMoi WHERE MaHoaDon = @maHoaDon";
            DataProvider.Instance.ExecuteNonQuery(queryUpdateHD, new object[] { maBanMoi, maHoaDon });

            // 3. Cập nhật trạng thái 2 bàn
            CapNhatTrangThaiBan(maBanMoi, "Có người");
            CapNhatTrangThaiBan(maBanCu, "Trống");

            return true;
        }

        public bool GopBan(int maBanNguon, int maBanDich)
        {
            int maHDNguon = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBanNguon);
            int maHDDich = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBanDich);

            if (maHDNguon == -1 || maHDDich == -1) return false;

            // 1. Chuyển và cộng dồn toàn bộ món từ hóa đơn nguồn sang hóa đơn đích
            string queryGetMonNguon = "SELECT MaMon, SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @maHDNguon";
            DataTable dtMonNguon = DataProvider.Instance.ExecuteQuery(queryGetMonNguon, new object[] { maHDNguon });

            foreach (DataRow row in dtMonNguon.Rows)
            {
                int maMon = (int)row["MaMon"];
                int soLuong = (int)row["SoLuong"];
                ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(maHDDich, maMon, soLuong);
            }

            // 2. Xóa chi tiết hóa đơn cũ và xóa hóa đơn của bàn nguồn
            string queryDeleteCTHD = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @maHDNguon";
            DataProvider.Instance.ExecuteNonQuery(queryDeleteCTHD, new object[] { maHDNguon });

            string queryDeleteHD = "DELETE FROM HoaDon WHERE MaHoaDon = @maHDNguon";
            DataProvider.Instance.ExecuteNonQuery(queryDeleteHD, new object[] { maHDNguon });

            // 3. Cập nhật trạng thái bàn
            CapNhatTrangThaiBan(maBanDich, "Có người");
            CapNhatTrangThaiBan(maBanNguon, "Trống");

            return true;
        }
    }
}
