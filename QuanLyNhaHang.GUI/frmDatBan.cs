using System;
using System.Drawing;
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
            ApDungGiaoDienBistro();
            _ban = ban;
            txtTenBan.Text = _ban.TenBan;
            dtpThoiGian.Value = DateTime.Now.AddHours(1); // Mặc định sau 1 tiếng
        }

        private void ApDungGiaoDienBistro()
        {
            ClientSize = new Size(520, 470);
            BackColor = BistroTheme.Canvas;
            ForeColor = BistroTheme.Ink;
            Font = new Font("Segoe UI", 9.5f);

            var accent = new Panel
            {
                BackColor = BistroTheme.Wine,
                Dock = DockStyle.Top,
                Height = 5
            };
            Controls.Add(accent);
            accent.BringToFront();

            lblTitle.SetBounds(30, 24, 460, 36);
            lblTitle.Text = "THÔNG TIN ĐẶT BÀN";
            lblTitle.Font = new Font("Georgia", 17f, FontStyle.Bold);
            lblTitle.ForeColor = BistroTheme.Olive;

            Label[] labels = { lblTenBan, lblTenKhach, lblSDT, lblThoiGian, lblSoNguoi, lblGhiChu };
            Control[] fields = { txtTenBan, txtTenKhach, txtSDT, dtpThoiGian, nudSoNguoi, txtGhiChu };
            int[] topPositions = { 88, 135, 182, 229, 276, 323 };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].SetBounds(32, topPositions[i] + 4, 112, 22);
                labels[i].Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                labels[i].ForeColor = BistroTheme.Muted;
                fields[i].SetBounds(150, topPositions[i], i == 4 ? 120 : 338, i == 5 ? 54 : 32);
            }

            foreach (TextBox textBox in new[] { txtTenBan, txtTenKhach, txtSDT, txtGhiChu })
            {
                textBox.Font = new Font("Segoe UI", 10f);
                textBox.ForeColor = BistroTheme.Ink;
                textBox.BackColor = BistroTheme.Surface;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
            txtTenBan.BackColor = BistroTheme.OliveSoft;
            dtpThoiGian.Font = new Font("Segoe UI", 10f);
            nudSoNguoi.Font = new Font("Segoe UI", 10f);

            btnXacNhan.SetBounds(150, 405, 205, 42);
            BistroTheme.ApplyPrimaryButton(btnXacNhan);
            btnHuy.SetBounds(366, 405, 122, 42);
            BistroTheme.ApplySecondaryButton(btnHuy);
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
