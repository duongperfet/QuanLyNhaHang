using System.Data;
using System.Collections.Generic;
using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class MonAnBLL
    {
        private static MonAnBLL? instance;
        public static MonAnBLL Instance => instance ??= new MonAnBLL();

        private MonAnBLL() { }

        public List<MonAnDTO> GetMonAnTheoDanhMuc(int maDanhMuc)
        {
            return MonAnDAL.Instance.GetMonAnTheoDanhMuc(maDanhMuc);
        }

        public DataTable GetAllMonAn()
        {
            return MonAnDAL.Instance.GetAllMonAn();
        }

        public bool ThemMonAn(string tenMon, int maDanhMuc, decimal donGia, string donViTinh)
        {
            return MonAnDAL.Instance.ThemMonAn(tenMon, maDanhMuc, donGia, donViTinh);
        }

        public bool SuaMonAn(int maMon, string tenMon, int maDanhMuc, decimal donGia, string donViTinh)
        {
            return MonAnDAL.Instance.SuaMonAn(maMon, tenMon, maDanhMuc, donGia, donViTinh);
        }

        public bool XoaMonAn(int maMon)
        {
            return MonAnDAL.Instance.XoaMonAn(maMon);
        }
    }
}
