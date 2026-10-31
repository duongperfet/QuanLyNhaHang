namespace QuanLyNhaHang.GUI
{
    partial class frmThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;

        // Left Panel Controls
        private System.Windows.Forms.Panel pnlHeaderInfo;
        private System.Windows.Forms.Label lblTitleLeft;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Panel pnlDivider1;
        private System.Windows.Forms.Label lblTienTamTinh;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblPhaiThuTitle;
        private System.Windows.Forms.Label lblPhaiThuValue;

        private System.Windows.Forms.GroupBox grpHinhThuc;
        private System.Windows.Forms.RadioButton rdoChuyenKhoan;
        private System.Windows.Forms.RadioButton rdoTienMat;

        private System.Windows.Forms.Panel pnlQRConfig;
        private System.Windows.Forms.Label lblNganHang;
        private System.Windows.Forms.ComboBox cboNganHang;
        private System.Windows.Forms.Label lblSoTK;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.Label lblChuTK;
        private System.Windows.Forms.TextBox txtChuTK;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnTaoHoaDonQR;

        private System.Windows.Forms.Panel pnlTienMatConfig;
        private System.Windows.Forms.Label lblKhachDua;
        private System.Windows.Forms.TextBox txtKhachDua;
        private System.Windows.Forms.Button btnQuickDuaDu;
        private System.Windows.Forms.Button btnQuick100k;
        private System.Windows.Forms.Button btnQuick200k;
        private System.Windows.Forms.Button btnQuick500k;
        private System.Windows.Forms.Label lblTienThuaTitle;
        private System.Windows.Forms.Label lblTienThuaValue;
        private System.Windows.Forms.Button btnTaoHoaDonTienMat;

        private System.Windows.Forms.Button btnDong;

        // Right Panel (Bill Paper) Controls
        private System.Windows.Forms.Panel pnlBillPaper;
        private System.Windows.Forms.Panel pnlPlaceholder;
        private System.Windows.Forms.Label lblPlaceholderIcon;
        private System.Windows.Forms.Label lblPlaceholderTitle;
        private System.Windows.Forms.Label lblPlaceholderDesc;

        private System.Windows.Forms.Panel pnlBillContent;
        private System.Windows.Forms.Label lblRestaurantName;
        private System.Windows.Forms.Label lblRestaurantSub;
        private System.Windows.Forms.Label lblBillDashed1;
        private System.Windows.Forms.Label lblBillHeaderTitle;
        private System.Windows.Forms.Label lblBillInfoBan;
        private System.Windows.Forms.Label lblBillInfoTime;
        private System.Windows.Forms.ListView lsvChiTietMon;
        private System.Windows.Forms.ColumnHeader colSTT;
        private System.Windows.Forms.ColumnHeader colTenMon;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colDonGia;
        private System.Windows.Forms.ColumnHeader colThanhTien;

        private System.Windows.Forms.Panel pnlBillBottom;
        private System.Windows.Forms.Panel pnlBillSummary;
        private System.Windows.Forms.Label lblSummaryTienMon;
        private System.Windows.Forms.Label lblSummaryGiamGia;
        private System.Windows.Forms.Label lblSummaryTongCong;
        private System.Windows.Forms.Label lblSummaryPhuongThuc;
        private System.Windows.Forms.Label lblSummaryBankInfo;
        private System.Windows.Forms.Button btnCopySTK;
        private System.Windows.Forms.Button btnLuuQR;

        private System.Windows.Forms.Panel pnlQRDisplay;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblQRGuide;

        private System.Windows.Forms.Label lblBillDashed2;
        private System.Windows.Forms.Label lblThankYou;
        private System.Windows.Forms.Button btnHoanTatThanhToan;

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
            btnDong = new Button();
            pnlTienMatConfig = new Panel();
            btnTaoHoaDonTienMat = new Button();
            lblTienThuaValue = new Label();
            lblTienThuaTitle = new Label();
            btnQuick500k = new Button();
            btnQuick200k = new Button();
            btnQuick100k = new Button();
            btnQuickDuaDu = new Button();
            txtKhachDua = new TextBox();
            lblKhachDua = new Label();
            pnlQRConfig = new Panel();
            btnTaoHoaDonQR = new Button();
            txtNoiDung = new TextBox();
            lblNoiDung = new Label();
            txtChuTK = new TextBox();
            lblChuTK = new Label();
            txtSoTK = new TextBox();
            lblSoTK = new Label();
            cboNganHang = new ComboBox();
            lblNganHang = new Label();
            grpHinhThuc = new GroupBox();
            rdoTienMat = new RadioButton();
            rdoChuyenKhoan = new RadioButton();
            pnlHeaderInfo = new Panel();
            lblPhaiThuValue = new Label();
            lblPhaiThuTitle = new Label();
            lblGiamGia = new Label();
            lblTienTamTinh = new Label();
            pnlDivider1 = new Panel();
            lblThoiGian = new Label();
            lblMaHoaDon = new Label();
            lblTenBan = new Label();
            lblTitleLeft = new Label();
            pnlRight = new Panel();
            pnlBillPaper = new Panel();
            pnlBillContent = new Panel();
            btnHoanTatThanhToan = new Button();
            lblThankYou = new Label();
            lblBillDashed2 = new Label();
            pnlBillBottom = new Panel();
            pnlQRDisplay = new Panel();
            lblQRGuide = new Label();
            picQR = new PictureBox();
            pnlBillSummary = new Panel();
            btnLuuQR = new Button();
            btnCopySTK = new Button();
            lblSummaryBankInfo = new Label();
            lblSummaryPhuongThuc = new Label();
            lblSummaryTongCong = new Label();
            lblSummaryGiamGia = new Label();
            lblSummaryTienMon = new Label();
            lsvChiTietMon = new ListView();
            colSTT = new ColumnHeader();
            colTenMon = new ColumnHeader();
            colSoLuong = new ColumnHeader();
            colDonGia = new ColumnHeader();
            colThanhTien = new ColumnHeader();
            lblBillInfoTime = new Label();
            lblBillInfoBan = new Label();
            lblBillHeaderTitle = new Label();
            lblBillDashed1 = new Label();
            lblRestaurantSub = new Label();
            lblRestaurantName = new Label();
            pnlPlaceholder = new Panel();
            lblPlaceholderDesc = new Label();
            lblPlaceholderTitle = new Label();
            lblPlaceholderIcon = new Label();
            pnlLeft.SuspendLayout();
            pnlTienMatConfig.SuspendLayout();
            pnlQRConfig.SuspendLayout();
            grpHinhThuc.SuspendLayout();
            pnlHeaderInfo.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBillPaper.SuspendLayout();
            pnlBillContent.SuspendLayout();
            pnlBillBottom.SuspendLayout();
            pnlQRDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            pnlBillSummary.SuspendLayout();
            pnlPlaceholder.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(248, 246, 240);
            pnlLeft.Controls.Add(btnDong);
            pnlLeft.Controls.Add(pnlQRConfig);
            pnlLeft.Controls.Add(pnlTienMatConfig);
            pnlLeft.Controls.Add(grpHinhThuc);
            pnlLeft.Controls.Add(pnlHeaderInfo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(12);
            pnlLeft.Size = new Size(380, 671);
            pnlLeft.TabIndex = 0;
            // 
            // btnDong
            // 
            btnDong.BackColor = Color.White;
            btnDong.Cursor = Cursors.Hand;
            btnDong.DialogResult = DialogResult.Cancel;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnDong.ForeColor = Color.FromArgb(100, 100, 100);
            btnDong.Location = new Point(12, 624);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(356, 35);
            btnDong.TabIndex = 4;
            btnDong.Text = "✕ Đóng / Hủy bỏ";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // pnlTienMatConfig
            // 
            pnlTienMatConfig.BackColor = Color.White;
            pnlTienMatConfig.BorderStyle = BorderStyle.FixedSingle;
            pnlTienMatConfig.Controls.Add(btnTaoHoaDonTienMat);
            pnlTienMatConfig.Controls.Add(lblTienThuaValue);
            pnlTienMatConfig.Controls.Add(lblTienThuaTitle);
            pnlTienMatConfig.Controls.Add(btnQuick500k);
            pnlTienMatConfig.Controls.Add(btnQuick200k);
            pnlTienMatConfig.Controls.Add(btnQuick100k);
            pnlTienMatConfig.Controls.Add(btnQuickDuaDu);
            pnlTienMatConfig.Controls.Add(txtKhachDua);
            pnlTienMatConfig.Controls.Add(lblKhachDua);
            pnlTienMatConfig.Location = new Point(12, 276);
            pnlTienMatConfig.Name = "pnlTienMatConfig";
            pnlTienMatConfig.Padding = new Padding(10);
            pnlTienMatConfig.Size = new Size(356, 338);
            pnlTienMatConfig.TabIndex = 3;
            pnlTienMatConfig.Visible = false;
            // 
            // btnTaoHoaDonTienMat
            // 
            btnTaoHoaDonTienMat.BackColor = Color.FromArgb(83, 99, 61);
            btnTaoHoaDonTienMat.Cursor = Cursors.Hand;
            btnTaoHoaDonTienMat.FlatStyle = FlatStyle.Flat;
            btnTaoHoaDonTienMat.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnTaoHoaDonTienMat.ForeColor = Color.White;
            btnTaoHoaDonTienMat.Location = new Point(10, 275);
            btnTaoHoaDonTienMat.Name = "btnTaoHoaDonTienMat";
            btnTaoHoaDonTienMat.Size = new Size(334, 45);
            btnTaoHoaDonTienMat.TabIndex = 8;
            btnTaoHoaDonTienMat.Text = "👉 XÁC NHẬN TẠO HÓA ĐƠN TIỀN MẶT";
            btnTaoHoaDonTienMat.UseVisualStyleBackColor = false;
            btnTaoHoaDonTienMat.Click += btnTaoHoaDonTienMat_Click;
            // 
            // lblTienThuaValue
            // 
            lblTienThuaValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblTienThuaValue.ForeColor = Color.FromArgb(83, 99, 61);
            lblTienThuaValue.Location = new Point(10, 225);
            lblTienThuaValue.Name = "lblTienThuaValue";
            lblTienThuaValue.Size = new Size(334, 30);
            lblTienThuaValue.TabIndex = 7;
            lblTienThuaValue.Text = "0 VNĐ";
            lblTienThuaValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTienThuaTitle
            // 
            lblTienThuaTitle.AutoSize = true;
            lblTienThuaTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTienThuaTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblTienThuaTitle.Location = new Point(10, 205);
            lblTienThuaTitle.Name = "lblTienThuaTitle";
            lblTienThuaTitle.Size = new Size(130, 17);
            lblTienThuaTitle.TabIndex = 6;
            lblTienThuaTitle.Text = "Tiền thừa trả khách:";
            // 
            // btnQuick500k
            // 
            btnQuick500k.BackColor = Color.FromArgb(245, 245, 245);
            btnQuick500k.FlatStyle = FlatStyle.Flat;
            btnQuick500k.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnQuick500k.Location = new Point(180, 125);
            btnQuick500k.Name = "btnQuick500k";
            btnQuick500k.Size = new Size(164, 32);
            btnQuick500k.TabIndex = 5;
            btnQuick500k.Text = "500.000";
            btnQuick500k.UseVisualStyleBackColor = false;
            btnQuick500k.Click += btnQuickMoney_Click;
            // 
            // btnQuick200k
            // 
            btnQuick200k.BackColor = Color.FromArgb(245, 245, 245);
            btnQuick200k.FlatStyle = FlatStyle.Flat;
            btnQuick200k.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnQuick200k.Location = new Point(10, 125);
            btnQuick200k.Name = "btnQuick200k";
            btnQuick200k.Size = new Size(164, 32);
            btnQuick200k.TabIndex = 4;
            btnQuick200k.Text = "200.000";
            btnQuick200k.UseVisualStyleBackColor = false;
            btnQuick200k.Click += btnQuickMoney_Click;
            // 
            // btnQuick100k
            // 
            btnQuick100k.BackColor = Color.FromArgb(245, 245, 245);
            btnQuick100k.FlatStyle = FlatStyle.Flat;
            btnQuick100k.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnQuick100k.Location = new Point(180, 85);
            btnQuick100k.Name = "btnQuick100k";
            btnQuick100k.Size = new Size(164, 32);
            btnQuick100k.TabIndex = 3;
            btnQuick100k.Text = "100.000";
            btnQuick100k.UseVisualStyleBackColor = false;
            btnQuick100k.Click += btnQuickMoney_Click;
            // 
            // btnQuickDuaDu
            // 
            btnQuickDuaDu.BackColor = Color.FromArgb(239, 242, 231);
            btnQuickDuaDu.FlatStyle = FlatStyle.Flat;
            btnQuickDuaDu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnQuickDuaDu.ForeColor = Color.FromArgb(83, 99, 61);
            btnQuickDuaDu.Location = new Point(10, 85);
            btnQuickDuaDu.Name = "btnQuickDuaDu";
            btnQuickDuaDu.Size = new Size(164, 32);
            btnQuickDuaDu.TabIndex = 2;
            btnQuickDuaDu.Text = "Đưa đủ";
            btnQuickDuaDu.UseVisualStyleBackColor = false;
            btnQuickDuaDu.Click += btnQuickDuaDu_Click;
            // 
            // txtKhachDua
            // 
            txtKhachDua.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtKhachDua.Location = new Point(10, 40);
            txtKhachDua.Name = "txtKhachDua";
            txtKhachDua.Size = new Size(334, 29);
            txtKhachDua.TabIndex = 1;
            txtKhachDua.TextAlign = HorizontalAlignment.Right;
            txtKhachDua.TextChanged += txtKhachDua_TextChanged;
            // 
            // lblKhachDua
            // 
            lblKhachDua.AutoSize = true;
            lblKhachDua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblKhachDua.Location = new Point(10, 15);
            lblKhachDua.Name = "lblKhachDua";
            lblKhachDua.Size = new Size(157, 17);
            lblKhachDua.TabIndex = 0;
            lblKhachDua.Text = "Số tiền khách đưa (VNĐ):";
            // 
            // pnlQRConfig
            // 
            pnlQRConfig.BackColor = Color.White;
            pnlQRConfig.BorderStyle = BorderStyle.FixedSingle;
            pnlQRConfig.Controls.Add(btnTaoHoaDonQR);
            pnlQRConfig.Controls.Add(txtNoiDung);
            pnlQRConfig.Controls.Add(lblNoiDung);
            pnlQRConfig.Controls.Add(txtChuTK);
            pnlQRConfig.Controls.Add(lblChuTK);
            pnlQRConfig.Controls.Add(txtSoTK);
            pnlQRConfig.Controls.Add(lblSoTK);
            pnlQRConfig.Controls.Add(cboNganHang);
            pnlQRConfig.Controls.Add(lblNganHang);
            pnlQRConfig.Location = new Point(12, 276);
            pnlQRConfig.Name = "pnlQRConfig";
            pnlQRConfig.Padding = new Padding(10);
            pnlQRConfig.Size = new Size(356, 338);
            pnlQRConfig.TabIndex = 2;
            // 
            // btnTaoHoaDonQR
            // 
            btnTaoHoaDonQR.BackColor = Color.FromArgb(143, 57, 65);
            btnTaoHoaDonQR.Cursor = Cursors.Hand;
            btnTaoHoaDonQR.FlatStyle = FlatStyle.Flat;
            btnTaoHoaDonQR.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnTaoHoaDonQR.ForeColor = Color.White;
            btnTaoHoaDonQR.Location = new Point(10, 275);
            btnTaoHoaDonQR.Name = "btnTaoHoaDonQR";
            btnTaoHoaDonQR.Size = new Size(334, 45);
            btnTaoHoaDonQR.TabIndex = 8;
            btnTaoHoaDonQR.Text = "👉 XÁC NHẬN TẠO HÓA ĐƠN & MÃ QR";
            btnTaoHoaDonQR.UseVisualStyleBackColor = false;
            btnTaoHoaDonQR.Click += btnTaoHoaDonQR_Click;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            txtNoiDung.Location = new Point(10, 228);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(334, 24);
            txtNoiDung.TabIndex = 7;
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNoiDung.ForeColor = Color.FromArgb(100, 100, 100);
            lblNoiDung.Location = new Point(10, 208);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(130, 15);
            lblNoiDung.TabIndex = 6;
            lblNoiDung.Text = "Nội dung chuyển khoản:";
            // 
            // txtChuTK
            // 
            txtChuTK.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            txtChuTK.Location = new Point(10, 165);
            txtChuTK.Name = "txtChuTK";
            txtChuTK.Size = new Size(334, 24);
            txtChuTK.TabIndex = 5;
            txtChuTK.Text = "VO TUNG DUONG";
            // 
            // lblChuTK
            // 
            lblChuTK.AutoSize = true;
            lblChuTK.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblChuTK.ForeColor = Color.FromArgb(100, 100, 100);
            lblChuTK.Location = new Point(10, 145);
            lblChuTK.Name = "lblChuTK";
            lblChuTK.Size = new Size(106, 15);
            lblChuTK.TabIndex = 4;
            lblChuTK.Text = "Tên chủ tài khoản:";
            // 
            // txtSoTK
            // 
            txtSoTK.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            txtSoTK.ForeColor = Color.FromArgb(0, 102, 179);
            txtSoTK.Location = new Point(10, 102);
            txtSoTK.Name = "txtSoTK";
            txtSoTK.Size = new Size(334, 25);
            txtSoTK.TabIndex = 3;
            txtSoTK.Text = "0889294024";
            // 
            // lblSoTK
            // 
            lblSoTK.AutoSize = true;
            lblSoTK.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSoTK.ForeColor = Color.FromArgb(100, 100, 100);
            lblSoTK.Location = new Point(10, 82);
            lblSoTK.Name = "lblSoTK";
            lblSoTK.Size = new Size(135, 15);
            lblSoTK.TabIndex = 2;
            lblSoTK.Text = "Số tài khoản ngân hàng:";
            // 
            // cboNganHang
            // 
            cboNganHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNganHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cboNganHang.FormattingEnabled = true;
            cboNganHang.Location = new Point(10, 39);
            cboNganHang.Name = "cboNganHang";
            cboNganHang.Size = new Size(334, 25);
            cboNganHang.TabIndex = 1;
            // 
            // lblNganHang
            // 
            lblNganHang.AutoSize = true;
            lblNganHang.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNganHang.ForeColor = Color.FromArgb(100, 100, 100);
            lblNganHang.Location = new Point(10, 18);
            lblNganHang.Name = "lblNganHang";
            lblNganHang.Size = new Size(130, 15);
            lblNganHang.TabIndex = 0;
            lblNganHang.Text = "Ngân hàng thụ hưởng:";
            // 
            // grpHinhThuc
            // 
            grpHinhThuc.BackColor = Color.White;
            grpHinhThuc.Controls.Add(rdoTienMat);
            grpHinhThuc.Controls.Add(rdoChuyenKhoan);
            grpHinhThuc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            grpHinhThuc.ForeColor = Color.FromArgb(83, 99, 61);
            grpHinhThuc.Location = new Point(12, 195);
            grpHinhThuc.Name = "grpHinhThuc";
            grpHinhThuc.Size = new Size(356, 70);
            grpHinhThuc.TabIndex = 1;
            grpHinhThuc.TabStop = false;
            grpHinhThuc.Text = "Hình thức thanh toán";
            // 
            // rdoTienMat
            // 
            rdoTienMat.AutoSize = true;
            rdoTienMat.Cursor = Cursors.Hand;
            rdoTienMat.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdoTienMat.ForeColor = Color.FromArgb(43, 45, 39);
            rdoTienMat.Location = new Point(245, 30);
            rdoTienMat.Name = "rdoTienMat";
            rdoTienMat.Size = new Size(71, 19);
            rdoTienMat.TabIndex = 1;
            rdoTienMat.Text = "Tiền mặt";
            rdoTienMat.UseVisualStyleBackColor = true;
            rdoTienMat.CheckedChanged += rdoHinhThuc_CheckedChanged;
            // 
            // rdoChuyenKhoan
            // 
            rdoChuyenKhoan.AutoSize = true;
            rdoChuyenKhoan.Checked = true;
            rdoChuyenKhoan.Cursor = Cursors.Hand;
            rdoChuyenKhoan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            rdoChuyenKhoan.ForeColor = Color.FromArgb(143, 57, 65);
            rdoChuyenKhoan.Location = new Point(15, 30);
            rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            rdoChuyenKhoan.Size = new Size(205, 19);
            rdoChuyenKhoan.TabIndex = 0;
            rdoChuyenKhoan.TabStop = true;
            rdoChuyenKhoan.Text = "Chuyển khoản QR (VietQR)";
            rdoChuyenKhoan.UseVisualStyleBackColor = true;
            rdoChuyenKhoan.CheckedChanged += rdoHinhThuc_CheckedChanged;
            // 
            // pnlHeaderInfo
            // 
            pnlHeaderInfo.BackColor = Color.White;
            pnlHeaderInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlHeaderInfo.Controls.Add(lblPhaiThuValue);
            pnlHeaderInfo.Controls.Add(lblPhaiThuTitle);
            pnlHeaderInfo.Controls.Add(lblGiamGia);
            pnlHeaderInfo.Controls.Add(lblTienTamTinh);
            pnlHeaderInfo.Controls.Add(pnlDivider1);
            pnlHeaderInfo.Controls.Add(lblThoiGian);
            pnlHeaderInfo.Controls.Add(lblMaHoaDon);
            pnlHeaderInfo.Controls.Add(lblTenBan);
            pnlHeaderInfo.Controls.Add(lblTitleLeft);
            pnlHeaderInfo.Location = new Point(12, 12);
            pnlHeaderInfo.Name = "pnlHeaderInfo";
            pnlHeaderInfo.Padding = new Padding(10);
            pnlHeaderInfo.Size = new Size(356, 175);
            pnlHeaderInfo.TabIndex = 0;
            // 
            // lblPhaiThuValue
            // 
            lblPhaiThuValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblPhaiThuValue.ForeColor = Color.FromArgb(143, 57, 65);
            lblPhaiThuValue.Location = new Point(125, 137);
            lblPhaiThuValue.Name = "lblPhaiThuValue";
            lblPhaiThuValue.Size = new Size(219, 28);
            lblPhaiThuValue.TabIndex = 8;
            lblPhaiThuValue.Text = "0 VNĐ";
            lblPhaiThuValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPhaiThuTitle
            // 
            lblPhaiThuTitle.AutoSize = true;
            lblPhaiThuTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblPhaiThuTitle.ForeColor = Color.FromArgb(143, 57, 65);
            lblPhaiThuTitle.Location = new Point(10, 142);
            lblPhaiThuTitle.Name = "lblPhaiThuTitle";
            lblPhaiThuTitle.Size = new Size(111, 19);
            lblPhaiThuTitle.TabIndex = 7;
            lblPhaiThuTitle.Text = "CẦN THU (VND):";
            // 
            // lblGiamGia
            // 
            lblGiamGia.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblGiamGia.ForeColor = Color.FromArgb(100, 100, 100);
            lblGiamGia.Location = new Point(10, 114);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(334, 18);
            lblGiamGia.TabIndex = 6;
            lblGiamGia.Text = "Giảm giá: 0% (-0 VNĐ)";
            lblGiamGia.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTienTamTinh
            // 
            lblTienTamTinh.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblTienTamTinh.ForeColor = Color.FromArgb(43, 45, 39);
            lblTienTamTinh.Location = new Point(10, 92);
            lblTienTamTinh.Name = "lblTienTamTinh";
            lblTienTamTinh.Size = new Size(334, 20);
            lblTienTamTinh.TabIndex = 5;
            lblTienTamTinh.Text = "Tiền món: 0 VNĐ";
            lblTienTamTinh.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlDivider1
            // 
            pnlDivider1.BackColor = Color.FromArgb(226, 222, 210);
            pnlDivider1.Location = new Point(10, 83);
            pnlDivider1.Name = "pnlDivider1";
            pnlDivider1.Size = new Size(334, 1);
            pnlDivider1.TabIndex = 4;
            // 
            // lblThoiGian
            // 
            lblThoiGian.AutoSize = true;
            lblThoiGian.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic, GraphicsUnit.Point);
            lblThoiGian.ForeColor = Color.FromArgb(120, 120, 120);
            lblThoiGian.Location = new Point(10, 60);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(130, 15);
            lblThoiGian.TabIndex = 3;
            lblThoiGian.Text = "Thời gian: 31/10/2026";
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaHoaDon.ForeColor = Color.FromArgb(70, 70, 70);
            lblMaHoaDon.Location = new Point(220, 36);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(101, 17);
            lblMaHoaDon.TabIndex = 2;
            lblMaHoaDon.Text = "Hóa Đơn: #HD01";
            lblMaHoaDon.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTenBan
            // 
            lblTenBan.AutoSize = true;
            lblTenBan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenBan.ForeColor = Color.FromArgb(83, 99, 61);
            lblTenBan.Location = new Point(10, 33);
            lblTenBan.Name = "lblTenBan";
            lblTenBan.Size = new Size(68, 21);
            lblTenBan.TabIndex = 1;
            lblTenBan.Text = "BÀN 01";
            // 
            // lblTitleLeft
            // 
            lblTitleLeft.AutoSize = true;
            lblTitleLeft.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitleLeft.ForeColor = Color.FromArgb(143, 57, 65);
            lblTitleLeft.Location = new Point(10, 8);
            lblTitleLeft.Name = "lblTitleLeft";
            lblTitleLeft.Size = new Size(169, 19);
            lblTitleLeft.TabIndex = 0;
            lblTitleLeft.Text = "THÔNG TIN THANH TOÁN";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(238, 236, 230);
            pnlRight.Controls.Add(pnlBillPaper);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(380, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(12);
            pnlRight.Size = new Size(624, 671);
            pnlRight.TabIndex = 1;
            // 
            // pnlBillPaper
            // 
            pnlBillPaper.BackColor = Color.White;
            pnlBillPaper.BorderStyle = BorderStyle.FixedSingle;
            pnlBillPaper.Controls.Add(pnlBillContent);
            pnlBillPaper.Controls.Add(pnlPlaceholder);
            pnlBillPaper.Dock = DockStyle.Fill;
            pnlBillPaper.Location = new Point(12, 12);
            pnlBillPaper.Name = "pnlBillPaper";
            pnlBillPaper.Padding = new Padding(14);
            pnlBillPaper.Size = new Size(600, 647);
            pnlBillPaper.TabIndex = 0;
            // 
            // pnlBillContent
            // 
            pnlBillContent.Controls.Add(btnHoanTatThanhToan);
            pnlBillContent.Controls.Add(lblThankYou);
            pnlBillContent.Controls.Add(lblBillDashed2);
            pnlBillContent.Controls.Add(pnlBillBottom);
            pnlBillContent.Controls.Add(lsvChiTietMon);
            pnlBillContent.Controls.Add(lblBillInfoTime);
            pnlBillContent.Controls.Add(lblBillInfoBan);
            pnlBillContent.Controls.Add(lblBillHeaderTitle);
            pnlBillContent.Controls.Add(lblBillDashed1);
            pnlBillContent.Controls.Add(lblRestaurantSub);
            pnlBillContent.Controls.Add(lblRestaurantName);
            pnlBillContent.Dock = DockStyle.Fill;
            pnlBillContent.Location = new Point(14, 14);
            pnlBillContent.Name = "pnlBillContent";
            pnlBillContent.Size = new Size(570, 617);
            pnlBillContent.TabIndex = 1;
            pnlBillContent.Visible = false;
            // 
            // btnHoanTatThanhToan
            // 
            btnHoanTatThanhToan.BackColor = Color.FromArgb(83, 99, 61);
            btnHoanTatThanhToan.Cursor = Cursors.Hand;
            btnHoanTatThanhToan.FlatStyle = FlatStyle.Flat;
            btnHoanTatThanhToan.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnHoanTatThanhToan.ForeColor = Color.White;
            btnHoanTatThanhToan.Location = new Point(5, 565);
            btnHoanTatThanhToan.Name = "btnHoanTatThanhToan";
            btnHoanTatThanhToan.Size = new Size(560, 46);
            btnHoanTatThanhToan.TabIndex = 10;
            btnHoanTatThanhToan.Text = "✔ XÁC NHẬN ĐÃ NHẬN TIỀN & HOÀN TẤT";
            btnHoanTatThanhToan.UseVisualStyleBackColor = false;
            btnHoanTatThanhToan.Click += btnHoanTatThanhToan_Click;
            // 
            // lblThankYou
            // 
            lblThankYou.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblThankYou.ForeColor = Color.FromArgb(120, 120, 120);
            lblThankYou.Location = new Point(5, 540);
            lblThankYou.Name = "lblThankYou";
            lblThankYou.Size = new Size(560, 18);
            lblThankYou.TabIndex = 9;
            lblThankYou.Text = "Cảm ơn quý khách và hẹn gặp lại!  •  Grazie e arrivederci!";
            lblThankYou.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBillDashed2
            // 
            lblBillDashed2.ForeColor = Color.FromArgb(180, 180, 180);
            lblBillDashed2.Location = new Point(5, 523);
            lblBillDashed2.Name = "lblBillDashed2";
            lblBillDashed2.Size = new Size(560, 14);
            lblBillDashed2.TabIndex = 8;
            lblBillDashed2.Text = "------------------------------------------------------------------------------------------------------------------------";
            lblBillDashed2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBillBottom
            // 
            pnlBillBottom.Controls.Add(pnlQRDisplay);
            pnlBillBottom.Controls.Add(pnlBillSummary);
            pnlBillBottom.Location = new Point(5, 298);
            pnlBillBottom.Name = "pnlBillBottom";
            pnlBillBottom.Size = new Size(560, 222);
            pnlBillBottom.TabIndex = 7;
            // 
            // pnlQRDisplay
            // 
            pnlQRDisplay.Controls.Add(lblQRGuide);
            pnlQRDisplay.Controls.Add(picQR);
            pnlQRDisplay.Dock = DockStyle.Right;
            pnlQRDisplay.Location = new Point(310, 0);
            pnlQRDisplay.Name = "pnlQRDisplay";
            pnlQRDisplay.Size = new Size(250, 222);
            pnlQRDisplay.TabIndex = 1;
            // 
            // lblQRGuide
            // 
            lblQRGuide.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lblQRGuide.ForeColor = Color.FromArgb(90, 90, 90);
            lblQRGuide.Location = new Point(5, 198);
            lblQRGuide.Name = "lblQRGuide";
            lblQRGuide.Size = new Size(240, 20);
            lblQRGuide.TabIndex = 1;
            lblQRGuide.Text = "Quét bằng App Ngân hàng hoặc MoMo";
            lblQRGuide.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picQR
            // 
            picQR.BackColor = Color.FromArgb(250, 250, 250);
            picQR.BorderStyle = BorderStyle.FixedSingle;
            picQR.Location = new Point(25, 2);
            picQR.Name = "picQR";
            picQR.Size = new Size(200, 194);
            picQR.SizeMode = PictureBoxSizeMode.Zoom;
            picQR.TabIndex = 0;
            picQR.TabStop = false;
            // 
            // pnlBillSummary
            // 
            pnlBillSummary.Controls.Add(btnLuuQR);
            pnlBillSummary.Controls.Add(btnCopySTK);
            pnlBillSummary.Controls.Add(lblSummaryBankInfo);
            pnlBillSummary.Controls.Add(lblSummaryPhuongThuc);
            pnlBillSummary.Controls.Add(lblSummaryTongCong);
            pnlBillSummary.Controls.Add(lblSummaryGiamGia);
            pnlBillSummary.Controls.Add(lblSummaryTienMon);
            pnlBillSummary.Dock = DockStyle.Left;
            pnlBillSummary.Location = new Point(0, 0);
            pnlBillSummary.Name = "pnlBillSummary";
            pnlBillSummary.Size = new Size(300, 222);
            pnlBillSummary.TabIndex = 0;
            // 
            // btnLuuQR
            // 
            btnLuuQR.BackColor = Color.FromArgb(245, 245, 245);
            btnLuuQR.Cursor = Cursors.Hand;
            btnLuuQR.FlatStyle = FlatStyle.Flat;
            btnLuuQR.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnLuuQR.Location = new Point(150, 175);
            btnLuuQR.Name = "btnLuuQR";
            btnLuuQR.Size = new Size(135, 34);
            btnLuuQR.TabIndex = 6;
            btnLuuQR.Text = "💾 Lưu ảnh QR";
            btnLuuQR.UseVisualStyleBackColor = false;
            btnLuuQR.Click += btnLuuQR_Click;
            // 
            // btnCopySTK
            // 
            btnCopySTK.BackColor = Color.FromArgb(245, 245, 245);
            btnCopySTK.Cursor = Cursors.Hand;
            btnCopySTK.FlatStyle = FlatStyle.Flat;
            btnCopySTK.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnCopySTK.Location = new Point(5, 175);
            btnCopySTK.Name = "btnCopySTK";
            btnCopySTK.Size = new Size(135, 34);
            btnCopySTK.TabIndex = 5;
            btnCopySTK.Text = "📋 Sao chép STK";
            btnCopySTK.UseVisualStyleBackColor = false;
            btnCopySTK.Click += btnCopySTK_Click;
            // 
            // lblSummaryBankInfo
            // 
            lblSummaryBankInfo.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummaryBankInfo.ForeColor = Color.FromArgb(60, 60, 60);
            lblSummaryBankInfo.Location = new Point(5, 105);
            lblSummaryBankInfo.Name = "lblSummaryBankInfo";
            lblSummaryBankInfo.Size = new Size(290, 65);
            lblSummaryBankInfo.TabIndex = 4;
            lblSummaryBankInfo.Text = "MB Bank  •  STK: 0889294024\nChủ TK: VO TUNG DUONG\nCú pháp: THANHTOAN BAN01 HD01";
            // 
            // lblSummaryPhuongThuc
            // 
            lblSummaryPhuongThuc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummaryPhuongThuc.ForeColor = Color.FromArgb(83, 99, 61);
            lblSummaryPhuongThuc.Location = new Point(5, 80);
            lblSummaryPhuongThuc.Name = "lblSummaryPhuongThuc";
            lblSummaryPhuongThuc.Size = new Size(290, 20);
            lblSummaryPhuongThuc.TabIndex = 3;
            lblSummaryPhuongThuc.Text = "Hình thức: Chuyển khoản QR (VietQR)";
            // 
            // lblSummaryTongCong
            // 
            lblSummaryTongCong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummaryTongCong.ForeColor = Color.FromArgb(143, 57, 65);
            lblSummaryTongCong.Location = new Point(5, 50);
            lblSummaryTongCong.Name = "lblSummaryTongCong";
            lblSummaryTongCong.Size = new Size(290, 26);
            lblSummaryTongCong.TabIndex = 2;
            lblSummaryTongCong.Text = "TỔNG CỘNG: 0 VNĐ";
            // 
            // lblSummaryGiamGia
            // 
            lblSummaryGiamGia.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummaryGiamGia.ForeColor = Color.FromArgb(90, 90, 90);
            lblSummaryGiamGia.Location = new Point(5, 28);
            lblSummaryGiamGia.Name = "lblSummaryGiamGia";
            lblSummaryGiamGia.Size = new Size(290, 18);
            lblSummaryGiamGia.TabIndex = 1;
            lblSummaryGiamGia.Text = "Giảm giá: 0%";
            // 
            // lblSummaryTienMon
            // 
            lblSummaryTienMon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummaryTienMon.Location = new Point(5, 6);
            lblSummaryTienMon.Name = "lblSummaryTienMon";
            lblSummaryTienMon.Size = new Size(290, 18);
            lblSummaryTienMon.TabIndex = 0;
            lblSummaryTienMon.Text = "Tổng tiền món: 0 VNĐ";
            // 
            // lsvChiTietMon
            // 
            lsvChiTietMon.BorderStyle = BorderStyle.FixedSingle;
            lsvChiTietMon.Columns.AddRange(new ColumnHeader[] { colSTT, colTenMon, colSoLuong, colDonGia, colThanhTien });
            lsvChiTietMon.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lsvChiTietMon.FullRowSelect = true;
            lsvChiTietMon.GridLines = true;
            lsvChiTietMon.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvChiTietMon.Location = new Point(5, 108);
            lsvChiTietMon.Name = "lsvChiTietMon";
            lsvChiTietMon.Size = new Size(560, 184);
            lsvChiTietMon.TabIndex = 6;
            lsvChiTietMon.UseCompatibleStateImageBehavior = false;
            lsvChiTietMon.View = View.Details;
            // 
            // colSTT
            // 
            colSTT.Text = "STT";
            colSTT.Width = 40;
            // 
            // colTenMon
            // 
            colTenMon.Text = "Tên món";
            colTenMon.Width = 210;
            // 
            // colSoLuong
            // 
            colSoLuong.Text = "SL";
            colSoLuong.TextAlign = HorizontalAlignment.Center;
            colSoLuong.Width = 45;
            // 
            // colDonGia
            // 
            colDonGia.Text = "Đơn giá";
            colDonGia.TextAlign = HorizontalAlignment.Right;
            colDonGia.Width = 120;
            // 
            // colThanhTien
            // 
            colThanhTien.Text = "Thành tiền";
            colThanhTien.TextAlign = HorizontalAlignment.Right;
            colThanhTien.Width = 135;
            // 
            // lblBillInfoTime
            // 
            lblBillInfoTime.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblBillInfoTime.ForeColor = Color.FromArgb(100, 100, 100);
            lblBillInfoTime.Location = new Point(280, 85);
            lblBillInfoTime.Name = "lblBillInfoTime";
            lblBillInfoTime.Size = new Size(285, 18);
            lblBillInfoTime.TabIndex = 5;
            lblBillInfoTime.Text = "Thời gian: 31/10/2026 15:30";
            lblBillInfoTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBillInfoBan
            // 
            lblBillInfoBan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblBillInfoBan.ForeColor = Color.FromArgb(83, 99, 61);
            lblBillInfoBan.Location = new Point(5, 85);
            lblBillInfoBan.Name = "lblBillInfoBan";
            lblBillInfoBan.Size = new Size(270, 18);
            lblBillInfoBan.TabIndex = 4;
            lblBillInfoBan.Text = "BÀN: BÀN 01  •  HĐ: #HD01";
            // 
            // lblBillHeaderTitle
            // 
            lblBillHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBillHeaderTitle.ForeColor = Color.FromArgb(143, 57, 65);
            lblBillHeaderTitle.Location = new Point(5, 58);
            lblBillHeaderTitle.Name = "lblBillHeaderTitle";
            lblBillHeaderTitle.Size = new Size(560, 24);
            lblBillHeaderTitle.TabIndex = 3;
            lblBillHeaderTitle.Text = "HÓA ĐƠN THANH TOÁN";
            lblBillHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBillDashed1
            // 
            lblBillDashed1.ForeColor = Color.FromArgb(180, 180, 180);
            lblBillDashed1.Location = new Point(5, 43);
            lblBillDashed1.Name = "lblBillDashed1";
            lblBillDashed1.Size = new Size(560, 14);
            lblBillDashed1.TabIndex = 2;
            lblBillDashed1.Text = "------------------------------------------------------------------------------------------------------------------------";
            lblBillDashed1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRestaurantSub
            // 
            lblRestaurantSub.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic, GraphicsUnit.Point);
            lblRestaurantSub.ForeColor = Color.FromArgb(110, 110, 110);
            lblRestaurantSub.Location = new Point(5, 26);
            lblRestaurantSub.Name = "lblRestaurantSub";
            lblRestaurantSub.Size = new Size(560, 16);
            lblRestaurantSub.TabIndex = 1;
            lblRestaurantSub.Text = "Ẩm thực Ý cao cấp  •  Hotline: 0889.294.024  •  Tài khoản MBBank: 0889294024";
            lblRestaurantSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRestaurantName
            // 
            lblRestaurantName.Font = new Font("Georgia", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblRestaurantName.ForeColor = Color.FromArgb(83, 99, 61);
            lblRestaurantName.Location = new Point(5, 2);
            lblRestaurantName.Name = "lblRestaurantName";
            lblRestaurantName.Size = new Size(560, 24);
            lblRestaurantName.TabIndex = 0;
            lblRestaurantName.Text = "MAISON OLIVA — CUCINA & BISTROT";
            lblRestaurantName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPlaceholder
            // 
            pnlPlaceholder.Controls.Add(lblPlaceholderDesc);
            pnlPlaceholder.Controls.Add(lblPlaceholderTitle);
            pnlPlaceholder.Controls.Add(lblPlaceholderIcon);
            pnlPlaceholder.Dock = DockStyle.Fill;
            pnlPlaceholder.Location = new Point(14, 14);
            pnlPlaceholder.Name = "pnlPlaceholder";
            pnlPlaceholder.Size = new Size(570, 617);
            pnlPlaceholder.TabIndex = 0;
            // 
            // lblPlaceholderDesc
            // 
            lblPlaceholderDesc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlaceholderDesc.ForeColor = Color.FromArgb(120, 120, 120);
            lblPlaceholderDesc.Location = new Point(40, 310);
            lblPlaceholderDesc.Name = "lblPlaceholderDesc";
            lblPlaceholderDesc.Size = new Size(490, 80);
            lblPlaceholderDesc.TabIndex = 2;
            lblPlaceholderDesc.Text = "Vui lòng chọn hình thức thanh toán bên trái, kiểm tra thông tin ngân hàng và nhấn nút \"XÁC NHẬN TẠO HÓA ĐƠN & MÃ QR\".\n\nHệ thống sẽ xuất phiếu thanh toán chi tiết các món ăn kèm mã quét VietQR chuyển khoản trực tiếp.";
            lblPlaceholderDesc.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPlaceholderTitle
            // 
            lblPlaceholderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlaceholderTitle.ForeColor = Color.FromArgb(83, 99, 61);
            lblPlaceholderTitle.Location = new Point(40, 260);
            lblPlaceholderTitle.Name = "lblPlaceholderTitle";
            lblPlaceholderTitle.Size = new Size(490, 30);
            lblPlaceholderTitle.TabIndex = 1;
            lblPlaceholderTitle.Text = "CHƯA XÁC NHẬN TẠO HÓA ĐƠN";
            lblPlaceholderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlaceholderIcon
            // 
            lblPlaceholderIcon.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlaceholderIcon.ForeColor = Color.FromArgb(190, 145, 78);
            lblPlaceholderIcon.Location = new Point(40, 150);
            lblPlaceholderIcon.Name = "lblPlaceholderIcon";
            lblPlaceholderIcon.Size = new Size(490, 100);
            lblPlaceholderIcon.TabIndex = 0;
            lblPlaceholderIcon.Text = "🧾";
            lblPlaceholderIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmThanhToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 246, 240);
            CancelButton = btnDong;
            ClientSize = new Size(1004, 671);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThanhToan";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thanh Toán & Hóa Đơn - Maison Oliva";
            Load += frmThanhToan_Load;
            pnlLeft.ResumeLayout(false);
            pnlTienMatConfig.ResumeLayout(false);
            pnlTienMatConfig.PerformLayout();
            pnlQRConfig.ResumeLayout(false);
            pnlQRConfig.PerformLayout();
            grpHinhThuc.ResumeLayout(false);
            grpHinhThuc.PerformLayout();
            pnlHeaderInfo.ResumeLayout(false);
            pnlHeaderInfo.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlBillPaper.ResumeLayout(false);
            pnlBillContent.ResumeLayout(false);
            pnlBillBottom.ResumeLayout(false);
            pnlQRDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            pnlBillSummary.ResumeLayout(false);
            pnlPlaceholder.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
