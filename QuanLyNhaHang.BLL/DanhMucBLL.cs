using System.Collections.Generic;
using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class DanhMucBLL
    {
        private static DanhMucBLL? instance;
        public static DanhMucBLL Instance => instance ??= new DanhMucBLL();

        private DanhMucBLL() { }

        public List<DanhMucDTO> GetDanhSachDanhMuc()
        {
            return DanhMucDAL.Instance.GetDanhSachDanhMuc();
        }
    }
}
