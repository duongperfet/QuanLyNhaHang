using System.Data;

namespace QuanLyNhaHang.DTO
{
    public class BanAnDTO
    {
        public int MaBan { get; set; }
        public string TenBan { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "Trống"; // Trống, Có người, Đã đặt

        public BanAnDTO() { }

        public BanAnDTO(int maBan, string tenBan, string trangThai)
        {
            this.MaBan = maBan;
            this.TenBan = tenBan;
            this.TrangThai = trangThai;
        }

        public BanAnDTO(DataRow row)
        {
            this.MaBan = (int)row["MaBan"];
            this.TenBan = row["TenBan"].ToString() ?? string.Empty;
            this.TrangThai = row["TrangThai"].ToString() ?? "Trống";
        }
    }
}
