namespace QuanLyNhaHang.DTO
{
    public class BankInfo
    {
        public string Bin { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;

        // Tên hiển thị đầy đủ, rõ ràng cho ComboBox
        public string DisplayName => !string.IsNullOrEmpty(ShortName) 
            ? $"{ShortName} - {Name}" 
            : (!string.IsNullOrEmpty(Code) ? $"{Code} - {Name}" : Name);

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
