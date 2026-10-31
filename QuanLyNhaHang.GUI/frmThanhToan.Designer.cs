namespace QuanLyNhaHang.GUI
{
    partial class frmThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpHoaDon;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Panel pnlTien;
        private System.Windows.Forms.Label lblTienGocTitle;
        private System.Windows.Forms.Label lblTienGocValue;
        private System.Windows.Forms.Label lblGiamGiaTitle;
        private System.Windows.Forms.Label lblGiamGiaValue;
        private System.Windows.Forms.Label lblTongThanhToanTitle;
        private System.Windows.Forms.Label lblTongThanhToanValue;
        private System.Windows.Forms.GroupBox grpHinhThuc;
        private System.Windows.Forms.RadioButton rdoChuyenKhoan;
        private System.Windows.Forms.RadioButton rdoTienMat;
        private System.Windows.Forms.Panel pnlTienMat;
        private System.Windows.Forms.Label lblKhachDua;
        private System.Windows.Forms.TextBox txtKhachDua;
        private System.Windows.Forms.Label lblTienThoiTitle;
        private System.Windows.Forms.Label lblTienThoiValue;
        private System.Windows.Forms.Button btnTienDu;
        private System.Windows.Forms.Button btn100k;
        private System.Windows.Forms.Button btn200k;
        private System.Windows.Forms.Button btn500k;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox grpVietQR;
        private System.Windows.Forms.Label lblChonNganHang;
        private System.Windows.Forms.ComboBox cboNganHang;
        private System.Windows.Forms.Label lblSoTK;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.Label lblChuTK;
        private System.Windows.Forms.TextBox txtChuTK;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnTaoQR;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblHuongDanQR;
        private System.Windows.Forms.Button btnLuuQR;
        private System.Windows.Forms.Button btnSaoChep;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            btnHuy = new Button();
            btnXacNhan = new Button();
            pnlTienMat = new Panel();
            btn500k = new Button();
            btn200k = new Button();
            btn100k = new Button();
            btnTienDu = new Button();
            lblTienThoiValue = new Label();
            lblTienThoiTitle = new Label();
            txtKhachDua = new TextBox();
            lblKhachDua = new Label();
            grpHinhThuc = new GroupBox();
            rdoChuyenKhoan = new RadioButton();
            rdoTienMat = new RadioButton();
            grpHoaDon = new GroupBox();
            pnlTien = new Panel();
            lblTongThanhToanValue = new Label();
            lblTongThanhToanTitle = new Label();
            lblGiamGiaValue = new Label();
            lblGiamGiaTitle = new Label();
            lblTienGocValue = new Label();
            lblTienGocTitle = new Label();
            lblThoiGian = new Label();
            lblMaHoaDon = new Label();
            lblTenBan = new Label();
            pnlRight = new Panel();
            grpVietQR = new GroupBox();
            btnSaoChep = new Button();
            btnLuuQR = new Button();
            lblHuongDanQR = new Label();
            picQR = new PictureBox();
            btnTaoQR = new Button();
            txtNoiDung = new TextBox();
            lblNoiDung = new Label();
            txtChuTK = new TextBox();
            lblChuTK = new Label();
            txtSoTK = new TextBox();
            lblSoTK = new Label();
            cboNganHang = new ComboBox();
            lblChonNganHang = new Label();
            pnlLeft.SuspendLayout();
            pnlTienMat.SuspendLayout();
            grpHinhThuc.SuspendLayout();
            grpHoaDon.SuspendLayout();
            pnlTien.SuspendLayout();
            pnlRight.SuspendLayout();
            grpVietQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(248, 246, 240);
            pnlLeft.Controls.Add(btnHuy);
            pnlLeft.Controls.Add(btnXacNhan);
            pnlLeft.Controls.Add(pnlTienMat);
            pnlLeft.Controls.Add(grpHinhThuc);
            pnlLeft.Controls.Add(grpHoaDon);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(12);
            pnlLeft.Size = new Size(365, 595);
            pnlLeft.TabIndex = 0;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.White;
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnHuy.ForeColor = Color.FromArgb(117, 117, 105);
            btnHuy.Location = new Point(12, 545);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 40);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "HỦY";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.FromArgb(83, 99, 61);
            btnXacNhan.Cursor = Cursors.Hand;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(118, 545);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(235, 40);
            btnXacNhan.TabIndex = 3;
            btnXacNhan.Text = "✔ HOÀN TẤT THANH TOÁN";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // pnlTienMat
            // 
            pnlTienMat.BackColor = Color.White;
            pnlTienMat.BorderStyle = BorderStyle.FixedSingle;
            pnlTienMat.Controls.Add(btn500k);
            pnlTienMat.Controls.Add(btn200k);
            pnlTienMat.Controls.Add(btn100k);
            pnlTienMat.Controls.Add(btnTienDu);
            pnlTienMat.Controls.Add(lblTienThoiValue);
            pnlTienMat.Controls.Add(lblTienThoiTitle);
            pnlTienMat.Controls.Add(txtKhachDua);
            pnlTienMat.Controls.Add(lblKhachDua);
            pnlTienMat.Location = new Point(12, 395);
            pnlTienMat.Name = "pnlTienMat";
            pnlTienMat.Size = new Size(341, 140);
            pnlTienMat.TabIndex = 2;
            pnlTienMat.Visible = false;
            // 
            // btn500k
            // 
            btn500k.BackColor = Color.FromArgb(239, 242, 231);
            btn500k.Cursor = Cursors.Hand;
            btn500k.FlatAppearance.BorderSize = 0;
            btn500k.FlatStyle = FlatStyle.Flat;
            btn500k.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btn500k.ForeColor = Color.FromArgb(83, 99, 61);
            btn500k.Location = new Point(255, 62);
            btn500k.Name = "btn500k";
            btn500k.Size = new Size(74, 26);
            btn500k.TabIndex = 7;
            btn500k.Text = "500.000";
            btn500k.UseVisualStyleBackColor = false;
            btn500k.Click += btnQuickMoney_Click;
            // 
            // btn200k
            // 
            btn200k.BackColor = Color.FromArgb(239, 242, 231);
            btn200k.Cursor = Cursors.Hand;
            btn200k.FlatAppearance.BorderSize = 0;
            btn200k.FlatStyle = FlatStyle.Flat;
            btn200k.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btn200k.ForeColor = Color.FromArgb(83, 99, 61);
            btn200k.Location = new Point(173, 62);
            btn200k.Name = "btn200k";
            btn200k.Size = new Size(74, 26);
            btn200k.TabIndex = 6;
            btn200k.Text = "200.000";
            btn200k.UseVisualStyleBackColor = false;
            btn200k.Click += btnQuickMoney_Click;
            // 
            // btn100k
            // 
            btn100k.BackColor = Color.FromArgb(239, 242, 231);
            btn100k.Cursor = Cursors.Hand;
            btn100k.FlatAppearance.BorderSize = 0;
            btn100k.FlatStyle = FlatStyle.Flat;
            btn100k.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btn100k.ForeColor = Color.FromArgb(83, 99, 61);
            btn100k.Location = new Point(91, 62);
            btn100k.Name = "btn100k";
            btn100k.Size = new Size(74, 26);
            btn100k.TabIndex = 5;
            btn100k.Text = "100.000";
            btn100k.UseVisualStyleBackColor = false;
            btn100k.Click += btnQuickMoney_Click;
            // 
            // btnTienDu
            // 
            btnTienDu.BackColor = Color.FromArgb(239, 242, 231);
            btnTienDu.Cursor = Cursors.Hand;
            btnTienDu.FlatAppearance.BorderSize = 0;
            btnTienDu.FlatStyle = FlatStyle.Flat;
            btnTienDu.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnTienDu.ForeColor = Color.FromArgb(83, 99, 61);
            btnTienDu.Location = new Point(9, 62);
            btnTienDu.Name = "btnTienDu";
            btnTienDu.Size = new Size(74, 26);
            btnTienDu.TabIndex = 4;
            btnTienDu.Text = "Đủ tiền";
            btnTienDu.UseVisualStyleBackColor = false;
            btnTienDu.Click += btnTienDu_Click;
            // 
            // lblTienThoiValue
            // 
            lblTienThoiValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTienThoiValue.ForeColor = Color.FromArgb(83, 99, 61);
            lblTienThoiValue.Location = new Point(135, 98);
            lblTienThoiValue.Name = "lblTienThoiValue";
            lblTienThoiValue.Size = new Size(194, 25);
            lblTienThoiValue.TabIndex = 3;
            lblTienThoiValue.Text = "0 VNĐ";
            lblTienThoiValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTienThoiTitle
            // 
            lblTienThoiTitle.AutoSize = true;
            lblTienThoiTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTienThoiTitle.ForeColor = Color.FromArgb(43, 45, 39);
            lblTienThoiTitle.Location = new Point(8, 102);
            lblTienThoiTitle.Name = "lblTienThoiTitle";
            lblTienThoiTitle.Size = new Size(88, 17);
            lblTienThoiTitle.TabIndex = 2;
            lblTienThoiTitle.Text = "Tiền thối lại:";
            // 
            // txtKhachDua
            // 
            txtKhachDua.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtKhachDua.ForeColor = Color.FromArgb(43, 45, 39);
            txtKhachDua.Location = new Point(140, 18);
            txtKhachDua.Name = "txtKhachDua";
            txtKhachDua.Size = new Size(189, 29);
            txtKhachDua.TabIndex = 1;
            txtKhachDua.TextAlign = HorizontalAlignment.Right;
            txtKhachDua.TextChanged += txtKhachDua_TextChanged;
            // 
            // lblKhachDua
            // 
            lblKhachDua.AutoSize = true;
            lblKhachDua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblKhachDua.ForeColor = Color.FromArgb(43, 45, 39);
            lblKhachDua.Location = new Point(8, 24);
            lblKhachDua.Name = "lblKhachDua";
            lblKhachDua.Size = new Size(106, 17);
            lblKhachDua.TabIndex = 0;
            lblKhachDua.Text = "Tiền khách đưa:";
            // 
            // grpHinhThuc
            // 
            grpHinhThuc.BackColor = Color.White;
            grpHinhThuc.Controls.Add(rdoChuyenKhoan);
            grpHinhThuc.Controls.Add(rdoTienMat);
            grpHinhThuc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpHinhThuc.ForeColor = Color.FromArgb(43, 45, 39);
            grpHinhThuc.Location = new Point(12, 305);
            grpHinhThuc.Name = "grpHinhThuc";
            grpHinhThuc.Size = new Size(341, 80);
            grpHinhThuc.TabIndex = 1;
            grpHinhThuc.TabStop = false;
            grpHinhThuc.Text = "Hình Thức Thanh Toán";
            // 
            // rdoChuyenKhoan
            // 
            rdoChuyenKhoan.AutoSize = true;
            rdoChuyenKhoan.Checked = true;
            rdoChuyenKhoan.Cursor = Cursors.Hand;
            rdoChuyenKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rdoChuyenKhoan.ForeColor = Color.FromArgb(0, 102, 179);
            rdoChuyenKhoan.Location = new Point(18, 32);
            rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            rdoChuyenKhoan.Size = new Size(160, 23);
            rdoChuyenKhoan.TabIndex = 0;
            rdoChuyenKhoan.TabStop = true;
            rdoChuyenKhoan.Text = "📲 Chuyển khoản QR";
            rdoChuyenKhoan.UseVisualStyleBackColor = true;
            rdoChuyenKhoan.CheckedChanged += rdoHinhThuc_CheckedChanged;
            // 
            // rdoTienMat
            // 
            rdoTienMat.AutoSize = true;
            rdoTienMat.Cursor = Cursors.Hand;
            rdoTienMat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rdoTienMat.ForeColor = Color.FromArgb(83, 99, 61);
            rdoTienMat.Location = new Point(205, 32);
            rdoTienMat.Name = "rdoTienMat";
            rdoTienMat.Size = new Size(111, 23);
            rdoTienMat.TabIndex = 1;
            rdoTienMat.Text = "💵 Tiền mặt";
            rdoTienMat.UseVisualStyleBackColor = true;
            rdoTienMat.CheckedChanged += rdoHinhThuc_CheckedChanged;
            // 
            // grpHoaDon
            // 
            grpHoaDon.BackColor = Color.White;
            grpHoaDon.Controls.Add(pnlTien);
            grpHoaDon.Controls.Add(lblThoiGian);
            grpHoaDon.Controls.Add(lblMaHoaDon);
            grpHoaDon.Controls.Add(lblTenBan);
            grpHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpHoaDon.ForeColor = Color.FromArgb(43, 45, 39);
            grpHoaDon.Location = new Point(12, 12);
            grpHoaDon.Name = "grpHoaDon";
            grpHoaDon.Size = new Size(341, 280);
            grpHoaDon.TabIndex = 0;
            grpHoaDon.TabStop = false;
            grpHoaDon.Text = "Chi Tiết Hóa Đơn";
            // 
            // pnlTien
            // 
            pnlTien.BackColor = Color.FromArgb(239, 242, 231);
            pnlTien.BorderStyle = BorderStyle.FixedSingle;
            pnlTien.Controls.Add(lblTongThanhToanValue);
            pnlTien.Controls.Add(lblTongThanhToanTitle);
            pnlTien.Controls.Add(lblGiamGiaValue);
            pnlTien.Controls.Add(lblGiamGiaTitle);
            pnlTien.Controls.Add(lblTienGocValue);
            pnlTien.Controls.Add(lblTienGocTitle);
            pnlTien.Location = new Point(10, 115);
            pnlTien.Name = "pnlTien";
            pnlTien.Size = new Size(321, 150);
            pnlTien.TabIndex = 3;
            // 
            // lblTongThanhToanValue
            // 
            lblTongThanhToanValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongThanhToanValue.ForeColor = Color.FromArgb(143, 57, 65);
            lblTongThanhToanValue.Location = new Point(12, 102);
            lblTongThanhToanValue.Name = "lblTongThanhToanValue";
            lblTongThanhToanValue.Size = new Size(295, 35);
            lblTongThanhToanValue.TabIndex = 5;
            lblTongThanhToanValue.Text = "0 VNĐ";
            lblTongThanhToanValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTongThanhToanTitle
            // 
            lblTongThanhToanTitle.AutoSize = true;
            lblTongThanhToanTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTongThanhToanTitle.ForeColor = Color.FromArgb(43, 45, 39);
            lblTongThanhToanTitle.Location = new Point(10, 80);
            lblTongThanhToanTitle.Name = "lblTongThanhToanTitle";
            lblTongThanhToanTitle.Size = new Size(183, 19);
            lblTongThanhToanTitle.TabIndex = 4;
            lblTongThanhToanTitle.Text = "SỐ TIỀN CẦN BÁO KHÁCH:";
            // 
            // lblGiamGiaValue
            // 
            lblGiamGiaValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGiamGiaValue.ForeColor = Color.FromArgb(143, 57, 65);
            lblGiamGiaValue.Location = new Point(135, 45);
            lblGiamGiaValue.Name = "lblGiamGiaValue";
            lblGiamGiaValue.Size = new Size(172, 20);
            lblGiamGiaValue.TabIndex = 3;
            lblGiamGiaValue.Text = "0% (-0 VNĐ)";
            lblGiamGiaValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGiamGiaTitle
            // 
            lblGiamGiaTitle.AutoSize = true;
            lblGiamGiaTitle.Font = new Font("Segoe UI", 9.5F);
            lblGiamGiaTitle.ForeColor = Color.FromArgb(117, 117, 105);
            lblGiamGiaTitle.Location = new Point(10, 45);
            lblGiamGiaTitle.Name = "lblGiamGiaTitle";
            lblGiamGiaTitle.Size = new Size(62, 17);
            lblGiamGiaTitle.TabIndex = 2;
            lblGiamGiaTitle.Text = "Giảm giá:";
            // 
            // lblTienGocValue
            // 
            lblTienGocValue.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTienGocValue.ForeColor = Color.FromArgb(43, 45, 39);
            lblTienGocValue.Location = new Point(135, 14);
            lblTienGocValue.Name = "lblTienGocValue";
            lblTienGocValue.Size = new Size(172, 22);
            lblTienGocValue.TabIndex = 1;
            lblTienGocValue.Text = "0 VNĐ";
            lblTienGocValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTienGocTitle
            // 
            lblTienGocTitle.AutoSize = true;
            lblTienGocTitle.Font = new Font("Segoe UI", 9.5F);
            lblTienGocTitle.ForeColor = Color.FromArgb(117, 117, 105);
            lblTienGocTitle.Location = new Point(10, 15);
            lblTienGocTitle.Name = "lblTienGocTitle";
            lblTienGocTitle.Size = new Size(95, 17);
            lblTienGocTitle.TabIndex = 0;
            lblTienGocTitle.Text = "Tổng tiền món:";
            // 
            // lblThoiGian
            // 
            lblThoiGian.AutoSize = true;
            lblThoiGian.Font = new Font("Segoe UI", 9F);
            lblThoiGian.ForeColor = Color.FromArgb(117, 117, 105);
            lblThoiGian.Location = new Point(10, 85);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(141, 15);
            lblThoiGian.TabIndex = 2;
            lblThoiGian.Text = "Thời gian: 31/10/2026 15:00";
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaHoaDon.ForeColor = Color.FromArgb(190, 145, 78);
            lblMaHoaDon.Location = new Point(10, 58);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(123, 19);
            lblMaHoaDon.TabIndex = 1;
            lblMaHoaDon.Text = "Hóa Đơn: #HD001";
            // 
            // lblTenBan
            // 
            lblTenBan.AutoSize = true;
            lblTenBan.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTenBan.ForeColor = Color.FromArgb(83, 99, 61);
            lblTenBan.Location = new Point(8, 25);
            lblTenBan.Name = "lblTenBan";
            lblTenBan.Size = new Size(100, 28);
            lblTenBan.TabIndex = 0;
            lblTenBan.Text = "BÀN SỐ 1";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(grpVietQR);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(365, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(12);
            pnlRight.Size = new Size(480, 595);
            pnlRight.TabIndex = 1;
            // 
            // grpVietQR
            // 
            grpVietQR.Controls.Add(btnSaoChep);
            grpVietQR.Controls.Add(btnLuuQR);
            grpVietQR.Controls.Add(lblHuongDanQR);
            grpVietQR.Controls.Add(picQR);
            grpVietQR.Controls.Add(btnTaoQR);
            grpVietQR.Controls.Add(txtNoiDung);
            grpVietQR.Controls.Add(lblNoiDung);
            grpVietQR.Controls.Add(txtChuTK);
            grpVietQR.Controls.Add(lblChuTK);
            grpVietQR.Controls.Add(txtSoTK);
            grpVietQR.Controls.Add(lblSoTK);
            grpVietQR.Controls.Add(cboNganHang);
            grpVietQR.Controls.Add(lblChonNganHang);
            grpVietQR.Dock = DockStyle.Fill;
            grpVietQR.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpVietQR.ForeColor = Color.FromArgb(43, 45, 39);
            grpVietQR.Location = new Point(12, 12);
            grpVietQR.Name = "grpVietQR";
            grpVietQR.Size = new Size(456, 571);
            grpVietQR.TabIndex = 0;
            grpVietQR.TabStop = false;
            grpVietQR.Text = "Cổng Thanh Toán Chuyển Khoản QR Ngân Hàng (API VietQR)";
            // 
            // btnSaoChep
            // 
            btnSaoChep.BackColor = Color.FromArgb(239, 242, 231);
            btnSaoChep.Cursor = Cursors.Hand;
            btnSaoChep.FlatAppearance.BorderSize = 0;
            btnSaoChep.FlatStyle = FlatStyle.Flat;
            btnSaoChep.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSaoChep.ForeColor = Color.FromArgb(83, 99, 61);
            btnSaoChep.Location = new Point(238, 528);
            btnSaoChep.Name = "btnSaoChep";
            btnSaoChep.Size = new Size(198, 32);
            btnSaoChep.TabIndex = 12;
            btnSaoChep.Text = "📋 Sao chép số tài khoản";
            btnSaoChep.UseVisualStyleBackColor = false;
            btnSaoChep.Click += btnSaoChep_Click;
            // 
            // btnLuuQR
            // 
            btnLuuQR.BackColor = Color.FromArgb(239, 242, 231);
            btnLuuQR.Cursor = Cursors.Hand;
            btnLuuQR.FlatAppearance.BorderSize = 0;
            btnLuuQR.FlatStyle = FlatStyle.Flat;
            btnLuuQR.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnLuuQR.ForeColor = Color.FromArgb(83, 99, 61);
            btnLuuQR.Location = new Point(20, 528);
            btnLuuQR.Name = "btnLuuQR";
            btnLuuQR.Size = new Size(205, 32);
            btnLuuQR.TabIndex = 11;
            btnLuuQR.Text = "💾 Lưu ảnh mã QR về máy";
            btnLuuQR.UseVisualStyleBackColor = false;
            btnLuuQR.Click += btnLuuQR_Click;
            // 
            // lblHuongDanQR
            // 
            lblHuongDanQR.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblHuongDanQR.ForeColor = Color.FromArgb(117, 117, 105);
            lblHuongDanQR.Location = new Point(20, 498);
            lblHuongDanQR.Name = "lblHuongDanQR";
            lblHuongDanQR.Size = new Size(416, 25);
            lblHuongDanQR.TabIndex = 10;
            lblHuongDanQR.Text = "💡 Khách dùng App mọi ngân hàng quét mã sẽ tự điền đúng STK và số tiền.";
            lblHuongDanQR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picQR
            // 
            picQR.BackColor = Color.FromArgb(248, 249, 250);
            picQR.BorderStyle = BorderStyle.FixedSingle;
            picQR.Location = new Point(88, 168);
            picQR.Name = "picQR";
            picQR.Size = new Size(280, 325);
            picQR.SizeMode = PictureBoxSizeMode.Zoom;
            picQR.TabIndex = 9;
            picQR.TabStop = false;
            // 
            // btnTaoQR
            // 
            btnTaoQR.BackColor = Color.FromArgb(190, 145, 78);
            btnTaoQR.Cursor = Cursors.Hand;
            btnTaoQR.FlatAppearance.BorderSize = 0;
            btnTaoQR.FlatStyle = FlatStyle.Flat;
            btnTaoQR.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTaoQR.ForeColor = Color.White;
            btnTaoQR.Location = new Point(310, 95);
            btnTaoQR.Name = "btnTaoQR";
            btnTaoQR.Size = new Size(130, 55);
            btnTaoQR.TabIndex = 8;
            btnTaoQR.Text = "🔄 Tạo lại mã QR";
            btnTaoQR.UseVisualStyleBackColor = false;
            btnTaoQR.Click += btnTaoQR_Click;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtNoiDung.Location = new Point(88, 126);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(210, 23);
            txtNoiDung.TabIndex = 7;
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Font = new Font("Segoe UI", 8.5F);
            lblNoiDung.ForeColor = Color.FromArgb(117, 117, 105);
            lblNoiDung.Location = new Point(15, 130);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(60, 15);
            lblNoiDung.TabIndex = 6;
            lblNoiDung.Text = "Nội dung:";
            // 
            // txtChuTK
            // 
            txtChuTK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtChuTK.Location = new Point(88, 96);
            txtChuTK.Name = "txtChuTK";
            txtChuTK.Size = new Size(210, 23);
            txtChuTK.TabIndex = 5;
            txtChuTK.Text = "VO TUNG DUONG";
            // 
            // lblChuTK
            // 
            lblChuTK.AutoSize = true;
            lblChuTK.Font = new Font("Segoe UI", 8.5F);
            lblChuTK.ForeColor = Color.FromArgb(117, 117, 105);
            lblChuTK.Location = new Point(15, 100);
            lblChuTK.Name = "lblChuTK";
            lblChuTK.Size = new Size(51, 15);
            lblChuTK.TabIndex = 4;
            lblChuTK.Text = "Chủ TK:";
            // 
            // txtSoTK
            // 
            txtSoTK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtSoTK.Location = new Point(88, 65);
            txtSoTK.Name = "txtSoTK";
            txtSoTK.Size = new Size(352, 23);
            txtSoTK.TabIndex = 3;
            txtSoTK.Text = "0889294024";
            // 
            // lblSoTK
            // 
            lblSoTK.AutoSize = true;
            lblSoTK.Font = new Font("Segoe UI", 8.5F);
            lblSoTK.ForeColor = Color.FromArgb(117, 117, 105);
            lblSoTK.Location = new Point(15, 68);
            lblSoTK.Name = "lblSoTK";
            lblSoTK.Size = new Size(42, 15);
            lblSoTK.TabIndex = 2;
            lblSoTK.Text = "Số TK:";
            // 
            // cboNganHang
            // 
            cboNganHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNganHang.Font = new Font("Segoe UI", 9F);
            cboNganHang.FormattingEnabled = true;
            cboNganHang.Location = new Point(88, 32);
            cboNganHang.Name = "cboNganHang";
            cboNganHang.Size = new Size(352, 23);
            cboNganHang.TabIndex = 1;
            cboNganHang.SelectedIndexChanged += cboNganHang_SelectedIndexChanged;
            // 
            // lblChonNganHang
            // 
            lblChonNganHang.AutoSize = true;
            lblChonNganHang.Font = new Font("Segoe UI", 8.5F);
            lblChonNganHang.ForeColor = Color.FromArgb(117, 117, 105);
            lblChonNganHang.Location = new Point(15, 35);
            lblChonNganHang.Name = "lblChonNganHang";
            lblChonNganHang.Size = new Size(69, 15);
            lblChonNganHang.TabIndex = 0;
            lblChonNganHang.Text = "Ngân hàng:";
            // 
            // frmThanhToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 246, 240);
            CancelButton = btnHuy;
            ClientSize = new Size(845, 595);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThanhToan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "XÁC NHẬN THANH TOÁN & ĐẤU NỐI VIETQR";
            Load += frmThanhToan_Load;
            pnlLeft.ResumeLayout(false);
            pnlTienMat.ResumeLayout(false);
            pnlTienMat.PerformLayout();
            grpHinhThuc.ResumeLayout(false);
            grpHinhThuc.PerformLayout();
            grpHoaDon.ResumeLayout(false);
            grpHoaDon.PerformLayout();
            pnlTien.ResumeLayout(false);
            pnlTien.PerformLayout();
            pnlRight.ResumeLayout(false);
            grpVietQR.ResumeLayout(false);
            grpVietQR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ResumeLayout(false);
        }
    }
}
