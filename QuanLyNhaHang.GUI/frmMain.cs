using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.GUI
{
    public partial class frmMain : Form
    {
        private BanAnDTO? _currentBan;
        private decimal _tongTienGoc = 0;

        public frmMain()
        {
            InitializeComponent();
            this.Text = "Hệ Thống Quản Lý Đặt Bàn & Nhà Hàng";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
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
                btn.FlatAppearance.BorderSize = 1;
                btn.Tag = ban;
                btn.Text = $"{ban.TenBan}\n({ban.TrangThai})";

                // Đổi màu trực quan theo trạng thái bàn
                switch (ban.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.LightGreen;
                        btn.FlatAppearance.BorderColor = Color.ForestGreen;
                        break;
                    case "Đã đặt":
                        btn.BackColor = Color.Khaki;
                        btn.FlatAppearance.BorderColor = Color.DarkGoldenrod;
                        break;
                    case "Có người":
                        btn.BackColor = Color.LightCoral;
                        btn.FlatAppearance.BorderColor = Color.Crimson;
                        break;
                }

                btn.Click += BtnBan_Click;
                flpBanAn.Controls.Add(btn);

                // Giữ lại bàn đang chọn nếu có
                if (_currentBan != null && _currentBan.MaBan == ban.MaBan)
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
            }
        }

        private void BtnBan_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is BanAnDTO ban)
            {
                _currentBan = ban;
                HienThiThongTinBan(ban);
            }
        }

        private void HienThiThongTinBan(BanAnDTO ban)
        {
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
                bool isSuccess = HoaDonBLL.Instance.ThanhToan(_currentBan.MaBan, giamGia, out _, out _);

                if (isSuccess)
                {
                    MessageBox.Show($"Thanh toán {_currentBan.TenBan} thành công!\nCảm ơn quý khách và hẹn gặp lại!", 
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        #region Menu Hệ Thống & Trợ Giúp

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            string thongTin = "ĐỒ ÁN: PHẦN MỀM QUẢN LÝ ĐẶT BÀN & NHÀ HÀNG\n\n" +
                              "Sinh viên thực hiện: Võ Tùng Dương\n" +
                              "MSSV: 24800600195\n" +
                              "Môn học: Lập trình trên môi trường Windows\n" +
                              "Công nghệ: C# WinForms, ADO.NET (SqlConnection), SQL Server\n" +
                              "Kiến trúc: Mô hình 3 lớp chuẩn (GUI - BLL - DAL - DTO)";

            MessageBox.Show(thongTin, "Thông tin đề tài", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
