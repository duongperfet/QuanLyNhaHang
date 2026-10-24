using System.Collections.Generic;
using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class BanAnBLL
    {
        private static BanAnBLL? instance;
        public static BanAnBLL Instance => instance ??= new BanAnBLL();

        private BanAnBLL() { }

        public List<BanAnDTO> GetDanhSachBanAn()
        {
            return BanAnDAL.Instance.GetDanhSachBanAn();
        }

        public bool ChuyenBan(int maBanCu, int maBanMoi, out string message)
        {
            if (maBanCu == maBanMoi)
            {
                message = "Không thể chuyển sang chính bàn hiện tại!";
                return false;
            }

            int maHD = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBanCu);
            if (maHD == -1)
            {
                message = "Bàn hiện tại không có món ăn hoặc hóa đơn nào để chuyển!";
                return false;
            }

            // Kiểm tra bàn mới có đang có khách không
            int maHDMoi = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBanMoi);
            if (maHDMoi != -1)
            {
                message = "Bàn đích đang có khách ngồi! Hãy chọn bàn còn trống để chuyển.";
                return false;
            }

            bool result = BanAnDAL.Instance.ChuyenBan(maBanCu, maBanMoi);
            if (result)
            {
                message = "Chuyển bàn thành công!";
                return true;
            }

            message = "Có lỗi xảy ra khi chuyển bàn!";
            return false;
        }
    }
}
