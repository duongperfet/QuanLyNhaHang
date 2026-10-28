using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL? instance;
        public static TaiKhoanDAL Instance
        {
            get => instance ??= new TaiKhoanDAL();
            private set => instance = value;
        }

        private TaiKhoanDAL() { }

        public TaiKhoanDTO? DangNhap(string tenDangNhap, string matKhau)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap, matKhau });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new TaiKhoanDTO
                {
                    TenDangNhap = row["TenDangNhap"].ToString() ?? "",
                    MatKhau = row["MatKhau"].ToString() ?? "",
                    HoTen = row["HoTen"].ToString() ?? "",
                    LoaiTaiKhoan = (int)row["LoaiTaiKhoan"]
                };
            }
            return null;
        }

        public DataTable GetDanhSachTaiKhoan()
        {
            string query = @"SELECT TenDangNhap AS [Tên đăng nhập], HoTen AS [Họ tên], 
                                    CASE WHEN LoaiTaiKhoan = 1 THEN N'Quản lý' ELSE N'Nhân viên' END AS [Vai trò],
                                    LoaiTaiKhoan
                             FROM TaiKhoan
                             ORDER BY LoaiTaiKhoan DESC, TenDangNhap ASC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string hoTen, int loaiTaiKhoan)
        {
            string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, LoaiTaiKhoan) VALUES ( @tenDangNhap , @matKhau , @hoTen , @loaiTaiKhoan )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenDangNhap, matKhau, hoTen, loaiTaiKhoan });
            return result > 0;
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = @matKhau WHERE TenDangNhap = @tenDangNhap";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matKhauMoi, tenDangNhap });
            return result > 0;
        }

        public bool XoaTaiKhoan(string tenDangNhap)
        {
            string query = "DELETE FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenDangNhap });
            return result > 0;
        }
    }
}
