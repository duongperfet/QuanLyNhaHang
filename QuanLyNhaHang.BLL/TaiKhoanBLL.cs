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
    }
}
