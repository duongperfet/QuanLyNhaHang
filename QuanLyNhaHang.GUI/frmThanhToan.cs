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
        private List<BankInfo> _danhSachNganHang = new List<BankInfo>();

        public string PhuongThucThanhToan { get; private set; } = "Chuyển khoản VietQR";
        public decimal TongTienSauGiam { get; private set; }
        public int GiamGia => _giamGia;

        public frmThanhToan(BanAnDTO ban, decimal tongTienGoc, int giamGia, int maHoaDon)
        {
            InitializeComponent();
            _ban = ban;
            _tongTienGoc = tongTienGoc;
            _giamGia = giamGia;
            _maHoaDon = maHoaDon;
            TongTienSauGiam = _tongTienGoc - (_tongTienGoc * _giamGia / 100);
        }

        private async void frmThanhToan_Load(object sender, EventArgs e)
        {
            // 1. Áp dụng Theme
            BistroTheme.ApplyPrimaryButton(btnXacNhan, BistroTheme.Olive);
            BistroTheme.ApplySecondaryButton(btnHuy);
            BistroTheme.ApplyPrimaryButton(btnTaoQR, BistroTheme.Brass);

            // 2. Hiển thị thông tin hóa đơn
            lblTenBan.Text = _ban.TenBan.ToUpper();
            lblMaHoaDon.Text = $"Hóa Đơn: #HD{_maHoaDon:D3}";
            lblThoiGian.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm}";

            lblTienGocValue.Text = $"{_tongTienGoc:#,##0} VNĐ";
            decimal tienGiam = _tongTienGoc * _giamGia / 100;
            lblGiamGiaValue.Text = $"{_giamGia}% (-{tienGiam:#,##0} VNĐ)";
            lblTongThanhToanValue.Text = $"{TongTienSauGiam:#,##0} VNĐ";

            // 3. Nội dung chuyển khoản gợi ý chuẩn
            string maBanClean = _ban.TenBan.Replace(" ", "");
            txtNoiDung.Text = $"THANHTOAN {maBanClean} HD{_maHoaDon}";
            txtSoTK.Text = "0889294024";

            // 4. Tải danh sách ngân hàng (từ VietQR API / mặc định offline)
            await LoadDanhSachNganHangAsync();

            // 5. Tạo mã QR ban đầu
            await CapNhatMaQRAsync();
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

            // Ưu tiên chọn MBBank (970422) hoặc Vietcombank (970436)
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

        private async Task CapNhatMaQRAsync()
        {
            if (cboNganHang.SelectedItem is not BankInfo bank) return;

            string soTK = txtSoTK.Text.Trim();
            string chuTK = txtChuTK.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(soTK))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản ngân hàng thụ hưởng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblHuongDanQR.Text = "⏳ Đang kết nối API VietQR tạo mã thanh toán...";
                lblHuongDanQR.ForeColor = BistroTheme.Brass;

                // Tạo ảnh QR VietQR chuẩn
                Bitmap qrBitmap = await VietQRService.GenerateVietQRBitmapAsync(bank, soTK, TongTienSauGiam, noiDung, chuTK);
                
                // Giải phóng ảnh cũ nếu có
                var oldImg = picQR.Image;
                picQR.Image = qrBitmap;
                oldImg?.Dispose();

                lblHuongDanQR.Text = $"💡 Khách dùng App ngân hàng ({bank.ShortName}, VCB, Techcombank, MoMo,...) quét mã là chuyển đúng {TongTienSauGiam:#,##0} VNĐ!";
                lblHuongDanQR.ForeColor = BistroTheme.Olive;
            }
            catch (Exception ex)
            {
                lblHuongDanQR.Text = $"❌ Lỗi tạo QR: {ex.Message}";
                lblHuongDanQR.ForeColor = BistroTheme.Wine;
            }
        }

        private async void btnTaoQR_Click(object? sender, EventArgs e)
        {
            await CapNhatMaQRAsync();
        }

        private async void cboNganHang_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                await CapNhatMaQRAsync();
            }
        }

        private void rdoHinhThuc_CheckedChanged(object? sender, EventArgs e)
        {
            if (rdoChuyenKhoan.Checked)
            {
                PhuongThucThanhToan = "Chuyển khoản VietQR";
                pnlTienMat.Visible = false;
                grpVietQR.Enabled = true;
            }
            else
            {
                PhuongThucThanhToan = "Tiền mặt";
                pnlTienMat.Visible = true;
                txtKhachDua.Focus();
                txtKhachDua.SelectAll();
            }
        }

        #region Xử lý Tiền mặt
        private void txtKhachDua_TextChanged(object? sender, EventArgs e)
        {
            TinhTienThoi();
        }

        private void TinhTienThoi()
        {
            string raw = txtKhachDua.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(raw, out decimal khachDua))
            {
                decimal tienThoi = khachDua - TongTienSauGiam;
                if (tienThoi >= 0)
                {
                    lblTienThoiValue.ForeColor = BistroTheme.Olive;
                    lblTienThoiValue.Text = $"{tienThoi:#,##0} VNĐ";
                }
                else
                {
                    lblTienThoiValue.ForeColor = BistroTheme.Wine;
                    lblTienThoiValue.Text = $"Còn thiếu {Math.Abs(tienThoi):#,##0} VNĐ";
                }
            }
            else
            {
                lblTienThoiValue.Text = "0 VNĐ";
                lblTienThoiValue.ForeColor = BistroTheme.Muted;
            }
        }

        private void btnTienDu_Click(object? sender, EventArgs e)
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

        #region Các nút tiện ích VietQR
        private void btnSaoChep_Click(object? sender, EventArgs e)
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

        private void btnXacNhan_Click(object? sender, EventArgs e)
        {
            // Nếu chọn tiền mặt và tiền khách đưa còn thiếu
            if (rdoTienMat.Checked)
            {
                string raw = txtKhachDua.Text.Replace(",", "").Replace(".", "").Trim();
                if (decimal.TryParse(raw, out decimal khachDua) && khachDua < TongTienSauGiam)
                {
                    var ask = MessageBox.Show($"Tiền khách đưa ({khachDua:#,##0} VNĐ) nhỏ hơn số tiền cần thanh toán ({TongTienSauGiam:#,##0} VNĐ).\nBạn có chắc chắn muốn tiếp tục hoàn tất không?", 
                                              "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ask != DialogResult.Yes) return;
                }
            }
            else
            {
                // Chuyển khoản QR
                var ask = MessageBox.Show($"Xác nhận khách đã chuyển khoản thành công số tiền {TongTienSauGiam:#,##0} VNĐ qua VietQR?",
                                          "Xác nhận thanh toán QR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask != DialogResult.Yes) return;
            }

            // Gọi BLL thực hiện thanh toán với phương thức
            bool isSuccess = HoaDonBLL.Instance.ThanhToan(_ban.MaBan, _giamGia, out _, out _, PhuongThucThanhToan);
            if (isSuccess)
            {
                MessageBox.Show($"Thanh toán {_ban.TenBan} thành công!\nPhương thức: {PhuongThucThanhToan}\nSố tiền: {TongTienSauGiam:#,##0} VNĐ", 
                                "Thanh toán thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
