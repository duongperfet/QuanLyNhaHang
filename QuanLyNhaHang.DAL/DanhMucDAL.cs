using System.Collections.Generic;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class DanhMucDAL
    {
        private static DanhMucDAL? instance;
        public static DanhMucDAL Instance
        {
            get => instance ??= new DanhMucDAL();
            private set => instance = value;
        }

        private DanhMucDAL() { }

        public List<DanhMucDTO> GetDanhSachDanhMuc()
        {
            List<DanhMucDTO> list = new List<DanhMucDTO>();
            string query = "SELECT * FROM DanhMuc ORDER BY MaDanhMuc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DanhMucDTO category = new DanhMucDTO(item);
                list.Add(category);
            }
            return list;
        }
    }
}
