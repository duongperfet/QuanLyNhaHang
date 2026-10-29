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
                message = "Bàn đích đang có khách ngồi! Hãy chọn bàn còn trống để chuyển, hoặc dùng chức năng Gộp bàn.";
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

        public bool GopBan(int maBanNguon, int maBanDich, out string message)
        {
            if (maBanNguon == maBanDich)
            {
                message = "Không thể gộp vào chính bàn đang chọn!";
                return false;
            }

            List<BanAnDTO> danhSachBan = GetDanhSachBanAn();
            BanAnDTO? banNguon = danhSachBan.Find(ban => ban.MaBan == maBanNguon);
            BanAnDTO? banDich = danhSachBan.Find(ban => ban.MaBan == maBanDich);

            if (banNguon?.TrangThai != "Có người")
            {
                message = "Bàn nguồn phải đang có khách mới có thể gộp!";
                return false;
            }

            if (banDich?.TrangThai != "Có người")
            {
                message = "Bàn đích chưa có khách. Chỉ có thể gộp khi cả hai bàn đều đang có khách!";
                return false;
            }

            int maHDNguon = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBanNguon);
            if (maHDNguon == -1)
            {
                message = "Bàn nguồn không có món ăn hoặc hóa đơn nào để gộp!";
                return false;
            }

            int maHDDich = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBanDich);
            if (maHDDich == -1)
            {
                message = "Bàn đích chưa có hóa đơn chưa thanh toán để nhận món gộp!";
                return false;
            }

            bool result = BanAnDAL.Instance.GopBan(maBanNguon, maBanDich);
            if (result)
            {
                message = "Gộp bàn thành công! Toàn bộ món ăn đã được chuyển sang bàn đích.";
                return true;
            }

            message = "Có lỗi xảy ra trong quá trình gộp bàn!";
            return false;
        }
    }
}
