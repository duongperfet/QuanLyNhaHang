using System.Collections.Generic;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class MonAnDAL
    {
        private static MonAnDAL? instance;
        public static MonAnDAL Instance
        {
            get => instance ??= new MonAnDAL();
            private set => instance = value;
        }

        private MonAnDAL() { }

        public List<MonAnDTO> GetMonAnTheoDanhMuc(int maDanhMuc)
        {
            List<MonAnDTO> list = new List<MonAnDTO>();
            string query = "SELECT * FROM MonAn WHERE MaDanhMuc = @maDanhMuc ORDER BY TenMon";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maDanhMuc });

            foreach (DataRow item in data.Rows)
            {
                MonAnDTO food = new MonAnDTO(item);
                list.Add(food);
            }
            return list;
        }

        public DataTable GetAllMonAn()
        {
            string query = @"SELECT m.MaMon AS [Mã món], m.TenMon AS [Tên món], d.TenDanhMuc AS [Danh mục], m.DonGia AS [Đơn giá], m.DonViTinh AS [Đơn vị tính], m.MaDanhMuc
                             FROM MonAn AS m
                             JOIN DanhMuc AS d ON m.MaDanhMuc = d.MaDanhMuc
                             ORDER BY m.MaMon DESC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool ThemMonAn(string tenMon, int maDanhMuc, decimal donGia, string donViTinh)
        {
            string query = "INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia, DonViTinh) VALUES ( @tenMon , @maDanhMuc , @donGia , @donViTinh )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenMon, maDanhMuc, donGia, donViTinh });
            return result > 0;
        }

        public bool SuaMonAn(int maMon, string tenMon, int maDanhMuc, decimal donGia, string donViTinh)
        {
            string query = "UPDATE MonAn SET TenMon = @tenMon , MaDanhMuc = @maDanhMuc , DonGia = @donGia , DonViTinh = @donViTinh WHERE MaMon = @maMon";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenMon, maDanhMuc, donGia, donViTinh, maMon });
            return result > 0;
        }

        public bool XoaMonAn(int maMon)
        {
            string query = "DELETE FROM MonAn WHERE MaMon = @maMon";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMon });
            return result > 0;
        }
    }
}
