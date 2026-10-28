namespace QuanLyNhaHang.GUI
{
    partial class frmQuanTri
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
            this.tcQuanTri = new System.Windows.Forms.TabControl();
            this.tpDoanhThu = new System.Windows.Forms.TabPage();
            this.pnlBottomDoanhThu = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnlTopDoanhThu = new System.Windows.Forms.Panel();
            this.btnXuatExcelDoanhThu = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.tpMonAn = new System.Windows.Forms.TabPage();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.pnlMonAnRight = new System.Windows.Forms.Panel();
            this.btnLamMoiMon = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnSuaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.nudDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.tpTaiKhoan = new System.Windows.Forms.TabPage();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.pnlTaiKhoanRight = new System.Windows.Forms.Panel();
            this.btnLamMoiTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.cboLoaiTK = new System.Windows.Forms.ComboBox();
            this.lblLoaiTK = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.tcQuanTri.SuspendLayout();
            this.tpDoanhThu.SuspendLayout();
            this.pnlBottomDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.pnlTopDoanhThu.SuspendLayout();
            this.tpMonAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.pnlMonAnRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).BeginInit();
            this.tpTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.pnlTaiKhoanRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcQuanTri
            // 
            this.tcQuanTri.Controls.Add(this.tpDoanhThu);
            this.tcQuanTri.Controls.Add(this.tpMonAn);
            this.tcQuanTri.Controls.Add(this.tpTaiKhoan);
            this.tcQuanTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcQuanTri.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tcQuanTri.Location = new System.Drawing.Point(0, 0);
            this.tcQuanTri.Name = "tcQuanTri";
            this.tcQuanTri.SelectedIndex = 0;
            this.tcQuanTri.Size = new System.Drawing.Size(934, 531);
            this.tcQuanTri.TabIndex = 0;
            // 
            // tpDoanhThu
            // 
            this.tpDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.tpDoanhThu.Controls.Add(this.pnlBottomDoanhThu);
            this.tpDoanhThu.Controls.Add(this.pnlTopDoanhThu);
            this.tpDoanhThu.Location = new System.Drawing.Point(4, 26);
            this.tpDoanhThu.Name = "tpDoanhThu";
            this.tpDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tpDoanhThu.Size = new System.Drawing.Size(926, 501);
            this.tpDoanhThu.TabIndex = 0;
            this.tpDoanhThu.Text = "  Thống Kê Doanh Thu  ";
            this.tpDoanhThu.UseVisualStyleBackColor = true;
            // 
            // pnlBottomDoanhThu
            // 
            this.pnlBottomDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlBottomDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.pnlBottomDoanhThu.Controls.Add(this.lblSoHoaDon);
            this.pnlBottomDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomDoanhThu.Location = new System.Drawing.Point(3, 453);
            this.pnlBottomDoanhThu.Name = "pnlBottomDoanhThu";
            this.pnlBottomDoanhThu.Size = new System.Drawing.Size(920, 45);
            this.pnlBottomDoanhThu.TabIndex = 2;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(460, 10);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(445, 25);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "TỔNG DOANH THU: 0 VNĐ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.AutoSize = true;
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSoHoaDon.Location = new System.Drawing.Point(15, 14);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(142, 19);
            this.lblSoHoaDon.TabIndex = 0;
            this.lblSoHoaDon.Text = "Số lượng hóa đơn: 0";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.Location = new System.Drawing.Point(3, 58);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersVisible = false;
            this.dgvDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.Size = new System.Drawing.Size(920, 395);
            this.dgvDoanhThu.TabIndex = 1;
            // 
            // pnlTopDoanhThu
            // 
            this.pnlTopDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlTopDoanhThu.Controls.Add(this.btnXuatExcelDoanhThu);
            this.pnlTopDoanhThu.Controls.Add(this.btnThongKe);
            this.pnlTopDoanhThu.Controls.Add(this.dtpDenNgay);
            this.pnlTopDoanhThu.Controls.Add(this.lblDenNgay);
            this.pnlTopDoanhThu.Controls.Add(this.dtpTuNgay);
            this.pnlTopDoanhThu.Controls.Add(this.lblTuNgay);
            this.pnlTopDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.pnlTopDoanhThu.Name = "pnlTopDoanhThu";
            this.pnlTopDoanhThu.Size = new System.Drawing.Size(920, 55);
            this.pnlTopDoanhThu.TabIndex = 0;
            // 
            // btnXuatExcelDoanhThu
            // 
            this.btnXuatExcelDoanhThu.BackColor = System.Drawing.Color.SeaGreen;
            this.btnXuatExcelDoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcelDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcelDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXuatExcelDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcelDoanhThu.Location = new System.Drawing.Point(620, 11);
            this.btnXuatExcelDoanhThu.Name = "btnXuatExcelDoanhThu";
            this.btnXuatExcelDoanhThu.Size = new System.Drawing.Size(150, 32);
            this.btnXuatExcelDoanhThu.TabIndex = 5;
            this.btnXuatExcelDoanhThu.Text = "Xuất Excel Báo Cáo";
            this.btnXuatExcelDoanhThu.UseVisualStyleBackColor = false;
            this.btnXuatExcelDoanhThu.Click += new System.EventHandler(this.btnXuatExcelDoanhThu_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(500, 11);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(105, 32);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(340, 15);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 25);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(265, 19);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(66, 17);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(85, 15);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 25);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(15, 19);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(58, 17);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // tpMonAn
            // 
            this.tpMonAn.Controls.Add(this.dgvMonAn);
            this.tpMonAn.Controls.Add(this.pnlMonAnRight);
            this.tpMonAn.Location = new System.Drawing.Point(4, 26);
            this.tpMonAn.Name = "tpMonAn";
            this.tpMonAn.Padding = new System.Windows.Forms.Padding(3);
            this.tpMonAn.Size = new System.Drawing.Size(926, 501);
            this.tpMonAn.TabIndex = 1;
            this.tpMonAn.Text = "  Quản Lý Thực Đơn  ";
            this.tpMonAn.UseVisualStyleBackColor = true;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AllowUserToAddRows = false;
            this.dgvMonAn.AllowUserToDeleteRows = false;
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonAn.Location = new System.Drawing.Point(3, 3);
            this.dgvMonAn.MultiSelect = false;
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(580, 495);
            this.dgvMonAn.TabIndex = 0;
            this.dgvMonAn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonAn_CellClick);
            // 
            // pnlMonAnRight
            // 
            this.pnlMonAnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMonAnRight.Controls.Add(this.btnLamMoiMon);
            this.pnlMonAnRight.Controls.Add(this.btnXoaMon);
            this.pnlMonAnRight.Controls.Add(this.btnSuaMon);
            this.pnlMonAnRight.Controls.Add(this.btnThemMon);
            this.pnlMonAnRight.Controls.Add(this.txtDonViTinh);
            this.pnlMonAnRight.Controls.Add(this.lblDonViTinh);
            this.pnlMonAnRight.Controls.Add(this.nudDonGia);
            this.pnlMonAnRight.Controls.Add(this.lblDonGia);
            this.pnlMonAnRight.Controls.Add(this.cboDanhMuc);
            this.pnlMonAnRight.Controls.Add(this.lblDanhMuc);
            this.pnlMonAnRight.Controls.Add(this.txtTenMon);
            this.pnlMonAnRight.Controls.Add(this.lblTenMon);
            this.pnlMonAnRight.Controls.Add(this.txtMaMon);
            this.pnlMonAnRight.Controls.Add(this.lblMaMon);
            this.pnlMonAnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMonAnRight.Location = new System.Drawing.Point(583, 3);
            this.pnlMonAnRight.Name = "pnlMonAnRight";
            this.pnlMonAnRight.Size = new System.Drawing.Size(340, 495);
            this.pnlMonAnRight.TabIndex = 1;
            // 
            // btnLamMoiMon
            // 
            this.btnLamMoiMon.BackColor = System.Drawing.Color.LightGray;
            this.btnLamMoiMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiMon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoiMon.Location = new System.Drawing.Point(180, 310);
            this.btnLamMoiMon.Name = "btnLamMoiMon";
            this.btnLamMoiMon.Size = new System.Drawing.Size(135, 36);
            this.btnLamMoiMon.TabIndex = 13;
            this.btnLamMoiMon.Text = "Làm mới";
            this.btnLamMoiMon.UseVisualStyleBackColor = false;
            this.btnLamMoiMon.Click += new System.EventHandler(this.btnLamMoiMon_Click);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.BackColor = System.Drawing.Color.Crimson;
            this.btnXoaMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMon.Location = new System.Drawing.Point(25, 310);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(135, 36);
            this.btnXoaMon.TabIndex = 12;
            this.btnXoaMon.Text = "Xóa món";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnSuaMon
            // 
            this.btnSuaMon.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSuaMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaMon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSuaMon.ForeColor = System.Drawing.Color.White;
            this.btnSuaMon.Location = new System.Drawing.Point(180, 260);
            this.btnSuaMon.Name = "btnSuaMon";
            this.btnSuaMon.Size = new System.Drawing.Size(135, 36);
            this.btnSuaMon.TabIndex = 11;
            this.btnSuaMon.Text = "Cập nhật";
            this.btnSuaMon.UseVisualStyleBackColor = false;
            this.btnSuaMon.Click += new System.EventHandler(this.btnSuaMon_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThemMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(25, 260);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(135, 36);
            this.btnThemMon.TabIndex = 10;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(115, 195);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(200, 25);
            this.txtDonViTinh.TabIndex = 9;
            this.txtDonViTinh.Text = "Đĩa";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Location = new System.Drawing.Point(25, 198);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(73, 17);
            this.lblDonViTinh.TabIndex = 8;
            this.lblDonViTinh.Text = "Đơn vị tính:";
            // 
            // nudDonGia
            // 
            this.nudDonGia.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
            this.nudDonGia.Location = new System.Drawing.Point(115, 150);
            this.nudDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudDonGia.Name = "nudDonGia";
            this.nudDonGia.Size = new System.Drawing.Size(200, 25);
            this.nudDonGia.TabIndex = 7;
            this.nudDonGia.ThousandsSeparator = true;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(25, 153);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(57, 17);
            this.lblDonGia.TabIndex = 6;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(115, 105);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(200, 25);
            this.cboDanhMuc.TabIndex = 5;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(25, 108);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(69, 17);
            this.lblDanhMuc.TabIndex = 4;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(115, 60);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(200, 25);
            this.txtTenMon.TabIndex = 3;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(25, 63);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(62, 17);
            this.lblTenMon.TabIndex = 2;
            this.lblTenMon.Text = "Tên món:";
            // 
            // txtMaMon
            // 
            this.txtMaMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtMaMon.Location = new System.Drawing.Point(115, 20);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.ReadOnly = true;
            this.txtMaMon.Size = new System.Drawing.Size(200, 25);
            this.txtMaMon.TabIndex = 1;
            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Location = new System.Drawing.Point(25, 23);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(59, 17);
            this.lblMaMon.TabIndex = 0;
            this.lblMaMon.Text = "Mã món:";
            // 
            // tpTaiKhoan
            // 
            this.tpTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.tpTaiKhoan.Controls.Add(this.pnlTaiKhoanRight);
            this.tpTaiKhoan.Location = new System.Drawing.Point(4, 26);
            this.tpTaiKhoan.Name = "tpTaiKhoan";
            this.tpTaiKhoan.Padding = new System.Windows.Forms.Padding(3);
            this.tpTaiKhoan.Size = new System.Drawing.Size(926, 501);
            this.tpTaiKhoan.TabIndex = 2;
            this.tpTaiKhoan.Text = "  Quản Lý Tài Khoản  ";
            this.tpTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(3, 3);
            this.dgvTaiKhoan.MultiSelect = false;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(580, 495);
            this.dgvTaiKhoan.TabIndex = 0;
            this.dgvTaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellClick);
            // 
            // pnlTaiKhoanRight
            // 
            this.pnlTaiKhoanRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlTaiKhoanRight.Controls.Add(this.btnLamMoiTK);
            this.pnlTaiKhoanRight.Controls.Add(this.btnXoaTK);
            this.pnlTaiKhoanRight.Controls.Add(this.btnDoiMatKhau);
            this.pnlTaiKhoanRight.Controls.Add(this.btnThemTK);
            this.pnlTaiKhoanRight.Controls.Add(this.cboLoaiTK);
            this.pnlTaiKhoanRight.Controls.Add(this.lblLoaiTK);
            this.pnlTaiKhoanRight.Controls.Add(this.txtMatKhau);
            this.pnlTaiKhoanRight.Controls.Add(this.lblMatKhau);
            this.pnlTaiKhoanRight.Controls.Add(this.txtHoTen);
            this.pnlTaiKhoanRight.Controls.Add(this.lblHoTen);
            this.pnlTaiKhoanRight.Controls.Add(this.txtTenDangNhap);
            this.pnlTaiKhoanRight.Controls.Add(this.lblTenDangNhap);
            this.pnlTaiKhoanRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTaiKhoanRight.Location = new System.Drawing.Point(583, 3);
            this.pnlTaiKhoanRight.Name = "pnlTaiKhoanRight";
            this.pnlTaiKhoanRight.Size = new System.Drawing.Size(340, 495);
            this.pnlTaiKhoanRight.TabIndex = 1;
            // 
            // btnLamMoiTK
            // 
            this.btnLamMoiTK.BackColor = System.Drawing.Color.LightGray;
            this.btnLamMoiTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoiTK.Location = new System.Drawing.Point(180, 260);
            this.btnLamMoiTK.Name = "btnLamMoiTK";
            this.btnLamMoiTK.Size = new System.Drawing.Size(135, 36);
            this.btnLamMoiTK.TabIndex = 11;
            this.btnLamMoiTK.Text = "Làm mới";
            this.btnLamMoiTK.UseVisualStyleBackColor = false;
            this.btnLamMoiTK.Click += new System.EventHandler(this.btnLamMoiTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.BackColor = System.Drawing.Color.Crimson;
            this.btnXoaTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoaTK.ForeColor = System.Drawing.Color.White;
            this.btnXoaTK.Location = new System.Drawing.Point(25, 260);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(135, 36);
            this.btnXoaTK.TabIndex = 10;
            this.btnXoaTK.Text = "Xóa tài khoản";
            this.btnXoaTK.UseVisualStyleBackColor = false;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(180, 210);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(135, 36);
            this.btnDoiMatKhau.TabIndex = 9;
            this.btnDoiMatKhau.Text = "Đặt lại MK";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnThemTK
            // 
            this.btnThemTK.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThemTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThemTK.ForeColor = System.Drawing.Color.White;
            this.btnThemTK.Location = new System.Drawing.Point(25, 210);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(135, 36);
            this.btnThemTK.TabIndex = 8;
            this.btnThemTK.Text = "Thêm TK";
            this.btnThemTK.UseVisualStyleBackColor = false;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // cboLoaiTK
            // 
            this.cboLoaiTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiTK.FormattingEnabled = true;
            this.cboLoaiTK.Location = new System.Drawing.Point(125, 150);
            this.cboLoaiTK.Name = "cboLoaiTK";
            this.cboLoaiTK.Size = new System.Drawing.Size(190, 25);
            this.cboLoaiTK.TabIndex = 7;
            // 
            // lblLoaiTK
            // 
            this.lblLoaiTK.AutoSize = true;
            this.lblLoaiTK.Location = new System.Drawing.Point(20, 153);
            this.lblLoaiTK.Name = "lblLoaiTK";
            this.lblLoaiTK.Size = new System.Drawing.Size(49, 17);
            this.lblLoaiTK.TabIndex = 6;
            this.lblLoaiTK.Text = "Vai trò:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(125, 105);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(190, 25);
            this.txtMatKhau.TabIndex = 5;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(20, 108);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(65, 17);
            this.lblMatKhau.TabIndex = 4;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(125, 60);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(190, 25);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(20, 63);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(50, 17);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(125, 20);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(190, 25);
            this.txtTenDangNhap.TabIndex = 1;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(20, 23);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(98, 17);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // frmQuanTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 531);
            this.Controls.Add(this.tcQuanTri);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "frmQuanTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Điều Khiển Quản Trị Hệ Thống";
            this.Load += new System.EventHandler(this.frmQuanTri_Load);
            this.tcQuanTri.ResumeLayout(false);
            this.tpDoanhThu.ResumeLayout(false);
            this.pnlBottomDoanhThu.ResumeLayout(false);
            this.pnlBottomDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.pnlTopDoanhThu.ResumeLayout(false);
            this.pnlTopDoanhThu.PerformLayout();
            this.tpMonAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.pnlMonAnRight.ResumeLayout(false);
            this.pnlMonAnRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).EndInit();
            this.tpTaiKhoan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.pnlTaiKhoanRight.ResumeLayout(false);
            this.pnlTaiKhoanRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tcQuanTri;
        private System.Windows.Forms.TabPage tpDoanhThu;
        private System.Windows.Forms.TabPage tpMonAn;
        private System.Windows.Forms.TabPage tpTaiKhoan;
        private System.Windows.Forms.Panel pnlTopDoanhThu;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuatExcelDoanhThu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Panel pnlBottomDoanhThu;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.Panel pnlMonAnRight;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown nudDonGia;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnSuaMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnLamMoiMon;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Panel pnlTaiKhoanRight;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblLoaiTK;
        private System.Windows.Forms.ComboBox cboLoaiTK;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Button btnLamMoiTK;
    }
}