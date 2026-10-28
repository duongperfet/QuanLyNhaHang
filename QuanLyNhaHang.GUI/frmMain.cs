using System;
using System.Collections.Generic;
using System.Drawing;
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
                this.Text = $"Hệ Thống Quản Lý Đặt Bàn & Nhà Hàng - [{CurrentAccount.HoTen} - {vaiTro}]";

                // Phân quyền nghiệp vụ:
                // 1. Chỉ Quản lý mới có quyền truy cập menu Quản trị (Doanh thu, Món ăn, Tài khoản)
                mnuQuanTri.Visible = isAdmin;

                // 2. Cả Nhân viên và Quản lý đều được áp dụng mã giảm giá khi thanh toán
                nudGiamGia.Enabled = true;
                lblGiamGia.Text = "Giảm giá (%):";
            }
        }

        public frmMain()
        {
            InitializeComponent();
            this.Text = "Hệ Thống Quản Lý Đặt Bàn & Nhà Hàng";
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
                Button btn = new Button();
                btn.Width = 98;
                btn.Height = 98;
                btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Tag = ban;

                bool isSelected = _currentBan != null && _currentBan.MaBan == ban.MaBan;
                btn.FlatAppearance.BorderSize = isSelected ? 3 : 1;

                // Đổi màu trực quan theo phong cách POS hiện đại
                switch (ban.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.FromArgb(236, 253, 245);
                        btn.ForeColor = Color.FromArgb(6, 95, 70);
                        btn.FlatAppearance.BorderColor = isSelected ? Color.FromArgb(37, 99, 235) : Color.FromArgb(167, 243, 208);
                        btn.Text = $"🍽️ {ban.TenBan}\n\n[ Trống ]";
                        break;
                    case "Đã đặt":
                        btn.BackColor = Color.FromArgb(254, 243, 199);
                        btn.ForeColor = Color.FromArgb(146, 64, 14);
                        btn.FlatAppearance.BorderColor = isSelected ? Color.FromArgb(37, 99, 235) : Color.FromArgb(252, 211, 77);
                        btn.Text = $"⏰ {ban.TenBan}\n\n[ Đã đặt ]";
                        break;
                    case "Có người":
                        btn.BackColor = Color.FromArgb(254, 226, 226);
                        btn.ForeColor = Color.FromArgb(153, 27, 27);
                        btn.FlatAppearance.BorderColor = isSelected ? Color.FromArgb(37, 99, 235) : Color.FromArgb(252, 165, 165);
                        btn.Text = $"🔥 {ban.TenBan}\n\n[ Có khách ]";
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
                if (c is Button b && b.Tag is BanAnDTO bDto)
                {
                    bool isSelected = bDto.MaBan == _currentBan.MaBan;
                    b.FlatAppearance.BorderSize = isSelected ? 3 : 1;
                    if (isSelected)
                    {
                        b.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
                    }
                    else
                    {
                        switch (bDto.TrangThai)
                        {
                            case "Trống":
                                b.FlatAppearance.BorderColor = Color.FromArgb(167, 243, 208);
                                break;
                            case "Đã đặt":
                                b.FlatAppearance.BorderColor = Color.FromArgb(252, 211, 77);
                                break;
                            case "Có người":
                                b.FlatAppearance.BorderColor = Color.FromArgb(252, 165, 165);
                                break;
                        }
                    }
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
