using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class VietQRHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };

        /// <summary>
        /// Danh sách ngân hàng mặc định phổ biến tại Việt Nam (hỗ trợ offline khi không có mạng)
        /// </summary>
        public static List<BankInfo> GetDanhSachNganHangMacDinh()
        {
            return new List<BankInfo>
            {
                new BankInfo { Bin = "970422", Code = "MB", ShortName = "MBBank", Name = "Ngân hàng TMCP Quân đội" },
                new BankInfo { Bin = "970436", Code = "VCB", ShortName = "Vietcombank", Name = "Ngân hàng Ngoại thương Việt Nam" },
                new BankInfo { Bin = "970407", Code = "TCB", ShortName = "Techcombank", Name = "Ngân hàng Kỹ thương Việt Nam" },
                new BankInfo { Bin = "970415", Code = "ICB", ShortName = "VietinBank", Name = "Ngân hàng Công thương Việt Nam" },
                new BankInfo { Bin = "970418", Code = "BIDV", ShortName = "BIDV", Name = "Ngân hàng Đầu tư và Phát triển VN" },
                new BankInfo { Bin = "970405", Code = "VBA", ShortName = "Agribank", Name = "Ngân hàng Nông nghiệp & PTNT VN" },
                new BankInfo { Bin = "970416", Code = "ACB", ShortName = "ACB", Name = "Ngân hàng Á Châu" },
                new BankInfo { Bin = "970432", Code = "VPB", ShortName = "VPBank", Name = "Ngân hàng Việt Nam Thịnh Vượng" },
                new BankInfo { Bin = "970423", Code = "TPB", ShortName = "TPBank", Name = "Ngân hàng Tiên Phong" },
                new BankInfo { Bin = "970403", Code = "STB", ShortName = "Sacombank", Name = "Ngân hàng Sài Gòn Thương Tín" },
                new BankInfo { Bin = "970441", Code = "VIB", ShortName = "VIB", Name = "Ngân hàng Quốc tế Việt Nam" },
                new BankInfo { Bin = "970443", Code = "SHB", ShortName = "SHB", Name = "Ngân hàng Sài Gòn - Hà Nội" },
                new BankInfo { Bin = "970437", Code = "HDB", ShortName = "HDBank", Name = "Ngân hàng Phát triển TP.HCM" },
                new BankInfo { Bin = "970426", Code = "MSB", ShortName = "MSB", Name = "Ngân hàng Hàng Hải" },
                new BankInfo { Bin = "970448", Code = "OCB", ShortName = "OCB", Name = "Ngân hàng Phương Đông" },
                new BankInfo { Bin = "970440", Code = "SEAB", ShortName = "SeABank", Name = "Ngân hàng Đông Nam Á" }
            };
        }

        /// <summary>
        /// Gọi API VietQR để lấy danh sách toàn bộ các ngân hàng chính thức
        /// </summary>
        public static async Task<List<BankInfo>> GetDanhSachNganHangTuApiAsync()
        {
            try
            {
                string json = await _httpClient.GetStringAsync("https://api.vietqr.io/v2/banks");
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("data", out JsonElement dataElement) && dataElement.ValueKind == JsonValueKind.Array)
                {
                    var list = new List<BankInfo>();
                    foreach (var item in dataElement.EnumerateArray())
                    {
                        string bin = item.TryGetProperty("bin", out var binProp) ? binProp.GetString() ?? "" : "";
                        string code = item.TryGetProperty("code", out var codeProp) ? codeProp.GetString() ?? "" : "";
                        string shortName = item.TryGetProperty("shortName", out var shortProp) ? shortProp.GetString() ?? "" : "";
                        string name = item.TryGetProperty("name", out var nameProp) ? nameProp.GetString() ?? "" : "";
                        string logo = item.TryGetProperty("logo", out var logoProp) ? logoProp.GetString() ?? "" : "";

                        if (!string.IsNullOrEmpty(bin) && !string.IsNullOrEmpty(code))
                        {
                            list.Add(new BankInfo
                            {
                                Bin = bin,
                                Code = code,
                                ShortName = string.IsNullOrEmpty(shortName) ? code : shortName,
                                Name = name,
                                LogoUrl = logo
                            });
                        }
                    }

                    if (list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi kết nối mạng và sử dụng danh sách mặc định
            }

            return GetDanhSachNganHangMacDinh();
        }

        /// <summary>
        /// Sinh chuỗi chuẩn EMVCo VietQR cho thanh toán liên ngân hàng Napas 247
        /// Tương thích 100% với ứng dụng tất cả các ngân hàng Việt Nam
        /// </summary>
        public static string GenerateVietQREMVCoString(string bankBin, string accountNumber, decimal amount, string content)
        {
            static string BuildTLV(string tag, string value)
            {
                int len = Encoding.UTF8.GetByteCount(value);
                return $"{tag}{len:D2}{value}";
            }

            // Tag 00: Version
            string payload = BuildTLV("00", "01");

            // Tag 01: Initiation method (12: Dynamic QR kèm số tiền, 11: Static QR)
            payload += BuildTLV("01", amount > 0 ? "12" : "11");

            // Tag 38: Consumer Account Information (VietQR NAPAS)
            string sub38_00 = BuildTLV("00", "A000000727");
            string subBeneficiary = BuildTLV("00", bankBin.Trim()) + BuildTLV("01", accountNumber.Trim());
            string sub38_01 = BuildTLV("01", subBeneficiary);
            string sub38_02 = BuildTLV("02", "QRIBFTTA"); // Chuyển nhanh 247 đến tài khoản
            payload += BuildTLV("38", sub38_00 + sub38_01 + sub38_02);

            // Tag 53: Transaction Currency (704 = VNĐ)
            payload += BuildTLV("53", "704");

            // Tag 54: Transaction Amount
            if (amount > 0)
            {
                payload += BuildTLV("54", ((long)amount).ToString());
            }

            // Tag 58: Country Code (VN)
            payload += BuildTLV("58", "VN");

            // Tag 62: Additional Data Field (Nội dung chuyển khoản)
            if (!string.IsNullOrWhiteSpace(content))
            {
                string cleanContent = RemoveAccents(content.Trim());
                if (cleanContent.Length > 25) cleanContent = cleanContent.Substring(0, 25);
                string sub62_08 = BuildTLV("08", cleanContent);
                payload += BuildTLV("62", sub62_08);
            }

            // Tag 63: CRC16-CCITT Checksum
            payload += "6304";
            ushort crc = ComputeCRC16(Encoding.ASCII.GetBytes(payload));
            return payload + crc.ToString("X4");
        }

        private static ushort ComputeCRC16(byte[] data)
        {
            ushort crc = 0xFFFF;
            ushort polynomial = 0x1021;

            foreach (byte b in data)
            {
                for (int i = 0; i < 8; i++)
                {
                    bool bit = ((b >> (7 - i)) & 1) == 1;
                    bool c15 = ((crc >> 15) & 1) == 1;
                    crc <<= 1;
                    if (c15 ^ bit) crc ^= polynomial;
                }
            }

            return crc;
        }

        public static string RemoveAccents(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;
            string[] vietnameseSigns = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < vietnameseSigns.Length; i++)
            {
                for (int j = 0; j < vietnameseSigns[i].Length; j++)
                    text = text.Replace(vietnameseSigns[i][j], vietnameseSigns[0][i - 1]);
            }

            return text;
        }

        /// <summary>
        /// Tạo URL ảnh VietQR trực tiếp từ API img.vietqr.io
        /// </summary>
        public static string GetVietQRQuickImageUrl(string bankCode, string accountNumber, decimal amount, string content, string accountName)
        {
            string cleanContent = Uri.EscapeDataString(RemoveAccents(content));
            string cleanName = Uri.EscapeDataString(RemoveAccents(accountName).ToUpper());
            long intAmount = (long)amount;
            return $"https://img.vietqr.io/image/{bankCode}-{accountNumber}-compact2.png?amount={intAmount}&addInfo={cleanContent}&accountName={cleanName}";
        }

        /// <summary>
        /// Tạo URL ảnh QR trực tiếp từ API QRServer dựa trên chuỗi EMVCo VietQR
        /// </summary>
        public static string GetQRServerImageUrl(string emvcoString, int size = 350)
        {
            return $"https://api.qrserver.com/v1/create-qr-code/?size={size}x{size}&data={Uri.EscapeDataString(emvcoString)}";
        }
    }
}
