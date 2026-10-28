using System.Data;
using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class TaiKhoanBLL
    {
        private static TaiKhoanBLL? instance;
        public static TaiKhoanBLL Instance => instance ??= new TaiKhoanBLL();

        private TaiKhoanBLL() { }

        public TaiKhoanDTO? DangNhap(string user, string pass)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                return null;
            }
            return TaiKhoanDAL.Instance.DangNhap(user.Trim(), pass.Trim());
        }

        public DataTable GetDanhSachTaiKhoan()
        {
            return TaiKhoanDAL.Instance.GetDanhSachTaiKhoan();
        }

        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string hoTen, int loaiTaiKhoan)
        {
            return TaiKhoanDAL.Instance.ThemTaiKhoan(tenDangNhap, matKhau, hoTen, loaiTaiKhoan);
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            return TaiKhoanDAL.Instance.DoiMatKhau(tenDangNhap, matKhauMoi);
        }

        public bool XoaTaiKhoan(string tenDangNhap)
        {
            return TaiKhoanDAL.Instance.XoaTaiKhoan(tenDangNhap);
        }
    }
}
