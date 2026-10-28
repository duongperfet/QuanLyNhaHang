using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.GUI
{
    public partial class frmQuanTri : Form
    {
        public frmQuanTri()
        {
            InitializeComponent();
        }

        private void frmQuanTri_Load(object sender, EventArgs e)
        {
            // Tab 1: Ngày đầu tháng -> Ngày hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadDoanhThu();

            // Tab 2: Danh mục món
            LoadDanhMucCbo();
            LoadDanhSachMonAn();

            // Tab 3: Loại tài khoản
            LoadLoaiTKCbo();
            LoadDanhSachTaiKhoan();
        }

        #region Tab 1: Thống Kê Doanh Thu

        private void LoadDoanhThu()
        {
            DateTime tuNgay = new DateTime(dtpTuNgay.Value.Year, dtpTuNgay.Value.Month, dtpTuNgay.Value.Day, 0, 0, 0);
            DateTime denNgay = new DateTime(dtpDenNgay.Value.Year, dtpDenNgay.Value.Month, dtpDenNgay.Value.Day, 23, 59, 59);

            DataTable dt = HoaDonBLL.Instance.GetDoanhThuTheoNgay(tuNgay, denNgay);
            dgvDoanhThu.DataSource = dt;

            // Định dạng hiển thị cột
            if (dgvDoanhThu.Columns.Contains("Tổng tiền (VNĐ)"))
            {
                dgvDoanhThu.Columns["Tổng tiền (VNĐ)"].DefaultCellStyle.Format = "#,##0";
                dgvDoanhThu.Columns["Tổng tiền (VNĐ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvDoanhThu.Columns.Contains("Ngày vào"))
            {
                dgvDoanhThu.Columns["Ngày vào"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvDoanhThu.Columns.Contains("Ngày ra"))
            {
                dgvDoanhThu.Columns["Ngày ra"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // Tính tổng tiền
            decimal tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Tổng tiền (VNĐ)"] != DBNull.Value)
                {
                    tongTien += Convert.ToDecimal(row["Tổng tiền (VNĐ)"]);
                }
            }

            lblTongDoanhThu.Text = $"TỔNG DOANH THU: {tongTien:#,##0} VNĐ";
            lblSoHoaDon.Text = $"Số lượng hóa đơn: {dt.Rows.Count}";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Từ ngày không thể lớn hơn đến ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadDoanhThu();
        }

        private void btnXuatExcelDoanhThu_Click(object sender, EventArgs e)
        {
            if (dgvDoanhThu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn nào để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    sfd.FileName = $"BaoCao_DoanhThu_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    sfd.Title = "Chọn nơi lưu báo cáo doanh thu";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("DoanhThu");

                            ws.Cell("A1").Value = "HỆ THỐNG QUẢN LÝ NHÀ HÀNG";
                            ws.Range("A1:F1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell("A2").Value = "BÁO CÁO THỐNG KÊ DOANH THU";
                            ws.Range("A2:F2").Merge().Style.Font.SetBold().Font.SetFontSize(14).Font.SetFontColor(XLColor.Navy).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            ws.Cell("A3").Value = $"Từ ngày: {dtpTuNgay.Value:dd/MM/yyyy}  đến ngày: {dtpDenNgay.Value:dd/MM/yyyy}";
                            ws.Range("A3:F3").Merge().Style.Font.SetItalic().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // Header các cột
                            int row = 5;
                            for (int col = 0; col < dgvDoanhThu.Columns.Count; col++)
                            {
                                ws.Cell(row, col + 1).Value = dgvDoanhThu.Columns[col].HeaderText;
                            }

                            var headerRange = ws.Range(row, 1, row, dgvDoanhThu.Columns.Count);
                            headerRange.Style.Font.SetBold()
                                             .Fill.SetBackgroundColor(XLColor.FromHtml("#4F81BD"))
                                             .Font.SetFontColor(XLColor.White)
                                             .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // Đổ dữ liệu
                            decimal tongTien = 0;
                            foreach (DataGridViewRow dgvRow in dgvDoanhThu.Rows)
                            {
                                row++;
                                for (int col = 0; col < dgvDoanhThu.Columns.Count; col++)
                                {
                                    var val = dgvRow.Cells[col].Value;
                                    if (dgvDoanhThu.Columns[col].HeaderText.Contains("Tổng tiền") && val != null)
                                    {
                                        decimal valDec = Convert.ToDecimal(val);
                                        tongTien += valDec;
                                        ws.Cell(row, col + 1).Value = valDec;
                                        ws.Cell(row, col + 1).Style.NumberFormat.Format = "#,##0";
                                        ws.Cell(row, col + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                                    }
                                    else if ((dgvDoanhThu.Columns[col].HeaderText.Contains("Ngày")) && val is DateTime dtVal)
                                    {
                                        ws.Cell(row, col + 1).Value = dtVal.ToString("dd/MM/yyyy HH:mm");
                                        ws.Cell(row, col + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    }
                                    else
                                    {
                                        ws.Cell(row, col + 1).Value = val?.ToString() ?? "";
                                        ws.Cell(row, col + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    }
                                }
                            }

                            // Kẻ viền bảng
                            var dataRange = ws.Range(5, 1, row, dgvDoanhThu.Columns.Count);
                            dataRange.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                                            .Border.SetInsideBorder(XLBorderStyleValues.Thin);

                            // Tổng kết
                            row++;
                            ws.Cell(row, dgvDoanhThu.Columns.Count - 1).Value = "TỔNG CỘNG:";
                            ws.Cell(row, dgvDoanhThu.Columns.Count - 1).Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                            ws.Cell(row, dgvDoanhThu.Columns.Count).Value = tongTien;
                            ws.Cell(row, dgvDoanhThu.Columns.Count).Style.Font.SetBold().Font.SetFontColor(XLColor.DarkRed).NumberFormat.Format = "#,##0";

                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }

                        var openConfirm = MessageBox.Show("Xuất báo cáo doanh thu ra Excel thành công!\nBạn có muốn mở file ngay không?", 
                                                          "Xuất báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (openConfirm == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Tab 2: Quản Lý Món Ăn

        private void LoadDanhMucCbo()
        {
            var listDM = DanhMucBLL.Instance.GetDanhSachDanhMuc();
            cboDanhMuc.DataSource = listDM;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadDanhSachMonAn()
        {
            DataTable dt = MonAnBLL.Instance.GetAllMonAn();
            dgvMonAn.DataSource = dt;

            if (dgvMonAn.Columns.Contains("MaDanhMuc"))
            {
                dgvMonAn.Columns["MaDanhMuc"].Visible = false;
            }

            if (dgvMonAn.Columns.Contains("Đơn giá"))
            {
                dgvMonAn.Columns["Đơn giá"].DefaultCellStyle.Format = "#,##0";
                dgvMonAn.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMonAn.Rows.Count)
            {
                DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];
                txtMaMon.Text = row.Cells["Mã món"].Value?.ToString();
                txtTenMon.Text = row.Cells["Tên món"].Value?.ToString();
                txtDonViTinh.Text = row.Cells["Đơn vị tính"].Value?.ToString();

                if (row.Cells["Đơn giá"].Value != null)
                {
                    nudDonGia.Value = Convert.ToDecimal(row.Cells["Đơn giá"].Value);
                }

                if (row.Cells["MaDanhMuc"].Value != null)
                {
                    cboDanhMuc.SelectedValue = Convert.ToInt32(row.Cells["MaDanhMuc"].Value);
                }
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMon.Text.Trim();
            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }

            if (cboDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục món ăn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDanhMuc = (int)cboDanhMuc.SelectedValue;
            decimal donGia = nudDonGia.Value;
            string donViTinh = string.IsNullOrWhiteSpace(txtDonViTinh.Text) ? "Đĩa" : txtDonViTinh.Text.Trim();

            if (MonAnBLL.Instance.ThemMonAn(tenMon, maDanhMuc, donGia, donViTinh))
            {
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachMonAn();
                btnLamMoiMon_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm món ăn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần cập nhật trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMon = int.Parse(txtMaMon.Text);
            string tenMon = txtTenMon.Text.Trim();
            int maDanhMuc = (int)cboDanhMuc.SelectedValue!;
            decimal donGia = nudDonGia.Value;
            string donViTinh = string.IsNullOrWhiteSpace(txtDonViTinh.Text) ? "Đĩa" : txtDonViTinh.Text.Trim();

            if (MonAnBLL.Instance.SuaMonAn(maMon, tenMon, maDanhMuc, donGia, donViTinh))
            {
                MessageBox.Show("Cập nhật thông tin món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachMonAn();
            }
            else
            {
                MessageBox.Show("Cập nhật món ăn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMon = int.Parse(txtMaMon.Text);
            string tenMon = txtTenMon.Text;

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa món: '{tenMon}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                if (MonAnBLL.Instance.XoaMonAn(maMon))
                {
                    MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachMonAn();
                    btnLamMoiMon_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không thể xóa món ăn này vì đã phát sinh hóa đơn liên quan!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoiMon_Click(object sender, EventArgs e)
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            nudDonGia.Value = 0;
            txtDonViTinh.Text = "Đĩa";
            if (cboDanhMuc.Items.Count > 0) cboDanhMuc.SelectedIndex = 0;
        }

        #endregion

        #region Tab 3: Quản Lý Tài Khoản

        private void LoadLoaiTKCbo()
        {
            var listLoai = new[]
            {
                new { Value = 0, Text = "Nhân viên" },
                new { Value = 1, Text = "Quản lý" }
            };
            cboLoaiTK.DataSource = listLoai;
            cboLoaiTK.DisplayMember = "Text";
            cboLoaiTK.ValueMember = "Value";
        }

        private void LoadDanhSachTaiKhoan()
        {
            DataTable dt = TaiKhoanBLL.Instance.GetDanhSachTaiKhoan();
            dgvTaiKhoan.DataSource = dt;

            if (dgvTaiKhoan.Columns.Contains("LoaiTaiKhoan"))
            {
                dgvTaiKhoan.Columns["LoaiTaiKhoan"].Visible = false;
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTaiKhoan.Rows.Count)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["Tên đăng nhập"].Value?.ToString();
                txtHoTen.Text = row.Cells["Họ tên"].Value?.ToString();
                txtTenDangNhap.ReadOnly = true; // Không cho sửa tên đăng nhập đã có

                if (row.Cells["LoaiTaiKhoan"].Value != null)
                {
                    cboLoaiTK.SelectedValue = Convert.ToInt32(row.Cells["LoaiTaiKhoan"].Value);
                }
            }
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string pass = txtMatKhau.Text;
            int loaiTK = (int)cboLoaiTK.SelectedValue!;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Tên đăng nhập, Mật khẩu và Họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (TaiKhoanBLL.Instance.ThemTaiKhoan(user, pass, hoTen, loaiTK))
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachTaiKhoan();
                    btnLamMoiTK_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message} (Có thể tên đăng nhập đã tồn tại)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string passMoi = txtMatKhau.Text;

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đổi mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(passMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới vào ô Mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (TaiKhoanBLL.Instance.DoiMatKhau(user, passMoi))
            {
                MessageBox.Show($"Đặt lại mật khẩu cho tài khoản '{user}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Clear();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (user.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được phép xóa tài khoản quản trị tối cao (admin)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản: '{user}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                if (TaiKhoanBLL.Instance.XoaTaiKhoan(user))
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachTaiKhoan();
                    btnLamMoiTK_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoiTK_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtTenDangNhap.ReadOnly = false;
            txtHoTen.Clear();
            txtMatKhau.Clear();
            if (cboLoaiTK.Items.Count > 0) cboLoaiTK.SelectedIndex = 0;
        }

        #endregion
    }
}