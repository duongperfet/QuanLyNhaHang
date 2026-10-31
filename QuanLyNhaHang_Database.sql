-- ========================================================
-- ĐỒ ÁN MÔN HỌC: LẬP TRÌNH TRÊN MÔI TRƯỜNG WINDOWS
-- ĐỀ TÀI: PHẦN MỀM QUẢN LÝ ĐẶT BÀN & NHÀ HÀNG
-- ========================================================
-- ========================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLyNhaHang')
BEGIN
    CREATE DATABASE QuanLyNhaHang;
END
GO

USE QuanLyNhaHang;
GO

-- Xóa bảng cũ nếu tồn tại
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('DatBan', 'U') IS NOT NULL DROP TABLE DatBan;
IF OBJECT_ID('MonAn', 'U') IS NOT NULL DROP TABLE MonAn;
IF OBJECT_ID('DanhMuc', 'U') IS NOT NULL DROP TABLE DanhMuc;
IF OBJECT_ID('BanAn', 'U') IS NOT NULL DROP TABLE BanAn;
IF OBJECT_ID('TaiKhoan', 'U') IS NOT NULL DROP TABLE TaiKhoan;
GO

-- 1. Bảng Tài Khoản (Đăng nhập & Phân quyền)
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(50) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    LoaiTaiKhoan INT NOT NULL DEFAULT 0 -- 1: Quản lý, 0: Nhân viên
);

-- 2. Bảng Danh Mục Món Ăn
CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);

-- 3. Bảng Món Ăn
CREATE TABLE MonAn (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDanhMuc INT NOT NULL FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc) ON DELETE CASCADE,
    DonGia DECIMAL(18,0) NOT NULL,
    DonViTinh NVARCHAR(20) DEFAULT N'Đĩa'
);

-- 4. Bảng Bàn Ăn
CREATE TABLE BanAn (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Trống' -- N'Trống', N'Có người', N'Đã đặt'
);

-- 5. Bảng Đặt Bàn Trước
CREATE TABLE DatBan (
    MaDatBan INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT NOT NULL FOREIGN KEY REFERENCES BanAn(MaBan) ON DELETE CASCADE,
    TenKhach NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL,
    ThoiGianDat DATETIME NOT NULL,
    SoNguoi INT NOT NULL DEFAULT 2,
    GhiChu NVARCHAR(255),
    TrangThai NVARCHAR(50) DEFAULT N'Đã đặt' -- N'Đã đặt', N'Đã nhận bàn', N'Đã hủy'
);

-- 6. Bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT NOT NULL FOREIGN KEY REFERENCES BanAn(MaBan),
    NgayVao DATETIME NOT NULL DEFAULT GETDATE(),
    NgayRa DATETIME,
    GiamGia INT NOT NULL DEFAULT 0,
    TongTien DECIMAL(18,0) NOT NULL DEFAULT 0,
    PhuongThucThanhToan NVARCHAR(50) DEFAULT N'Tiền mặt',
    TrangThai INT NOT NULL DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);

-- 7. Bảng Chi Tiết Hóa Đơn
CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE,
    MaMon INT NOT NULL FOREIGN KEY REFERENCES MonAn(MaMon),
    SoLuong INT NOT NULL DEFAULT 1,
    PRIMARY KEY (MaHoaDon, MaMon)
);
GO

-- ========================================================
-- NẠP DỮ LIỆU MẪU BAN ĐẦU
-- ========================================================

-- Tài khoản
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, LoaiTaiKhoan) VALUES
('admin', '123456', N'Quản trị viên', 1),
('nhanvien', '123456', N'Nhân Viên Phục Vụ', 0);

-- Danh mục món
INSERT INTO DanhMuc (TenDanhMuc) VALUES
(N'Khai vị'),
(N'Hải sản'),
(N'Món Bò - Heo - Gà'),
(N'Lẩu & Nướng'),
(N'Đồ uống');

-- Thực đơn món ăn
INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia, DonViTinh) VALUES
(N'Salad cá ngừ', 1, 55000, N'Đĩa'),
(N'Súp hải sản nấm hương', 1, 45000, N'Bát'),
(N'Khoai tây chiên bơ tỏi', 1, 35000, N'Đĩa'),
(N'Tôm sú hấp bia', 2, 180000, N'Đĩa'),
(N'Mực nướng sa tế', 2, 150000, N'Đĩa'),
(N'Cua rang me', 2, 250000, N'Con'),
(N'Bò lúc lắc khoai tây', 3, 140000, N'Đĩa'),
(N'Gà hấp lá chanh', 3, 160000, N'Nửa con'),
(N'Sườn nướng mật ong', 3, 135000, N'Đĩa'),
(N'Lẩu Thái hải sản thập cẩm', 4, 290000, N'Nồi'),
(N'Lẩu riêu cua bắp bò', 4, 320000, N'Nồi'),
(N'Coca Cola', 5, 15000, N'Lon'),
(N'Bia Heineken', 5, 25000, N'Lon'),
(N'Nước suối Aquafina', 5, 10000, N'Chai');

-- 12 Bàn Ăn
INSERT INTO BanAn (TenBan, TrangThai) VALUES
(N'Bàn 01', N'Trống'),
(N'Bàn 02', N'Trống'),
(N'Bàn 03', N'Trống'),
(N'Bàn 04', N'Trống'),
(N'Bàn 05', N'Trống'),
(N'Bàn 06', N'Trống'),
(N'Bàn 07', N'Trống'),
(N'Bàn 08', N'Trống'),
(N'Bàn 09', N'Trống'),
(N'Bàn 10', N'Trống'),
(N'Bàn 11', N'Trống'),
(N'Bàn 12', N'Trống');
GO
