using System;
using System.Data;
using System.Collections.Generic;
using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL? instance;
        public static HoaDonBLL Instance => instance ??= new HoaDonBLL();

        private HoaDonBLL() { }

        public List<MenuOrderDTO> GetDanhSachMenuTheoBan(int maBan)
        {
            return ChiTietHoaDonDAL.Instance.GetDanhSachMenuTheoBan(maBan);
        }

        public int GetMaHoaDonChuaThanhToanTheoBan(int maBan)
        {
            return HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBan);
        }

        public void ThemMon(int maBan, int maMon, int soLuong)
        {
            int maHoaDon = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBan);

            // Nếu bàn chưa có hóa đơn thì tạo hóa đơn mới
            if (maHoaDon == -1)
            {
                maHoaDon = HoaDonDAL.Instance.ThemHoaDon(maBan);
                // Cập nhật trạng thái bàn sang "Có người"
                BanAnDAL.Instance.CapNhatTrangThaiBan(maBan, "Có người");
            }

            ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(maHoaDon, maMon, soLuong);

            // Kiểm tra nếu danh sách món sau khi thêm/bớt rỗng thì cập nhật lại bàn thành "Trống"
            var list = ChiTietHoaDonDAL.Instance.GetDanhSachMenuTheoBan(maBan);
            if (list.Count == 0)
            {
                BanAnDAL.Instance.CapNhatTrangThaiBan(maBan, "Trống");
            }
        }

        public bool ThanhToan(int maBan, int giamGia, out decimal tongTienTruocGiam, out decimal tongTienSauGiam, string phuongThuc = "Tiền mặt")
        {
            tongTienTruocGiam = 0;
            tongTienSauGiam = 0;

            int maHoaDon = HoaDonDAL.Instance.GetMaHoaDonChuaThanhToanTheoBan(maBan);
            if (maHoaDon == -1) return false;

            var listMenu = ChiTietHoaDonDAL.Instance.GetDanhSachMenuTheoBan(maBan);
            foreach (var item in listMenu)
            {
                tongTienTruocGiam += item.ThanhTien;
            }

            // Tính tiền sau giảm giá
            tongTienSauGiam = tongTienTruocGiam - (tongTienTruocGiam * giamGia / 100);

            // Cập nhật hóa đơn sang Đã thanh toán (TrangThai = 1) kèm phương thức
            bool result = HoaDonDAL.Instance.ThanhToanHoaDon(maHoaDon, giamGia, tongTienSauGiam, phuongThuc);
            if (result)
            {
                // Trả bàn về trạng thái Trống
                BanAnDAL.Instance.CapNhatTrangThaiBan(maBan, "Trống");
                return true;
            }

            return false;
        }

        public DataTable GetDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return HoaDonDAL.Instance.GetDoanhThuTheoNgay(tuNgay, denNgay);
        }
    }
}
