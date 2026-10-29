using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;
using ClosedXML.Excel;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace QuanLyNhaHang.GUI
{
    public partial class frmMain : Form
    {
        private BanAnDTO? _currentBan;
        private decimal _tongTienGoc = 0;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaiKhoanDTO? CurrentAccount { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLogout { get; private set; } = false;

        public frmMain(TaiKhoanDTO account) : this()
        {
            CurrentAccount = account;
            HienThiThongTinTaiKhoan();
        }

        private void HienThiThongTinTaiKhoan()
        {
            if (CurrentAccount != null)
            {
                bool isAdmin = CurrentAccount.LoaiTaiKhoan == 1;
                string vaiTro = isAdmin ? "Quản lý" : "Nhân viên";

                mnuTaiKhoanHienTai.Text = $"Xin chào: {CurrentAccount.HoTen} ({vaiTro})";
                this.Text = $"Hệ Thống Quản Lý Nhà Hàng & Bán Hàng POS - [{CurrentAccount.HoTen} - {vaiTro}]";

                // Phân quyền nghiệp vụ:
                // 1. Chỉ Quản lý mới có quyền truy cập menu Quản trị (Doanh thu, Món ăn, Tài khoản)
                mnuQuanTri.Visible = isAdmin;

                // 2. Cả Nhân viên và Quản lý đều được áp dụng mã giảm giá khi thanh toán
                nudGiamGia.Enabled = true;
                lblGiamGia.Text = "Giảm giá (%):";
            }
        }

        private Button? btnGopBan;

        public frmMain()
        {
            InitializeComponent();
            this.Text = "Hệ Thống Quản Lý Nhà Hàng & Bán Hàng POS";
            KhoiTaoNutGopBan();
            ApDungGiaoDienHienDai();
            Resize += (_, _) => BoTriGiaoDien();
            WindowState = FormWindowState.Maximized;
        }

        private static readonly Color MauNen = BistroTheme.Canvas;
        private static readonly Color MauThe = BistroTheme.Surface;
        private static readonly Color MauChu = BistroTheme.Ink;
        private static readonly Color MauChuPhu = BistroTheme.Muted;
        private static readonly Color MauXanh = BistroTheme.Olive;
        private static readonly Color MauVien = BistroTheme.Line;

        private void ApDungGiaoDienHienDai()
        {
            BackColor = MauNen;
            Font = new Font("Segoe UI", 9.5f);
            MinimumSize = new Size(1100, 700);

            mnuMain.BackColor = MauThe;
            mnuMain.ForeColor = MauChu;
            mnuMain.Font = new Font("Segoe UI", 9.5f);
            mnuMain.Padding = new Padding(12, 4, 12, 4);
            mnuTaiKhoanHienTai.ForeColor = MauXanh;

            foreach (GroupBox group in new[] { grpSoDoBan, grpThongTinBan, grpGoiMon, grpThanhToan })
            {
                group.BackColor = MauThe;
                group.ForeColor = BistroTheme.Olive;
                group.Font = new Font("Georgia", 10f, FontStyle.Bold);
            }

            grpSoDoBan.Text = "SƠ ĐỒ BÀN";
            grpThongTinBan.Text = "THÔNG TIN BÀN";
            grpGoiMon.Text = "GỌI MÓN";
            grpThanhToan.Text = "THANH TOÁN & ĐIỀU PHỐI";

            flpBanAn.BackColor = MauThe;
            flpBanAn.BorderStyle = BorderStyle.None;
            flpBanAn.Padding = new Padding(8);
            flpBanAn.WrapContents = true;
            flpBanAn.FlowDirection = FlowDirection.LeftToRight;

            pnlChuThich.BackColor = MauThe;
            foreach (Label label in new[] { lblChuThichTrong, lblChuThichDaDat, lblChuThichCoKhach })
            {
                label.ForeColor = MauChuPhu;
                label.Font = new Font("Segoe UI", 9f);
            }

            lblTenBanDangChon.ForeColor = MauChu;
            lblThongTinDat.ForeColor = MauChuPhu;
            lblDanhMuc.ForeColor = MauChuPhu;
            lblMonAn.ForeColor = MauChuPhu;
            lblSoLuong.ForeColor = MauChuPhu;
            lblChuyenBan.ForeColor = MauChuPhu;
            lblGiamGia.ForeColor = MauChuPhu;

            foreach (ComboBox combo in new[] { cboDanhMuc, cboMonAn, cboChuyenBan })
            {
                combo.Font = new Font("Segoe UI", 9.5f);
                combo.BackColor = Color.White;
                combo.ForeColor = MauChu;
                combo.FlatStyle = FlatStyle.Flat;
            }

            nudSoLuong.Font = new Font("Segoe UI", 10f);
            nudGiamGia.Font = new Font("Segoe UI", 10f);

            DinhDangNut(btnDatBan, BistroTheme.Brass);
            DinhDangNut(btnNhanBan, MauXanh);
            DinhDangNut(btnHuyDat, BistroTheme.Wine);
            DinhDangNut(btnThemMon, MauXanh);
            DinhDangNut(btnChuyenBan, BistroTheme.Wine);
            DinhDangNut(btnThanhToan, MauXanh);
            DinhDangNut(btnGopBan, BistroTheme.Wine);

            lsvHoaDon.BackColor = Color.White;
            lsvHoaDon.ForeColor = MauChu;
            lsvHoaDon.BorderStyle = BorderStyle.None;
            lsvHoaDon.GridLines = false;
            lsvHoaDon.Font = new Font("Segoe UI", 9.5f);
            lsvHoaDon.OwnerDraw = true;
            lsvHoaDon.DrawColumnHeader += LsvHoaDon_DrawColumnHeader;
            lsvHoaDon.DrawItem += (_, e) =>
            {
                if (lsvHoaDon.View != View.Details)
                {
                    e.DrawDefault = true;
                }
            };
            lsvHoaDon.DrawSubItem += LsvHoaDon_DrawSubItem;

            lblTongTien.ForeColor = MauXanh;
            txtTongTien.BackColor = BistroTheme.OliveSoft;
            txtTongTien.ForeColor = BistroTheme.Olive;
            txtTongTien.BorderStyle = BorderStyle.FixedSingle;
            txtTongTien.Font = new Font("Segoe UI", 15f, FontStyle.Bold);

            BoTriGiaoDien();
        }

        private static void DinhDangNut(Button? button, Color color)
        {
            if (button == null) return;

            button.BackColor = color;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(color, 0.12f);
            button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color, 0.08f);
            button.Cursor = Cursors.Hand;
            button.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            button.UseVisualStyleBackColor = false;
        }

        private void BoTriGiaoDien()
        {
            if (mnuMain == null || grpSoDoBan == null) return;

            const int margin = 18;
            const int gap = 14;
            int top = mnuMain.Bottom + 12;
            int availableHeight = ClientSize.Height - top - margin;
            if (availableHeight < 360) return;

            int leftWidth = Math.Max(330, (ClientSize.Width - margin * 2 - gap) * 34 / 100);
            leftWidth = Math.Min(leftWidth, ClientSize.Width - margin * 2 - gap - 520);
            int rightX = margin + leftWidth + gap;
            int rightWidth = ClientSize.Width - rightX - margin;

            grpSoDoBan.SetBounds(margin, top, leftWidth, availableHeight);
            flpBanAn.SetBounds(14, 30, leftWidth - 28, availableHeight - 92);
            pnlChuThich.SetBounds(14, availableHeight - 52, leftWidth - 28, 36);

            const int infoHeight = 96;
            const int orderHeight = 94;
            const int footerHeight = 158;
            grpThongTinBan.SetBounds(rightX, top, rightWidth, infoHeight);
            grpGoiMon.SetBounds(rightX, top + infoHeight + 10, rightWidth, orderHeight);
            grpThanhToan.SetBounds(rightX, top + availableHeight - footerHeight, rightWidth, footerHeight);

            int listTop = top + infoHeight + orderHeight + 22;
            int listBottom = grpThanhToan.Top - 12;
            lsvHoaDon.SetBounds(rightX, listTop, rightWidth, Math.Max(100, listBottom - listTop));

            int innerWidth = rightWidth - 24;
            int actionWidth = 82;
            int actionGap = 7;
            int actionStart = rightWidth - (actionWidth * 3 + actionGap * 2) - 16;
            lblTenBanDangChon.SetBounds(18, 27, Math.Max(160, actionStart - 28), 25);
            lblThongTinDat.SetBounds(18, 58, Math.Max(160, actionStart - 28), 20);
            btnDatBan.SetBounds(actionStart, 30, actionWidth, 42);
            btnNhanBan.SetBounds(actionStart + actionWidth + actionGap, 30, actionWidth, 42);
            btnHuyDat.SetBounds(actionStart + (actionWidth + actionGap) * 2, 30, actionWidth, 42);

            int addButtonWidth = 106;
            int quantityWidth = 70;
            int quantityX = innerWidth - quantityWidth - addButtonWidth - 22;
            int foodX = 180;
            int foodWidth = Math.Max(130, quantityX - foodX - 14);
            lblDanhMuc.SetBounds(18, 27, 150, 18);
            cboDanhMuc.SetBounds(18, 49, 150, 29);
            lblMonAn.SetBounds(foodX, 27, foodWidth, 18);
            cboMonAn.SetBounds(foodX, 49, foodWidth, 29);
            lblSoLuong.SetBounds(quantityX, 27, quantityWidth, 18);
            nudSoLuong.SetBounds(quantityX, 49, quantityWidth, 29);
            btnThemMon.SetBounds(innerWidth - addButtonWidth - 4, 43, addButtonWidth, 40);

            int payButtonWidth = 148;
            int payButtonX = rightWidth - payButtonWidth - 16;
            lblChuyenBan.SetBounds(16, 29, 190, 18);
            cboChuyenBan.SetBounds(16, 51, 190, 29);
            btnChuyenBan.SetBounds(16, 88, 90, 38);
            btnGopBan?.SetBounds(112, 88, 94, 38);
            lblGiamGia.SetBounds(226, 29, 110, 18);
            nudGiamGia.SetBounds(226, 51, 110, 29);
            lblTongTien.SetBounds(226, 86, Math.Max(120, payButtonX - 240), 18);
            txtTongTien.SetBounds(226, 106, Math.Max(150, payButtonX - 242), 34);
            btnThanhToan.SetBounds(payButtonX, 34, payButtonWidth, 96);

            int tableGap = 10;
            int tableWidth = Math.Max(92, (flpBanAn.ClientSize.Width - flpBanAn.Padding.Horizontal - tableGap * 2 - 18) / 3);
            foreach (Control control in flpBanAn.Controls)
            {
                if (control is TableCardButton tableButton)
                {
                    tableButton.Size = new Size(tableWidth, 92);
                    tableButton.Margin = new Padding(0, 0, tableGap, tableGap);
                }
            }

            int columnsWidth = Math.Max(360, lsvHoaDon.ClientSize.Width - 4);
            colTenMon.Width = (int)(columnsWidth * 0.42);
            colSoLuong.Width = (int)(columnsWidth * 0.12);
            colDonGia.Width = (int)(columnsWidth * 0.21);
            colThanhTien.Width = columnsWidth - colTenMon.Width - colSoLuong.Width - colDonGia.Width;
        }

        private void LsvHoaDon_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
        {
            using var brush = new SolidBrush(BistroTheme.OliveSoft);
            using var textBrush = new SolidBrush(MauChuPhu);
            using var font = new Font("Segoe UI", 9f, FontStyle.Bold);
            e.Graphics.FillRectangle(brush, e.Bounds);
            TextRenderer.DrawText(e.Graphics, e.Header?.Text ?? string.Empty, font, e.Bounds, textBrush.Color,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }

        private void LsvHoaDon_DrawSubItem(object? sender, DrawListViewSubItemEventArgs e)
        {
            Color background = e.ItemIndex % 2 == 0 ? BistroTheme.Surface : BistroTheme.Canvas;
            using var brush = new SolidBrush(background);
            e.Graphics.FillRectangle(brush, e.Bounds);
            TextFormatFlags alignment = e.ColumnIndex == 1
                ? TextFormatFlags.HorizontalCenter
                : e.ColumnIndex >= 2 ? TextFormatFlags.Right : TextFormatFlags.Left;
            var textBounds = Rectangle.Inflate(e.Bounds, e.ColumnIndex == 1 ? -2 : -10, 0);
            TextRenderer.DrawText(e.Graphics, e.SubItem?.Text ?? string.Empty, lsvHoaDon.Font, textBounds, MauChu,
                alignment | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private void KhoiTaoNutGopBan()
        {
            // Căn chỉnh bố cục cụm Thanh toán & Điều phối bàn chuẩn xác, thoáng đẹp
            grpThanhToan.Text = "THANH TOÁN & ĐIỀU PHỐI BÀN";

            // Cột 1: Chuyển & Gộp bàn
            lblChuyenBan.Location = new Point(14, 25);
            lblChuyenBan.Text = "Chuyển / Gộp sang:";
            lblChuyenBan.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblChuyenBan.ForeColor = BistroTheme.Muted;

            cboChuyenBan.Location = new Point(14, 48);
            cboChuyenBan.Size = new Size(182, 26);

            btnChuyenBan.Location = new Point(14, 80);
            btnChuyenBan.Size = new Size(88, 38);
            btnChuyenBan.Text = "Chuyển";
            btnChuyenBan.BackColor = BistroTheme.Wine;
            btnChuyenBan.ForeColor = Color.White;
            btnChuyenBan.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

            btnGopBan = new Button();
            btnGopBan.Text = "Gộp bàn";
            btnGopBan.BackColor = BistroTheme.Olive;
            btnGopBan.ForeColor = Color.White;
            btnGopBan.FlatAppearance.BorderSize = 0;
            btnGopBan.FlatStyle = FlatStyle.Flat;
            btnGopBan.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnGopBan.Cursor = Cursors.Hand;
            btnGopBan.Location = new Point(108, 80);
            btnGopBan.Size = new Size(88, 38);
            btnGopBan.Click += btnGopBan_Click;
            grpThanhToan.Controls.Add(btnGopBan);

            // Cột 2: Giảm giá & Tổng tiền
            lblGiamGia.Location = new Point(218, 25);
            lblGiamGia.Text = "Giảm giá (%):";
            lblGiamGia.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblGiamGia.ForeColor = BistroTheme.Muted;

            nudGiamGia.Location = new Point(310, 22);
            nudGiamGia.Size = new Size(95, 26);
            nudGiamGia.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);

            lblTongTien.Location = new Point(218, 55);
            lblTongTien.Text = "TỔNG THANH TOÁN:";
            lblTongTien.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblTongTien.ForeColor = BistroTheme.Wine;

            txtTongTien.Location = new Point(218, 77);
            txtTongTien.Size = new Size(187, 36);
            txtTongTien.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            txtTongTien.BackColor = BistroTheme.OliveSoft;
            txtTongTien.ForeColor = BistroTheme.Wine;
            txtTongTien.BorderStyle = BorderStyle.FixedSingle;

            // Cột 3: Nút Thanh toán
            btnThanhToan.Location = new Point(420, 22);
            btnThanhToan.Size = new Size(150, 96);
            btnThanhToan.BackColor = BistroTheme.Olive;
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            btnThanhToan.Text = "THANH TOÁN";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            HienThiThongTinTaiKhoan();
            LoadDanhMuc();
            LoadDanhSachBan();
        }

        #region Xử lý Sơ đồ bàn & Hiển thị thông tin bàn

        private void LoadDanhSachBan()
        {
            flpBanAn.Controls.Clear();
            List<BanAnDTO> listBan = BanAnBLL.Instance.GetDanhSachBanAn();

            foreach (BanAnDTO ban in listBan)
            {
                TableCardButton btn = new TableCardButton
                {
                    Width = 112,
                    Height = 92,
                    TableName = ban.TenBan,
                    AccessibleName = $"{ban.TenBan}, {ban.TrangThai}",
                    Cursor = Cursors.Hand,
                    TabStop = true,
                };
                btn.Tag = ban;

                bool isSelected = _currentBan != null && _currentBan.MaBan == ban.MaBan;
                btn.IsSelected = isSelected;

                switch (ban.TrangThai)
                {
                    case "Trống":
                        btn.CardColor = BistroTheme.OliveSoft;
                        btn.StatusColor = BistroTheme.Olive;
                        btn.StatusText = "TRỐNG";
                        break;
                    case "Đã đặt":
                        btn.CardColor = Color.FromArgb(249, 244, 232);
                        btn.StatusColor = BistroTheme.Brass;
                        btn.StatusText = "ĐÃ ĐẶT";
                        break;
                    case "Có người":
                        btn.CardColor = Color.FromArgb(249, 238, 236);
                        btn.StatusColor = BistroTheme.Wine;
                        btn.StatusText = "CÓ KHÁCH";
                        break;
                }

                btn.Click += BtnBan_Click;
                flpBanAn.Controls.Add(btn);

                // Giữ lại bàn đang chọn nếu có
                if (isSelected)
                {
                    _currentBan = ban;
                }
            }

            // Nạp danh sách chuyển bàn
            cboChuyenBan.DataSource = new List<BanAnDTO>(listBan);
            cboChuyenBan.DisplayMember = "TenBan";
            cboChuyenBan.ValueMember = "MaBan";

            // Nếu chưa chọn bàn nào thì chọn bàn đầu tiên
            if (_currentBan == null && listBan.Count > 0)
            {
                _currentBan = listBan[0];
            }

            if (_currentBan != null)
            {
                HienThiThongTinBan(_currentBan);
                CapNhatVienBanDangChon();
            }
        }

        private void BtnBan_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is BanAnDTO ban)
            {
                _currentBan = ban;
                HienThiThongTinBan(ban);
                CapNhatVienBanDangChon();
            }
        }

        private void CapNhatVienBanDangChon()
        {
            if (_currentBan == null) return;
            foreach (Control c in flpBanAn.Controls)
            {
                if (c is TableCardButton b && b.Tag is BanAnDTO bDto)
                {
                    b.IsSelected = bDto.MaBan == _currentBan.MaBan;
                }
            }
        }

        private void HienThiThongTinBan(BanAnDTO ban)
        {
            CapNhatVienBanDangChon();
            lblTenBanDangChon.Text = $"Đang chọn: {ban.TenBan} ({ban.TrangThai})";

            // Cập nhật trạng thái các nút thao tác đặt bàn
            if (ban.TrangThai == "Trống")
            {
                btnDatBan.Enabled = true;
                btnNhanBan.Enabled = false;
                btnHuyDat.Enabled = false;
                lblThongTinDat.Text = "(Bàn trống - Chưa có khách đặt trước)";
            }
            else if (ban.TrangThai == "Đã đặt")
            {
                btnDatBan.Enabled = false;
                btnNhanBan.Enabled = true;
                btnHuyDat.Enabled = true;

                // Lấy thông tin phiếu đặt bàn
                DatBanDTO? phieu = DatBanBLL.Instance.GetPhieuDatBanHienTai(ban.MaBan);
                if (phieu != null)
                {
                    lblThongTinDat.Text = $"Khách: {phieu.TenKhach} | SĐT: {phieu.SoDienThoai} | Đến lúc: {phieu.ThoiGianDat:HH:mm dd/MM} ({phieu.SoNguoi} người)";
                }
                else
                {
                    lblThongTinDat.Text = "(Có thông tin đặt bàn trước)";
                }
            }
            else // Có người
            {
                btnDatBan.Enabled = false;
                btnNhanBan.Enabled = false;
                btnHuyDat.Enabled = false;
                lblThongTinDat.Text = "(Bàn đang có khách phục vụ món)";
            }

            // Hiển thị hóa đơn món ăn của bàn
            HienThiHoaDonTheoBan(ban.MaBan);
        }

        private void HienThiHoaDonTheoBan(int maBan)
        {
            lsvHoaDon.Items.Clear();
            List<MenuOrderDTO> listMenu = HoaDonBLL.Instance.GetDanhSachMenuTheoBan(maBan);

            _tongTienGoc = 0;

            foreach (MenuOrderDTO item in listMenu)
            {
                ListViewItem lvi = new ListViewItem(item.TenMon);
                lvi.SubItems.Add(item.SoLuong.ToString());
                lvi.SubItems.Add(item.DonGia.ToString("#,##0"));
                lvi.SubItems.Add(item.ThanhTien.ToString("#,##0"));

                lsvHoaDon.Items.Add(lvi);
                _tongTienGoc += item.ThanhTien;
            }

            CapNhatTongTienHienThi();
        }

        private void CapNhatTongTienHienThi()
        {
            int giamGia = (int)nudGiamGia.Value;
            decimal tongTienSauGiam = _tongTienGoc - (_tongTienGoc * giamGia / 100);
            txtTongTien.Text = $"{tongTienSauGiam:#,##0} VNĐ";
        }

        #endregion

        #region Xử lý Gọi món (Order)

        private void LoadDanhMuc()
        {
            List<DanhMucDTO> listDanhMuc = DanhMucBLL.Instance.GetDanhSachDanhMuc();
            cboDanhMuc.DataSource = listDanhMuc;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";

            if (listDanhMuc.Count > 0)
            {
                cboDanhMuc.SelectedIndex = 0;
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedValue is int maDanhMuc)
            {
                List<MonAnDTO> listMon = MonAnBLL.Instance.GetMonAnTheoDanhMuc(maDanhMuc);
                cboMonAn.DataSource = listMon;
                cboMonAn.DisplayMember = "TenMon";
                cboMonAn.ValueMember = "MaMon";
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (_currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMonAn.SelectedValue is not int maMon)
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = (int)nudSoLuong.Value;
            if (soLuong == 0) return;

            // Gọi BLL thêm món (tự tạo hóa đơn nếu chưa có)
            HoaDonBLL.Instance.ThemMon(_currentBan.MaBan, maMon, soLuong);

            // Nạp lại sơ đồ bàn và hóa đơn
            LoadDanhSachBan();
            nudSoLuong.Value = 1;
        }

        #endregion

        #region Xử lý Đặt bàn & Nhận bàn & Hủy đặt

        private void btnDatBan_Click(object sender, EventArgs e)
        {
            if (_currentBan == null) return;

            if (_currentBan.TrangThai != "Trống")
            {
                MessageBox.Show("Chỉ có thể đặt trước cho bàn đang còn Trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmDatBan f = new frmDatBan(_currentBan);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachBan();
            }
        }

        private void btnNhanBan_Click(object sender, EventArgs e)
        {
            if (_currentBan == null) return;

            DatBanDTO? phieu = DatBanBLL.Instance.GetPhieuDatBanHienTai(_currentBan.MaBan);
            if (phieu == null)
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu đặt của bàn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialogResult = MessageBox.Show($"Xác nhận nhận bàn cho khách: {phieu.TenKhach} ({phieu.SoDienThoai})?", 
                                               "Xác nhận nhận bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                DatBanBLL.Instance.NhanBan(phieu.MaDatBan, _currentBan.MaBan);
                MessageBox.Show("Nhận bàn thành công! Bây giờ bạn có thể gọi món cho bàn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachBan();
            }
        }

        private void btnHuyDat_Click(object sender, EventArgs e)
        {
            if (_currentBan == null) return;

            DatBanDTO? phieu = DatBanBLL.Instance.GetPhieuDatBanHienTai(_currentBan.MaBan);
            if (phieu == null) return;

            var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn hủy đặt bàn này không?", 
                                               "Xác nhận hủy đặt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                DatBanBLL.Instance.HuyDatBan(phieu.MaDatBan, _currentBan.MaBan);
                MessageBox.Show("Đã hủy đặt bàn thành công! Bàn đã trở về trạng thái Trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachBan();
            }
        }

        #endregion

        #region Xử lý Chuyển bàn & Thanh toán

        private void btnGopBan_Click(object? sender, EventArgs e)
        {
            if (_currentBan == null) return;

            if (cboChuyenBan.SelectedValue is not int maBanDich) return;
            string tenBanDich = cboChuyenBan.Text;

            if (maBanDich == _currentBan.MaBan)
            {
                MessageBox.Show("Không thể gộp vào chính bàn đang chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lsvHoaDon.Items.Count == 0)
            {
                MessageBox.Show($"Bàn {_currentBan.TenBan} hiện chưa có món ăn nào để gộp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn GỘP TOÀN BỘ MÓN từ {_currentBan.TenBan} sang {tenBanDich} để thanh toán chung?",
                                          "Xác nhận gộp bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool result = BanAnBLL.Instance.GopBan(_currentBan.MaBan, maBanDich, out string message);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (result)
                {
                    LoadDanhSachBan();
                }
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (_currentBan == null) return;

            if (cboChuyenBan.SelectedValue is not int maBanMoi) return;
            string tenBanMoi = cboChuyenBan.Text;

            var confirm = MessageBox.Show($"Bạn có chắc muốn chuyển toàn bộ món từ {_currentBan.TenBan} sang {tenBanMoi}?",
                                          "Xác nhận chuyển bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool result = BanAnBLL.Instance.ChuyenBan(_currentBan.MaBan, maBanMoi, out string message);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (result)
                {
                    LoadDanhSachBan();
                }
            }
        }

        private void nudGiamGia_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTienHienThi();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_currentBan == null) return;

            if (lsvHoaDon.Items.Count == 0 || _tongTienGoc == 0)
            {
                MessageBox.Show($"Bàn {_currentBan.TenBan} hiện chưa có món ăn nào cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int giamGia = (int)nudGiamGia.Value;
            decimal tongTienSauGiam = _tongTienGoc - (_tongTienGoc * giamGia / 100);

            string thongTinHoaDon = $"HÓA ĐƠN THANH TOÁN: {_currentBan.TenBan}\n" +
                                   $"----------------------------------\n" +
                                   $"Tổng tiền món: {_tongTienGoc:#,##0} VNĐ\n" +
                                   $"Giảm giá: {giamGia}%\n" +
                                   $"SỐ TIỀN CẦN THANH TOÁN: {tongTienSauGiam:#,##0} VNĐ\n\n" +
                                   $"Xác nhận thanh toán và in hóa đơn?";

            var confirm = MessageBox.Show(thongTinHoaDon, "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var listMenu = HoaDonBLL.Instance.GetDanhSachMenuTheoBan(_currentBan.MaBan);
                bool isSuccess = HoaDonBLL.Instance.ThanhToan(_currentBan.MaBan, giamGia, out _, out _);

                if (isSuccess)
                {
                    MessageBox.Show($"Thanh toán {_currentBan.TenBan} thành công!\nCảm ơn quý khách và hẹn gặp lại!", 
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var askExport = MessageBox.Show($"Bạn có muốn xuất hóa đơn {_currentBan.TenBan} ra file Excel không?", 
                                                    "Xuất hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (askExport == DialogResult.Yes)
                    {
                        XuatHoaDonExcel(_currentBan.TenBan, listMenu, _tongTienGoc, giamGia, tongTienSauGiam);
                    }

                    nudGiamGia.Value = 0;
                    LoadDanhSachBan();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private sealed class TableCardButton : Button
        {
            private bool _hovered;
            private bool _pressed;

            public string TableName { get; set; } = string.Empty;
            public string StatusText { get; set; } = string.Empty;
            public Color CardColor { get; set; } = Color.White;
            public Color StatusColor { get; set; } = Color.Gray;
            public bool IsSelected { get; set; }

            public TableCardButton()
            {
                SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
                FlatStyle = FlatStyle.Flat;
                FlatAppearance.BorderSize = 0;
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                _hovered = true;
                Invalidate();
                base.OnMouseEnter(e);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                _hovered = false;
                Invalidate();
                base.OnMouseLeave(e);
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                _pressed = true;
                Invalidate();
                base.OnMouseDown(e);
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                _pressed = false;
                Invalidate();
                base.OnMouseUp(e);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Parent?.BackColor ?? Color.White);

                Rectangle cardBounds = ClientRectangle;
                cardBounds.Inflate(-1, -1);
                Color fillColor = _pressed
                    ? ControlPaint.Dark(CardColor, 0.04f)
                    : _hovered ? ControlPaint.Light(CardColor, 0.35f) : CardColor;

                using (GraphicsPath cardPath = CreateRoundedRectangle(cardBounds, 12))
                using (var fillBrush = new SolidBrush(fillColor))
                using (var borderPen = new Pen(IsSelected ? MauXanh : MauVien, IsSelected ? 2f : 1f))
                {
                    graphics.FillPath(fillBrush, cardPath);
                    graphics.DrawPath(borderPen, cardPath);
                }

                using (var titleFont = new Font("Segoe UI", 10f, FontStyle.Bold))
                using (var titleBrush = new SolidBrush(MauChu))
                {
                    Rectangle titleBounds = new Rectangle(8, 13, Width - 16, 24);
                    TextRenderer.DrawText(graphics, TableName, titleFont, titleBounds, titleBrush.Color,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }

                int badgeWidth = Math.Min(96, Width - 24);
                Rectangle badge = new Rectangle((Width - badgeWidth) / 2, 52, badgeWidth, 23);
                using (GraphicsPath badgePath = CreateRoundedRectangle(badge, 8))
                using (var badgeBrush = new SolidBrush(StatusColor))
                using (var badgeFont = new Font("Segoe UI", 8f, FontStyle.Bold))
                using (var badgeTextBrush = new SolidBrush(Color.White))
                {
                    graphics.FillPath(badgeBrush, badgePath);
                    TextRenderer.DrawText(graphics, StatusText, badgeFont, badge, badgeTextBrush.Color,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }

                if (Focused)
                {
                    Rectangle focusBounds = ClientRectangle;
                    focusBounds.Inflate(-5, -5);
                    ControlPaint.DrawFocusRectangle(graphics, focusBounds);
                }
            }

            private static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
            {
                int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
                var path = new GraphicsPath();
                path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();
                return path;
            }
        }

        private void XuatHoaDonExcel(string tenBan, List<MenuOrderDTO> listMenu, decimal tongTienGoc, int giamGia, decimal tongTienSauGiam)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    sfd.FileName = $"HoaDon_{tenBan.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    sfd.Title = "Chọn nơi lưu hóa đơn Excel";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("HoaDon");

                            // Tiêu đề hóa đơn
                            ws.Cell("A1").Value = "HỆ THỐNG QUẢN LÝ NHÀ HÀNG";
                            ws.Range("A1:E1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell("A2").Value = "HÓA ĐƠN THANH TOÁN";
                            ws.Range("A2:E2").Merge().Style.Font.SetBold().Font.SetFontSize(14).Font.SetFontColor(XLColor.Navy).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell("A3").Value = $"Bàn: {tenBan}  |  Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                            ws.Range("A3:E3").Merge().Style.Font.SetItalic().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // Tiêu đề các cột dữ liệu
                            int row = 5;
                            ws.Cell(row, 1).Value = "STT";
                            ws.Cell(row, 2).Value = "Tên món";
                            ws.Cell(row, 3).Value = "Đơn giá (VNĐ)";
                            ws.Cell(row, 4).Value = "Số lượng";
                            ws.Cell(row, 5).Value = "Thành tiền (VNĐ)";

                            var headerRange = ws.Range(row, 1, row, 5);
                            headerRange.Style.Font.SetBold()
                                             .Fill.SetBackgroundColor(XLColor.FromHtml("#4F81BD"))
                                             .Font.SetFontColor(XLColor.White)
                                             .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // Danh sách chi tiết món
                            int stt = 1;
                            foreach (var item in listMenu)
                            {
                                row++;
                                ws.Cell(row, 1).Value = stt++;
                                ws.Cell(row, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                                ws.Cell(row, 2).Value = item.TenMon;

                                ws.Cell(row, 3).Value = item.DonGia;
                                ws.Cell(row, 3).Style.NumberFormat.Format = "#,##0";
                                ws.Cell(row, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                                ws.Cell(row, 4).Value = item.SoLuong;
                                ws.Cell(row, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                                ws.Cell(row, 5).Value = item.ThanhTien;
                                ws.Cell(row, 5).Style.NumberFormat.Format = "#,##0";
                                ws.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                            }

                            // Kẻ viền bảng chi tiết
                            var tableRange = ws.Range(5, 1, row, 5);
                            tableRange.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                                            .Border.SetInsideBorder(XLBorderStyleValues.Thin);

                            // Phần tổng kết
                            row++;
                            ws.Cell(row, 4).Value = "Tổng tiền món:";
                            ws.Cell(row, 4).Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                            ws.Cell(row, 5).Value = tongTienGoc;
                            ws.Cell(row, 5).Style.Font.SetBold().NumberFormat.Format = "#,##0";
                            ws.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                            row++;
                            ws.Cell(row, 4).Value = $"Giảm giá ({giamGia}%):";
                            ws.Cell(row, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                            ws.Cell(row, 5).Value = tongTienGoc * giamGia / 100;
                            ws.Cell(row, 5).Style.NumberFormat.Format = "#,##0";
                            ws.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                            row++;
                            ws.Cell(row, 4).Value = "TỔNG THANH TOÁN:";
                            ws.Cell(row, 4).Style.Font.SetBold().Font.SetFontSize(12).Font.SetFontColor(XLColor.DarkRed).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                            ws.Cell(row, 5).Value = tongTienSauGiam;
                            ws.Cell(row, 5).Style.Font.SetBold().Font.SetFontSize(12).Font.SetFontColor(XLColor.DarkRed).NumberFormat.Format = "#,##0";
                            ws.Cell(row, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                            row += 2;
                            ws.Cell(row, 1).Value = "Cảm ơn quý khách và hẹn gặp lại!";
                            ws.Range(row, 1, row, 5).Merge().Style.Font.SetItalic().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // Tự động căn chỉnh độ rộng cột
                            ws.Columns(1, 5).AdjustToContents();
                            ws.Column(1).Width = Math.Max(ws.Column(1).Width, 8);
                            ws.Column(2).Width = Math.Max(ws.Column(2).Width, 25);
                            ws.Column(3).Width = Math.Max(ws.Column(3).Width, 18);
                            ws.Column(4).Width = Math.Max(ws.Column(4).Width, 12);
                            ws.Column(5).Width = Math.Max(ws.Column(5).Width, 20);

                            workbook.SaveAs(sfd.FileName);
                        }

                        var openConfirm = MessageBox.Show("Xuất hóa đơn ra Excel thành công!\nBạn có muốn mở file ngay không?", 
                                                          "Xuất hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (openConfirm == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Menu Hệ Thống & Trợ Giúp

        private void mnuQuanTri_Click(object sender, EventArgs e)
        {
            if (CurrentAccount == null || CurrentAccount.LoaiTaiKhoan != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng Quản trị!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmQuanTri fAdmin = new frmQuanTri())
            {
                fAdmin.ShowDialog();
                // Sau khi quản lý có thể cập nhật món ăn, load lại danh mục và sơ đồ bàn
                LoadDanhMuc();
                LoadDanhSachBan();
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất tài khoản hiện tại không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                IsLogout = true;
                this.Close();
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            string thongTin = "ĐỒ ÁN: PHẦN MỀM QUẢN LÝ ĐẶT BÀN & NHÀ HÀNG\n\n" +
                              "Môn học: Lập trình trên môi trường Windows\n" +
                              "Công nghệ: C# WinForms, ADO.NET (SqlConnection), SQL Server\n" +
                              "Kiến trúc: Mô hình 3 lớp chuẩn (GUI - BLL - DAL - DTO)";

            MessageBox.Show(thongTin, "Thông tin đề tài", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
