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
    }
}
