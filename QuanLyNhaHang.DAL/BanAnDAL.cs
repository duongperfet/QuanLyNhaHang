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
    }
}
