using System.Data;

namespace QuanLyNhaHang.DTO
{
    public class DanhMucDTO
    {
        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; } = string.Empty;

        public DanhMucDTO() { }

        public DanhMucDTO(int maDanhMuc, string tenDanhMuc)
        {
            this.MaDanhMuc = maDanhMuc;
            this.TenDanhMuc = tenDanhMuc;
        }

        public DanhMucDTO(DataRow row)
        {
            this.MaDanhMuc = (int)row["MaDanhMuc"];
            this.TenDanhMuc = row["TenDanhMuc"].ToString() ?? string.Empty;
        }
    }
}
