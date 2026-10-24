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
    }
}
