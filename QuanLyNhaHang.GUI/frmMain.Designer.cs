namespace QuanLyNhaHang.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiKhoanHienTai = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSoDoBan = new System.Windows.Forms.GroupBox();
            this.flpBanAn = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlChuThich = new System.Windows.Forms.Panel();
            this.lblChuThichCoKhach = new System.Windows.Forms.Label();
            this.pnlMauCoKhach = new System.Windows.Forms.Panel();
            this.lblChuThichDaDat = new System.Windows.Forms.Label();
            this.pnlMauDaDat = new System.Windows.Forms.Panel();
            this.lblChuThichTrong = new System.Windows.Forms.Label();
            this.pnlMauTrong = new System.Windows.Forms.Panel();
            this.grpThongTinBan = new System.Windows.Forms.GroupBox();
            this.lblThongTinDat = new System.Windows.Forms.Label();
            this.btnHuyDat = new System.Windows.Forms.Button();
            this.btnNhanBan = new System.Windows.Forms.Button();
            this.btnDatBan = new System.Windows.Forms.Button();
            this.lblTenBanDangChon = new System.Windows.Forms.Label();
            this.grpGoiMon = new System.Windows.Forms.GroupBox();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.cboMonAn = new System.Windows.Forms.ComboBox();
            this.lblMonAn = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.lsvHoaDon = new System.Windows.Forms.ListView();
            this.colTenMon = new System.Windows.Forms.ColumnHeader();
            this.colSoLuong = new System.Windows.Forms.ColumnHeader();
            this.colDonGia = new System.Windows.Forms.ColumnHeader();
            this.colThanhTien = new System.Windows.Forms.ColumnHeader();
            this.grpThanhToan = new System.Windows.Forms.GroupBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.nudGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.cboChuyenBan = new System.Windows.Forms.ComboBox();
            this.lblChuyenBan = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.grpSoDoBan.SuspendLayout();
            this.pnlChuThich.SuspendLayout();
            this.grpThongTinBan.SuspendLayout();
            this.grpGoiMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.grpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanTri,
            this.mnuTroGiup,
            this.mnuTaiKhoanHienTai});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1084, 24);
            this.mnuMain.TabIndex = 0;
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            new System.Windows.Forms.ToolStripSeparator(),
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(69, 20);
            this.mnuHeThong.Text = "&Hệ thống";
            // 
            // mnuThoat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(128, 22);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(105, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThongTin});
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(62, 20);
            this.mnuTroGiup.Text = "&Trợ giúp";
            // 
            // mnuThongTin
            // 
            this.mnuThongTin.Name = "mnuThongTin";
            this.mnuThongTin.Size = new System.Drawing.Size(177, 22);
            this.mnuThongTin.Text = "Thông tin phần mềm";
            this.mnuThongTin.Click += new System.EventHandler(this.mnuThongTin_Click);
            // 
            // mnuTaiKhoanHienTai
            // 
            this.mnuTaiKhoanHienTai.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuTaiKhoanHienTai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuTaiKhoanHienTai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.mnuTaiKhoanHienTai.Name = "mnuTaiKhoanHienTai";
            this.mnuTaiKhoanHienTai.Size = new System.Drawing.Size(120, 20);
            this.mnuTaiKhoanHienTai.Text = "Tài khoản";
            // 
            // mnuQuanTri
            // 
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(62, 20);
            this.mnuQuanTri.Text = "&Quản trị";
            this.mnuQuanTri.Click += new System.EventHandler(this.mnuQuanTri_Click);
            // 
            // grpSoDoBan
            // 
            this.grpSoDoBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpSoDoBan.Controls.Add(this.flpBanAn);
            this.grpSoDoBan.Controls.Add(this.pnlChuThich);
            this.grpSoDoBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpSoDoBan.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.grpSoDoBan.Location = new System.Drawing.Point(12, 32);
            this.grpSoDoBan.Name = "grpSoDoBan";
            this.grpSoDoBan.Size = new System.Drawing.Size(460, 595);
            this.grpSoDoBan.TabIndex = 1;
            this.grpSoDoBan.TabStop = false;
            this.grpSoDoBan.Text = "SƠ ĐỒ BÀN ĂN";
            // 
            // flpBanAn
            // 
            this.flpBanAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpBanAn.AutoScroll = true;
            this.flpBanAn.BackColor = System.Drawing.Color.White;
            this.flpBanAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBanAn.Location = new System.Drawing.Point(10, 25);
            this.flpBanAn.Name = "flpBanAn";
            this.flpBanAn.Padding = new System.Windows.Forms.Padding(6);
            this.flpBanAn.Size = new System.Drawing.Size(440, 520);
            this.flpBanAn.TabIndex = 0;
            // 
            // pnlChuThich
            // 
            this.pnlChuThich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChuThich.Controls.Add(this.lblChuThichCoKhach);
            this.pnlChuThich.Controls.Add(this.pnlMauCoKhach);
            this.pnlChuThich.Controls.Add(this.lblChuThichDaDat);
            this.pnlChuThich.Controls.Add(this.pnlMauDaDat);
            this.pnlChuThich.Controls.Add(this.lblChuThichTrong);
            this.pnlChuThich.Controls.Add(this.pnlMauTrong);
            this.pnlChuThich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlChuThich.ForeColor = System.Drawing.Color.Black;
            this.pnlChuThich.Location = new System.Drawing.Point(10, 552);
            this.pnlChuThich.Name = "pnlChuThich";
            this.pnlChuThich.Size = new System.Drawing.Size(440, 35);
            this.pnlChuThich.TabIndex = 1;
            // 
            // lblChuThichCoKhach
            // 
            this.lblChuThichCoKhach.AutoSize = true;
            this.lblChuThichCoKhach.Location = new System.Drawing.Point(340, 10);
            this.lblChuThichCoKhach.Name = "lblChuThichCoKhach";
            this.lblChuThichCoKhach.Size = new System.Drawing.Size(60, 15);
            this.lblChuThichCoKhach.TabIndex = 5;
            this.lblChuThichCoKhach.Text = ": Có khách";
            // 
            // pnlMauCoKhach
            // 
            this.pnlMauCoKhach.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.pnlMauCoKhach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauCoKhach.Location = new System.Drawing.Point(315, 8);
            this.pnlMauCoKhach.Name = "pnlMauCoKhach";
            this.pnlMauCoKhach.Size = new System.Drawing.Size(20, 18);
            this.pnlMauCoKhach.TabIndex = 4;
            // 
            // lblChuThichDaDat
            // 
            this.lblChuThichDaDat.AutoSize = true;
            this.lblChuThichDaDat.Location = new System.Drawing.Point(195, 10);
            this.lblChuThichDaDat.Name = "lblChuThichDaDat";
            this.lblChuThichDaDat.Size = new System.Drawing.Size(47, 15);
            this.lblChuThichDaDat.TabIndex = 3;
            this.lblChuThichDaDat.Text = ": Đã đặt";
            // 
            // pnlMauDaDat
            // 
            this.pnlMauDaDat.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlMauDaDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauDaDat.Location = new System.Drawing.Point(170, 8);
            this.pnlMauDaDat.Name = "pnlMauDaDat";
            this.pnlMauDaDat.Size = new System.Drawing.Size(20, 18);
            this.pnlMauDaDat.TabIndex = 2;
            // 
            // lblChuThichTrong
            // 
            this.lblChuThichTrong.AutoSize = true;
            this.lblChuThichTrong.Location = new System.Drawing.Point(45, 10);
            this.lblChuThichTrong.Name = "lblChuThichTrong";
            this.lblChuThichTrong.Size = new System.Drawing.Size(68, 15);
            this.lblChuThichTrong.TabIndex = 1;
            this.lblChuThichTrong.Text = ": Bàn trống";
            // 
            // pnlMauTrong
            // 
            this.pnlMauTrong.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.pnlMauTrong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMauTrong.Location = new System.Drawing.Point(20, 8);
            this.pnlMauTrong.Name = "pnlMauTrong";
            this.pnlMauTrong.Size = new System.Drawing.Size(20, 18);
            this.pnlMauTrong.TabIndex = 0;
            // 
            // grpThongTinBan
            // 
            this.grpThongTinBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongTinBan.Controls.Add(this.lblThongTinDat);
            this.grpThongTinBan.Controls.Add(this.btnHuyDat);
            this.grpThongTinBan.Controls.Add(this.btnNhanBan);
            this.grpThongTinBan.Controls.Add(this.btnDatBan);
            this.grpThongTinBan.Controls.Add(this.lblTenBanDangChon);
            this.grpThongTinBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpThongTinBan.Location = new System.Drawing.Point(485, 32);
            this.grpThongTinBan.Name = "grpThongTinBan";
            this.grpThongTinBan.Size = new System.Drawing.Size(585, 80);
            this.grpThongTinBan.TabIndex = 2;
            this.grpThongTinBan.TabStop = false;
            this.grpThongTinBan.Text = "Bàn đang chọn";
            // 
            // lblThongTinDat
            // 
            this.lblThongTinDat.AutoSize = true;
            this.lblThongTinDat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblThongTinDat.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblThongTinDat.Location = new System.Drawing.Point(15, 52);
            this.lblThongTinDat.Name = "lblThongTinDat";
            this.lblThongTinDat.Size = new System.Drawing.Size(160, 15);
            this.lblThongTinDat.TabIndex = 4;
            this.lblThongTinDat.Text = "(Chưa có thông tin đặt trước)";
            // 
            // btnHuyDat
            // 
            this.btnHuyDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyDat.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnHuyDat.ForeColor = System.Drawing.Color.White;
            this.btnHuyDat.FlatAppearance.BorderSize = 0;
            this.btnHuyDat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHuyDat.Location = new System.Drawing.Point(495, 25);
            this.btnHuyDat.Name = "btnHuyDat";
            this.btnHuyDat.Size = new System.Drawing.Size(80, 42);
            this.btnHuyDat.TabIndex = 3;
            this.btnHuyDat.Text = "Hủy đặt";
            this.btnHuyDat.UseVisualStyleBackColor = false;
            this.btnHuyDat.Click += new System.EventHandler(this.btnHuyDat_Click);
            // 
            // btnNhanBan
            // 
            this.btnNhanBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhanBan.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnNhanBan.ForeColor = System.Drawing.Color.White;
            this.btnNhanBan.FlatAppearance.BorderSize = 0;
            this.btnNhanBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNhanBan.Location = new System.Drawing.Point(405, 25);
            this.btnNhanBan.Name = "btnNhanBan";
            this.btnNhanBan.Size = new System.Drawing.Size(85, 42);
            this.btnNhanBan.TabIndex = 2;
            this.btnNhanBan.Text = "Nhận bàn";
            this.btnNhanBan.UseVisualStyleBackColor = false;
            this.btnNhanBan.Click += new System.EventHandler(this.btnNhanBan_Click);
            // 
            // btnDatBan
            // 
            this.btnDatBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatBan.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnDatBan.ForeColor = System.Drawing.Color.White;
            this.btnDatBan.FlatAppearance.BorderSize = 0;
            this.btnDatBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDatBan.Location = new System.Drawing.Point(315, 25);
            this.btnDatBan.Name = "btnDatBan";
            this.btnDatBan.Size = new System.Drawing.Size(85, 42);
            this.btnDatBan.TabIndex = 1;
            this.btnDatBan.Text = "Đặt bàn";
            this.btnDatBan.UseVisualStyleBackColor = false;
            this.btnDatBan.Click += new System.EventHandler(this.btnDatBan_Click);
            // 
            // lblTenBanDangChon
            // 
            this.lblTenBanDangChon.AutoSize = true;
            this.lblTenBanDangChon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTenBanDangChon.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTenBanDangChon.Location = new System.Drawing.Point(15, 24);
            this.lblTenBanDangChon.Name = "lblTenBanDangChon";
            this.lblTenBanDangChon.Size = new System.Drawing.Size(188, 21);
            this.lblTenBanDangChon.TabIndex = 0;
            this.lblTenBanDangChon.Text = "Đang chọn: BÀN 01 (Trống)";
            // 
            // grpGoiMon
            // 
            this.grpGoiMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGoiMon.Controls.Add(this.btnThemMon);
            this.grpGoiMon.Controls.Add(this.nudSoLuong);
            this.grpGoiMon.Controls.Add(this.lblSoLuong);
            this.grpGoiMon.Controls.Add(this.cboMonAn);
            this.grpGoiMon.Controls.Add(this.lblMonAn);
            this.grpGoiMon.Controls.Add(this.cboDanhMuc);
            this.grpGoiMon.Controls.Add(this.lblDanhMuc);
            this.grpGoiMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpGoiMon.Location = new System.Drawing.Point(485, 118);
            this.grpGoiMon.Name = "grpGoiMon";
            this.grpGoiMon.Size = new System.Drawing.Size(585, 75);
            this.grpGoiMon.TabIndex = 3;
            this.grpGoiMon.TabStop = false;
            this.grpGoiMon.Text = "Gọi món / Order";
            // 
            // btnThemMon
            // 
            this.btnThemMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(485, 23);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(90, 42);
            this.btnThemMon.TabIndex = 6;
            this.btnThemMon.Text = "+ Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudSoLuong.Location = new System.Drawing.Point(420, 33);
            this.nudSoLuong.Minimum = new decimal(new int[] { 10, 0, 0, -2147483648 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(55, 25);
            this.nudSoLuong.TabIndex = 5;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(417, 14);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 17);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // cboMonAn
            // 
            this.cboMonAn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMonAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonAn.FormattingEnabled = true;
            this.cboMonAn.Location = new System.Drawing.Point(180, 34);
            this.cboMonAn.Name = "cboMonAn";
            this.cboMonAn.Size = new System.Drawing.Size(225, 25);
            this.cboMonAn.TabIndex = 3;
            // 
            // lblMonAn
            // 
            this.lblMonAn.AutoSize = true;
            this.lblMonAn.Location = new System.Drawing.Point(177, 14);
            this.lblMonAn.Name = "lblMonAn";
            this.lblMonAn.Size = new System.Drawing.Size(55, 17);
            this.lblMonAn.TabIndex = 2;
            this.lblMonAn.Text = "Món ăn:";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(15, 34);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(150, 25);
            this.cboDanhMuc.TabIndex = 1;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(12, 14);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(69, 17);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // lsvHoaDon
            // 
            this.lsvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTenMon,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.lsvHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lsvHoaDon.FullRowSelect = true;
            this.lsvHoaDon.GridLines = true;
            this.lsvHoaDon.Location = new System.Drawing.Point(485, 200);
            this.lsvHoaDon.Name = "lsvHoaDon";
            this.lsvHoaDon.Size = new System.Drawing.Size(585, 290);
            this.lsvHoaDon.TabIndex = 4;
            this.lsvHoaDon.UseCompatibleStateImageBehavior = false;
            this.lsvHoaDon.View = System.Windows.Forms.View.Details;
            // 
            // colTenMon
            // 
            this.colTenMon.Text = "Tên món";
            this.colTenMon.Width = 220;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "SL";
            this.colSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSoLuong.Width = 60;
            // 
            // colDonGia
            // 
            this.colDonGia.Text = "Đơn giá (VNĐ)";
            this.colDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDonGia.Width = 130;
            // 
            // colThanhTien
            // 
            this.colThanhTien.Text = "Thành tiền (VNĐ)";
            this.colThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colThanhTien.Width = 150;
            // 
            // grpThanhToan
            // 
            this.grpThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThanhToan.Controls.Add(this.btnThanhToan);
            this.grpThanhToan.Controls.Add(this.txtTongTien);
            this.grpThanhToan.Controls.Add(this.lblTongTien);
            this.grpThanhToan.Controls.Add(this.nudGiamGia);
            this.grpThanhToan.Controls.Add(this.lblGiamGia);
            this.grpThanhToan.Controls.Add(this.btnChuyenBan);
            this.grpThanhToan.Controls.Add(this.cboChuyenBan);
            this.grpThanhToan.Controls.Add(this.lblChuyenBan);
            this.grpThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpThanhToan.Location = new System.Drawing.Point(485, 495);
            this.grpThanhToan.Name = "grpThanhToan";
            this.grpThanhToan.Size = new System.Drawing.Size(585, 132);
            this.grpThanhToan.TabIndex = 5;
            this.grpThanhToan.TabStop = false;
            this.grpThanhToan.Text = "Thanh toán & Chuyển bàn";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(435, 30);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(140, 80);
            this.btnThanhToan.TabIndex = 7;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTongTien.ForeColor = System.Drawing.Color.Crimson;
            this.txtTongTien.Location = new System.Drawing.Point(230, 78);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(185, 32);
            this.txtTongTien.TabIndex = 6;
            this.txtTongTien.Text = "0 VNĐ";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongTien.ForeColor = System.Drawing.Color.Crimson;
            this.lblTongTien.Location = new System.Drawing.Point(226, 56);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(76, 19);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // nudGiamGia
            // 
            this.nudGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudGiamGia.Location = new System.Drawing.Point(230, 25);
            this.nudGiamGia.Name = "nudGiamGia";
            this.nudGiamGia.Size = new System.Drawing.Size(80, 25);
            this.nudGiamGia.TabIndex = 4;
            this.nudGiamGia.ValueChanged += new System.EventHandler(this.nudGiamGia_ValueChanged);
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Location = new System.Drawing.Point(140, 28);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(87, 17);
            this.lblGiamGia.TabIndex = 3;
            this.lblGiamGia.Text = "Giảm giá (%):";
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnChuyenBan.ForeColor = System.Drawing.Color.White;
            this.btnChuyenBan.FlatAppearance.BorderSize = 0;
            this.btnChuyenBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChuyenBan.Location = new System.Drawing.Point(15, 78);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(110, 32);
            this.btnChuyenBan.TabIndex = 2;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // cboChuyenBan
            // 
            this.cboChuyenBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenBan.FormattingEnabled = true;
            this.cboChuyenBan.Location = new System.Drawing.Point(15, 45);
            this.cboChuyenBan.Name = "cboChuyenBan";
            this.cboChuyenBan.Size = new System.Drawing.Size(110, 25);
            this.cboChuyenBan.TabIndex = 1;
            // 
            // lblChuyenBan
            // 
            this.lblChuyenBan.AutoSize = true;
            this.lblChuyenBan.Location = new System.Drawing.Point(12, 25);
            this.lblChuyenBan.Name = "lblChuyenBan";
            this.lblChuyenBan.Size = new System.Drawing.Size(107, 17);
            this.lblChuyenBan.TabIndex = 0;
            this.lblChuyenBan.Text = "Chuyển sang bàn:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1084, 638);
            this.Controls.Add(this.grpThanhToan);
            this.Controls.Add(this.lsvHoaDon);
            this.Controls.Add(this.grpGoiMon);
            this.Controls.Add(this.grpThongTinBan);
            this.Controls.Add(this.grpSoDoBan);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(1100, 675);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Đặt Bàn & Nhà Hàng";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.grpSoDoBan.ResumeLayout(false);
            this.pnlChuThich.ResumeLayout(false);
            this.pnlChuThich.PerformLayout();
            this.grpThongTinBan.ResumeLayout(false);
            this.grpThongTinBan.PerformLayout();
            this.grpGoiMon.ResumeLayout(false);
            this.grpGoiMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.grpThanhToan.ResumeLayout(false);
            this.grpThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiKhoanHienTai;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuThongTin;
        private System.Windows.Forms.GroupBox grpSoDoBan;
        private System.Windows.Forms.FlowLayoutPanel flpBanAn;
        private System.Windows.Forms.Panel pnlChuThich;
        private System.Windows.Forms.Panel pnlMauTrong;
        private System.Windows.Forms.Label lblChuThichTrong;
        private System.Windows.Forms.Panel pnlMauDaDat;
        private System.Windows.Forms.Label lblChuThichDaDat;
        private System.Windows.Forms.Panel pnlMauCoKhach;
        private System.Windows.Forms.Label lblChuThichCoKhach;
        private System.Windows.Forms.GroupBox grpThongTinBan;
        private System.Windows.Forms.Label lblTenBanDangChon;
        private System.Windows.Forms.Button btnDatBan;
        private System.Windows.Forms.Button btnNhanBan;
        private System.Windows.Forms.Button btnHuyDat;
        private System.Windows.Forms.Label lblThongTinDat;
        private System.Windows.Forms.GroupBox grpGoiMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblMonAn;
        private System.Windows.Forms.ComboBox cboMonAn;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.ListView lsvHoaDon;
        private System.Windows.Forms.ColumnHeader colTenMon;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colDonGia;
        private System.Windows.Forms.ColumnHeader colThanhTien;
        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.Label lblChuyenBan;
        private System.Windows.Forms.ComboBox cboChuyenBan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.NumericUpDown nudGiamGia;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnThanhToan;
    }
}
