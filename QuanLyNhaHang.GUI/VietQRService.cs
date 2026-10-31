using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using QRCoder;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.GUI
{
    public static class VietQRService
    {
        private static readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(6) };

        /// <summary>
        /// Tạo ảnh QR VietQR chuẩn EMVCo kết hợp QRCoder nội bộ và API Online
        /// </summary>
        public static async Task<Bitmap> GenerateVietQRBitmapAsync(BankInfo bank, string accountNumber, decimal amount, string content, string accountName)
        {
            // 1. Sinh chuỗi chuẩn EMVCo của Napas 247
            string emvco = VietQRHelper.GenerateVietQREMVCoString(bank.Bin, accountNumber, amount, content);

            // 2. Thử tải ảnh từ API Online trước nếu có mạng
            try
            {
                string apiUrl = VietQRHelper.GetQRServerImageUrl(emvco, 320);
                byte[] bytes = await _httpClient.GetByteArrayAsync(apiUrl);
                using var ms = new MemoryStream(bytes);
                using var rawImg = Image.FromStream(ms);
                return CreateBrandedVietQRCard(new Bitmap(rawImg), bank, accountNumber, amount, content, accountName);
            }
            catch
            {
                // Nếu API online lỗi hoặc mất mạng, chuyển sang tạo cục bộ bằng QRCoder
            }

            // 3. Fallback: Tạo bằng thư viện QRCoder cục bộ (100% không lo rớt mạng)
            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(emvco, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new QRCode(qrData);
            using Bitmap localQr = qrCode.GetGraphic(12, Color.FromArgb(20, 30, 45), Color.White, true);

            return CreateBrandedVietQRCard(localQr, bank, accountNumber, amount, content, accountName);
        }

        /// <summary>
        /// Ghép khung thanh toán chuyên nghiệp mang phong cách thẻ VietQR
        /// </summary>
        private static Bitmap CreateBrandedVietQRCard(Bitmap qrSource, BankInfo bank, string accountNumber, decimal amount, string content, string accountName)
        {
            int cardWidth = 360;
            int cardHeight = 490;
            Bitmap card = new Bitmap(cardWidth, cardHeight);

            using (Graphics g = Graphics.FromImage(card))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Nền thẻ
                g.Clear(Color.White);

                // Header gradient VietQR / Ngân hàng
                using (var brush = new LinearGradientBrush(new Rectangle(0, 0, cardWidth, 65),
                    Color.FromArgb(10, 40, 95), Color.FromArgb(0, 102, 179), LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(brush, 0, 0, cardWidth, 65);
                }

                // Tiêu đề Header
                using (var headerFont = new Font("Segoe UI", 12f, FontStyle.Bold))
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    g.DrawString("VIETQR  |  NAPAS 247", headerFont, whiteBrush, new PointF(18, 12));
                }

                using (var subHeaderFont = new Font("Segoe UI", 9f, FontStyle.Regular))
                using (var subWhiteBrush = new SolidBrush(Color.FromArgb(220, 235, 255)))
                {
                    g.DrawString($"Thanh toán chuyển khoản qua {bank.ShortName}", subHeaderFont, subWhiteBrush, new PointF(18, 36));
                }

                // Vẽ mã QR ở giữa
                int qrSize = 250;
                int qrX = (cardWidth - qrSize) / 2;
                int qrY = 78;

                // Khung viền QR
                using (var borderPen = new Pen(Color.FromArgb(220, 224, 230), 1.5f))
                {
                    g.DrawRectangle(borderPen, qrX - 4, qrY - 4, qrSize + 8, qrSize + 8);
                }
                g.DrawImage(qrSource, new Rectangle(qrX, qrY, qrSize, qrSize));

                // Khung thông tin phía dưới
                int infoY = 345;
                using (var infoBgBrush = new SolidBrush(Color.FromArgb(248, 249, 250)))
                {
                    g.FillRectangle(infoBgBrush, 12, infoY, cardWidth - 24, 132);
                }
                using (var linePen = new Pen(Color.FromArgb(230, 233, 238)))
                {
                    g.DrawRectangle(linePen, 12, infoY, cardWidth - 24, 132);
                }

                using (var boldFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                using (var normalFont = new Font("Segoe UI", 9f, FontStyle.Regular))
                using (var moneyFont = new Font("Segoe UI", 13f, FontStyle.Bold))
                using (var labelBrush = new SolidBrush(Color.FromArgb(100, 110, 125)))
                using (var textBrush = new SolidBrush(Color.FromArgb(30, 35, 45)))
                using (var moneyBrush = new SolidBrush(Color.FromArgb(178, 34, 34))) // Đỏ rượu
                {
                    // Dòng 1: Chủ tài khoản
                    g.DrawString("Chủ TK:", normalFont, labelBrush, 22, infoY + 10);
                    g.DrawString(accountName.ToUpper(), boldFont, textBrush, 105, infoY + 9);

                    // Dòng 2: Số tài khoản & Ngân hàng
                    g.DrawString("Số TK:", normalFont, labelBrush, 22, infoY + 34);
                    g.DrawString($"{accountNumber} ({bank.ShortName})", boldFont, textBrush, 105, infoY + 33);

                    // Dòng 3: Số tiền
                    g.DrawString("Số tiền:", normalFont, labelBrush, 22, infoY + 62);
                    g.DrawString($"{amount:#,##0} VNĐ", moneyFont, moneyBrush, 105, infoY + 58);

                    // Dòng 4: Nội dung
                    g.DrawString("Nội dung:", normalFont, labelBrush, 22, infoY + 98);
                    g.DrawString(content, boldFont, textBrush, 105, infoY + 97);
                }
            }

            return card;
        }
    }
}
