using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.GUI
{
    public partial class frmThanhToan : Form
    {
        private readonly BanAnDTO _ban;
        private readonly decimal _tongTienGoc;
        private readonly int _giamGia;
        private readonly int _maHoaDon;
        private readonly List<MenuOrderDTO> _listMenu;
        private List<BankInfo> _danhSachNganHang = new List<BankInfo>();

        public string PhuongThucThanhToan { get; private set; } = "Chuyển khoản VietQR";
        public decimal TongTienSauGiam { get; private set; }
        public int GiamGia => _giamGia;

        public frmThanhToan(BanAnDTO ban, decimal tongTienGoc, int giamGia, int maHoaDon, List<MenuOrderDTO>? listMenu = null)
        {
            InitializeComponent();
            _ban = ban;
            _tongTienGoc = tongTienGoc;
            _giamGia = giamGia;
            _maHoaDon = maHoaDon;
            _listMenu = listMenu ?? HoaDonBLL.Instance.GetDanhSachMenuTheoBan(_ban.MaBan);
            TongTienSauGiam = _tongTienGoc - (_tongTienGoc * _giamGia / 100);
        }

        private async void frmThanhToan_Load(object sender, EventArgs e)
        {
            // 1. Áp dụng Theme giao diện
            BistroTheme.ApplyPrimaryButton(btnTaoHoaDonQR, BistroTheme.Wine);
            BistroTheme.ApplyPrimaryButton(btnTaoHoaDonTienMat, BistroTheme.Olive);
            BistroTheme.ApplyPrimaryButton(btnHoanTatThanhToan, BistroTheme.Olive);
            BistroTheme.ApplySecondaryButton(btnDong);
            BistroTheme.ApplySecondaryButton(btnCopySTK);
            BistroTheme.ApplySecondaryButton(btnLuuQR);

            // 2. Điền thông tin tổng quan bên trái
            lblTenBan.Text = _ban.TenBan.ToUpper();
            lblMaHoaDon.Text = $"Hóa Đơn: #HD{_maHoaDon:D3}";
            lblThoiGian.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm}";

            lblTienTamTinh.Text = $"Tiền món: {_tongTienGoc:#,##0} VNĐ";
            decimal tienGiam = _tongTienGoc * _giamGia / 100;
            lblGiamGia.Text = $"Giảm giá: {_giamGia}% (-{tienGiam:#,##0} VNĐ)";
            lblPhaiThuValue.Text = $"{TongTienSauGiam:#,##0} VNĐ";

            // 3. Thông tin mặc định Chuyển khoản QR (MB Bank - 0889294024)
            string maBanClean = _ban.TenBan.Replace(" ", "");
            txtNoiDung.Text = $"THANHTOAN {maBanClean} HD{_maHoaDon}";
            txtSoTK.Text = "0889294024";
            txtChuTK.Text = "VO TUNG DUONG";

            // 4. Tiền mặt mặc định
            txtKhachDua.Text = $"{TongTienSauGiam:#,##0}";
            CapNhatTienThoi();

            // 5. Tải danh sách ngân hàng từ API / Offline
            await LoadDanhSachNganHangAsync();

            // 6. Ban đầu hiển thị placeholder yêu cầu xác nhận
            pnlPlaceholder.Visible = true;
            pnlBillContent.Visible = false;
        }

        private async Task LoadDanhSachNganHangAsync()
        {
            try
            {
                _danhSachNganHang = await VietQRHelper.GetDanhSachNganHangTuApiAsync();
            }
            catch
            {
                _danhSachNganHang = VietQRHelper.GetDanhSachNganHangMacDinh();
            }

            cboNganHang.DataSource = _danhSachNganHang;
            cboNganHang.DisplayMember = "ToString";
            cboNganHang.ValueMember = "Bin";

            // Ưu tiên chọn MBBank (970422)
            int indexMB = _danhSachNganHang.FindIndex(b => b.Code.Equals("MB", StringComparison.OrdinalIgnoreCase) || b.Bin == "970422" || b.ShortName.Contains("MB"));
            if (indexMB >= 0)
            {
                cboNganHang.SelectedIndex = indexMB;
            }
            else if (_danhSachNganHang.Count > 0)
            {
                cboNganHang.SelectedIndex = 0;
            }
        }

        private void rdoHinhThuc_CheckedChanged(object? sender, EventArgs e)
        {
            if (rdoChuyenKhoan.Checked)
            {
                PhuongThucThanhToan = "Chuyển khoản VietQR";
                pnlQRConfig.Visible = true;
                pnlTienMatConfig.Visible = false;
            }
            else
            {
                PhuongThucThanhToan = "Tiền mặt";
                pnlQRConfig.Visible = false;
                pnlTienMatConfig.Visible = true;
            }

            // Trở về placeholder để người dùng bấm xác nhận tạo hóa đơn cho phương thức mới
            pnlPlaceholder.Visible = true;
            pnlBillContent.Visible = false;
        }

        #region Xử lý Tiền mặt
        private void txtKhachDua_TextChanged(object? sender, EventArgs e)
        {
            CapNhatTienThoi();
        }

        private void CapNhatTienThoi()
        {
            string raw = txtKhachDua.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(raw, out decimal khachDua))
            {
                decimal tienThoi = khachDua - TongTienSauGiam;
                if (tienThoi >= 0)
                {
                    lblTienThuaValue.ForeColor = BistroTheme.Olive;
                    lblTienThuaValue.Text = $"{tienThoi:#,##0} VNĐ";
                }
                else
                {
                    lblTienThuaValue.ForeColor = BistroTheme.Wine;
                    lblTienThuaValue.Text = $"Còn thiếu {Math.Abs(tienThoi):#,##0} VNĐ";
                }
            }
            else
            {
                lblTienThuaValue.Text = "0 VNĐ";
                lblTienThuaValue.ForeColor = BistroTheme.Muted;
            }
        }

        private void btnQuickDuaDu_Click(object? sender, EventArgs e)
        {
            txtKhachDua.Text = $"{TongTienSauGiam:#,##0}";
        }

        private void btnQuickMoney_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string numStr = btn.Text.Replace(".", "").Trim();
                if (decimal.TryParse(numStr, out decimal val))
                {
                    txtKhachDua.Text = $"{val:#,##0}";
                }
            }
        }
        #endregion

        #region Xác nhận tạo hóa đơn (QR hoặc Tiền mặt)

        // Khi người dùng ấn xác nhận tạo hóa đơn & mã QR
        private async void btnTaoHoaDonQR_Click(object? sender, EventArgs e)
        {
            if (cboNganHang.SelectedItem is not BankInfo bank)
            {
                MessageBox.Show("Vui lòng chọn ngân hàng thụ hưởng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soTK = txtSoTK.Text.Trim();
            string chuTK = txtChuTK.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(soTK))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản ngân hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTK.Focus();
                return;
            }

            btnTaoHoaDonQR.Enabled = false;
            btnTaoHoaDonQR.Text = "Đang tạo hóa đơn & mã QR...";

            try
            {
                // 1. Hiển thị phiếu hóa đơn chi tiết các món ăn
                HienThiThongTinHoaDon(laChuyenKhoan: true);

                // 2. Tạo mã QR VietQR Napas 247
                Bitmap qrImage = await VietQRService.GenerateVietQRBitmapAsync(bank, soTK, TongTienSauGiam, noiDung, chuTK);
                picQR.Image = qrImage;
                picQR.Visible = true;
                lblQRGuide.Visible = true;

                // 3. Hiển thị thông tin ngân hàng trong phiếu
                lblSummaryPhuongThuc.Text = "Hình thức: Chuyển khoản QR (VietQR)";
                lblSummaryBankInfo.Text = $"Ngân hàng: {bank.ShortName}\nSTK: {soTK}  •  Chủ TK: {chuTK}\nCú pháp: {noiDung}";
                btnCopySTK.Visible = true;
                btnLuuQR.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tạo mã QR: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTaoHoaDonQR.Enabled = true;
                btnTaoHoaDonQR.Text = "👉 XÁC NHẬN TẠO HÓA ĐƠN & MÃ QR";
            }
        }

        // Khi người dùng ấn xác nhận tạo hóa đơn tiền mặt
        private void btnTaoHoaDonTienMat_Click(object? sender, EventArgs e)
        {
            string raw = txtKhachDua.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(raw, out decimal khachDua) || khachDua < TongTienSauGiam)
            {
                var ask = MessageBox.Show($"Tiền khách đưa ({khachDua:#,##0} VNĐ) nhỏ hơn số tiền cần thanh toán ({TongTienSauGiam:#,##0} VNĐ).\nBạn có muốn tiếp tục tạo hóa đơn không?",
                                          "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ask != DialogResult.Yes) return;
            }

            decimal tienThoi = Math.Max(0, khachDua - TongTienSauGiam);

            // 1. Hiển thị phiếu hóa đơn chi tiết các món ăn
            HienThiThongTinHoaDon(laChuyenKhoan: false);

            // 2. Ẩn ảnh QR, thay bằng thông tin tiền mặt
            picQR.Visible = false;
            lblQRGuide.Visible = false;
            btnCopySTK.Visible = false;
            btnLuuQR.Visible = false;

            lblSummaryPhuongThuc.Text = "Hình thức: Tiền mặt";
            lblSummaryBankInfo.Text = $"Tiền khách đưa: {khachDua:#,##0} VNĐ\nTiền thừa trả khách: {tienThoi:#,##0} VNĐ";
        }

        private void HienThiThongTinHoaDon(bool laChuyenKhoan)
        {
            // Chuyển từ màn hình Placeholder sang Hóa đơn thật
            pnlPlaceholder.Visible = false;
            pnlBillContent.Visible = true;

            // Thông tin tiêu đề hóa đơn
            lblBillInfoBan.Text = $"BÀN: {_ban.TenBan.ToUpper()}  •  HĐ: #HD{_maHoaDon:D3}";
            lblBillInfoTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm}";

            // Nạp danh sách món ăn vào bảng chi tiết
            lsvChiTietMon.Items.Clear();
            int stt = 1;
            foreach (var item in _listMenu)
            {
                ListViewItem lvi = new ListViewItem(stt++.ToString());
                lvi.SubItems.Add(item.TenMon);
                lvi.SubItems.Add(item.SoLuong.ToString());
                lvi.SubItems.Add($"{item.DonGia:#,##0}");
                lvi.SubItems.Add($"{item.ThanhTien:#,##0}");
                lsvChiTietMon.Items.Add(lvi);
            }

            // Tóm tắt tiền
            lblSummaryTienMon.Text = $"Tổng tiền món: {_tongTienGoc:#,##0} VNĐ";
            decimal tienGiam = _tongTienGoc * _giamGia / 100;
            lblSummaryGiamGia.Text = $"Giảm giá: {_giamGia}% (-{tienGiam:#,##0} VNĐ)";
            lblSummaryTongCong.Text = $"TỔNG CỘNG: {TongTienSauGiam:#,##0} VNĐ";
        }

        #endregion

        #region Các nút tiện ích VietQR
        private void btnCopySTK_Click(object? sender, EventArgs e)
        {
            if (cboNganHang.SelectedItem is BankInfo bank)
            {
                string info = $"Ngân hàng: {bank.ShortName}\nSố TK: {txtSoTK.Text.Trim()}\nChủ TK: {txtChuTK.Text.Trim()}\nSố tiền: {TongTienSauGiam:#,##0} VNĐ\nNội dung: {txtNoiDung.Text.Trim()}";
                Clipboard.SetText(info);
                MessageBox.Show("Đã sao chép đầy đủ thông tin chuyển khoản vào Clipboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuuQR_Click(object? sender, EventArgs e)
        {
            if (picQR.Image == null) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg",
                FileName = $"VietQR_{_ban.TenBan}_{_maHoaDon}.png"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picQR.Image.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("Lưu mã QR thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        // Nút Hoàn tất thanh toán
        private void btnHoanTatThanhToan_Click(object? sender, EventArgs e)
        {
            if (rdoChuyenKhoan.Checked)
            {
                var ask = MessageBox.Show($"Xác nhận khách đã quét mã VietQR và tài khoản MB ({txtSoTK.Text.Trim()}) đã nhận đủ số tiền {TongTienSauGiam:#,##0} VNĐ?",
                                          "Xác nhận thanh toán QR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask != DialogResult.Yes) return;
            }
            else
            {
                var ask = MessageBox.Show($"Xác nhận đã nhận đủ tiền mặt cho {_ban.TenBan} với số tiền {TongTienSauGiam:#,##0} VNĐ?",
                                          "Xác nhận thanh toán Tiền mặt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask != DialogResult.Yes) return;
            }

            // Gọi BLL thực hiện chốt hóa đơn và cập nhật phương thức thanh toán
            bool isSuccess = HoaDonBLL.Instance.ThanhToan(_ban.MaBan, _giamGia, out _, out _, PhuongThucThanhToan);
            if (isSuccess)
            {
                MessageBox.Show($"Thanh toán {_ban.TenBan} thành công!\nPhương thức: {PhuongThucThanhToan}\nSố tiền: {TongTienSauGiam:#,##0} VNĐ", 
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
