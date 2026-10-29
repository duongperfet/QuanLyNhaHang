using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.GUI
{
    public partial class frmDangNhap : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaiKhoanDTO? LoggedInUser { get; private set; }

        public frmDangNhap()
        {
            InitializeComponent();
            ApDungGiaoDienBistro();
            txtTenDangNhap.Text = "admin"; // Gợi ý mặc định
        }

        private void ApDungGiaoDienBistro()
        {
            ClientSize = new Size(760, 470);
            BackColor = BistroTheme.Canvas;
            ForeColor = BistroTheme.Ink;
            Font = new Font("Segoe UI", 10f);

            var brandPanel = new Panel
            {
                BackColor = BistroTheme.Olive,
                Location = Point.Empty,
                Size = new Size(260, ClientSize.Height)
            };
            var accent = new Panel
            {
                BackColor = BistroTheme.Wine,
                Dock = DockStyle.Left,
                Width = 6
            };
            brandPanel.Controls.Add(accent);
            brandPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Text = "CUCINA  ·  BISTROT",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(225, 214, 176),
                Location = new Point(32, 118)
            });
            brandPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Text = "MAISON\nOLIVA",
                Font = new Font("Georgia", 27f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(30, 148)
            });
            brandPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Text = "Cucina di casa,\nspirito parigino.",
                Font = new Font("Georgia", 12f, FontStyle.Italic),
                ForeColor = Color.FromArgb(231, 231, 215),
                Location = new Point(32, 244)
            });
            Controls.Add(brandPanel);
            brandPanel.SendToBack();

            lblTitle.AutoSize = false;
            lblTitle.SetBounds(310, 62, 400, 40);
            lblTitle.Text = "Chào mừng trở lại";
            lblTitle.Font = new Font("Georgia", 21f, FontStyle.Bold);
            lblTitle.ForeColor = BistroTheme.Ink;

            lblTenDangNhap.SetBounds(310, 132, 390, 22);
            lblMatKhau.SetBounds(310, 211, 390, 22);
            foreach (Label label in new[] { lblTenDangNhap, lblMatKhau })
            {
                label.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                label.ForeColor = BistroTheme.Muted;
            }

            foreach (TextBox textBox in new[] { txtTenDangNhap, txtMatKhau })
            {
                textBox.SetBounds(310, textBox == txtTenDangNhap ? 158 : 237, 400, 34);
                textBox.Font = new Font("Segoe UI", 11f);
                textBox.BackColor = BistroTheme.Surface;
                textBox.ForeColor = BistroTheme.Ink;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            chkHienMatKhau.SetBounds(310, 286, 220, 24);
            chkHienMatKhau.Font = new Font("Segoe UI", 9.5f);
            chkHienMatKhau.ForeColor = BistroTheme.Muted;

            btnDangNhap.SetBounds(310, 344, 230, 44);
            btnDangNhap.Text = "Đăng nhập";
            BistroTheme.ApplyPrimaryButton(btnDangNhap, BistroTheme.Wine);

            btnThoat.SetBounds(552, 344, 158, 44);
            BistroTheme.ApplySecondaryButton(btnThoat);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            try
            {
                TaiKhoanDTO? account = TaiKhoanBLL.Instance.DangNhap(username, password);

                if (account != null)
                {
                    LoggedInUser = account;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.SelectAll();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}