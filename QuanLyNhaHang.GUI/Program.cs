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
            Application.Run(new frmMain());
        }
    }
}
