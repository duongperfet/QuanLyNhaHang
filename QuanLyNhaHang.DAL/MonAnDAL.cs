using System.Collections.Generic;
using System.Data;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAL
{
    public class MonAnDAL
    {
        private static MonAnDAL? instance;
        public static MonAnDAL Instance
        {
            get => instance ??= new MonAnDAL();
            private set => instance = value;
        }

        private MonAnDAL() { }

        public List<MonAnDTO> GetMonAnTheoDanhMuc(int maDanhMuc)
        {
            List<MonAnDTO> list = new List<MonAnDTO>();
            string query = "SELECT * FROM MonAn WHERE MaDanhMuc = @maDanhMuc ORDER BY TenMon";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maDanhMuc });

            foreach (DataRow item in data.Rows)
            {
                MonAnDTO food = new MonAnDTO(item);
                list.Add(food);
            }
            return list;
        }
    }
}
