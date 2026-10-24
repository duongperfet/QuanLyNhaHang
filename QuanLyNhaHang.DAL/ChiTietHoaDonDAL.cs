using System;
using System.Collections.Generic;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class ChiTietHoaDonDAL
    {
        private static ChiTietHoaDonDAL? instance;
        public static ChiTietHoaDonDAL Instance
        {
            get => instance ??= new ChiTietHoaDonDAL();
            private set => instance = value;
        }

        private ChiTietHoaDonDAL() { }

        // Lấy danh sách món ăn đang gọi của bàn (kèm số lượng, giá, thành tiền)
        public List<MenuOrderDTO> GetDanhSachMenuTheoBan(int maBan)
        {
            List<MenuOrderDTO> listMenu = new List<MenuOrderDTO>();

            string query = @"SELECT m.TenMon, c.SoLuong, m.DonGia, (c.SoLuong * m.DonGia) AS ThanhTien
                             FROM ChiTietHoaDon AS c
                             JOIN HoaDon AS h ON c.MaHoaDon = h.MaHoaDon
                             JOIN MonAn AS m ON c.MaMon = m.MaMon
                             WHERE h.TrangThai = 0 AND h.MaBan = @maBan";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maBan });

            foreach (DataRow item in data.Rows)
            {
                MenuOrderDTO menu = new MenuOrderDTO(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }

        // Thêm món vào hóa đơn (nếu món đã có thì cộng dồn số lượng)
        public void ThemChiTietHoaDon(int maHoaDon, int maMon, int soLuong)
        {
            // Kiểm tra món đã có trong hóa đơn chưa
            string queryCheck = "SELECT SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon AND MaMon = @maMon";
            object? result = DataProvider.Instance.ExecuteScalar(queryCheck, new object[] { maHoaDon, maMon });

            if (result != null)
            {
                int soLuongCu = Convert.ToInt32(result);
                int soLuongMoi = soLuongCu + soLuong;

                if (soLuongMoi > 0)
                {
                    string queryUpdate = "UPDATE ChiTietHoaDon SET SoLuong = @soLuong WHERE MaHoaDon = @maHoaDon AND MaMon = @maMon";
                    DataProvider.Instance.ExecuteNonQuery(queryUpdate, new object[] { soLuongMoi, maHoaDon, maMon });
                }
                else
                {
                    // Nếu số lượng giảm về <= 0 thì xóa món khỏi hóa đơn
                    string queryDelete = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon AND MaMon = @maMon";
                    DataProvider.Instance.ExecuteNonQuery(queryDelete, new object[] { maHoaDon, maMon });
                }
            }
            else if (soLuong > 0)
            {
                string queryInsert = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong) VALUES ( @maHoaDon , @maMon , @soLuong )";
                DataProvider.Instance.ExecuteNonQuery(queryInsert, new object[] { maHoaDon, maMon, soLuong });
            }
        }
    }
}
