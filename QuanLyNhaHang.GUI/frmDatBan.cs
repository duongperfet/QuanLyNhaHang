using System;
using System.Windows.Forms;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.GUI
{
    public partial class frmDatBan : Form
    {
        private readonly BanAnDTO _ban;

        public frmDatBan(BanAnDTO ban)
        {
            InitializeComponent();
            _ban = ban;
            txtTenBan.Text = _ban.TenBan;
            dtpThoiGian.Value = DateTime.Now.AddHours(1); // Mặc định sau 1 tiếng
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string tenKhach = txtTenKhach.Text;
            string sdt = txtSDT.Text;
            DateTime thoiGian = dtpThoiGian.Value;
            int soNguoi = (int)nudSoNguoi.Value;
            string ghiChu = txtGhiChu.Text;

            bool isSuccess = DatBanBLL.Instance.DatBan(_ban.MaBan, tenKhach, sdt, thoiGian, soNguoi, ghiChu, out string message);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
