namespace QuanLyNhaHang.DTO
{
    public class BankInfo
    {
        public string Bin { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[{Code}] {ShortName} - {Name}";
        }
    }
}
