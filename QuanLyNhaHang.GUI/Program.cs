using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (frmDangNhap fLogin = new frmDangNhap())
                {
                    if (fLogin.ShowDialog() == DialogResult.OK && fLogin.LoggedInUser != null)
                    {
                        using (frmMain fMain = new frmMain(fLogin.LoggedInUser))
                        {
                            Application.Run(fMain);
                            if (!fMain.IsLogout)
                            {
                                break; // Người dùng đóng ứng dụng hoặc nhấn Thoát
                            }
                            // Nếu bấm Đăng xuất -> vòng lặp while quay lại mở form đăng nhập
                        }
                    }
                    else
                    {
                        break; // Người dùng bấm Thoát hoặc tắt form đăng nhập
                    }
                }
            }
        }
    }
}
