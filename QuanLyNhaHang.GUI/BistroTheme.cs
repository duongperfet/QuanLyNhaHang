using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.GUI
{
    internal static class BistroTheme
    {
        public static readonly Color Canvas = Color.FromArgb(248, 246, 240);
        public static readonly Color Surface = Color.White;
        public static readonly Color Ink = Color.FromArgb(43, 45, 39);
        public static readonly Color Muted = Color.FromArgb(117, 117, 105);
        public static readonly Color Olive = Color.FromArgb(83, 99, 61);
        public static readonly Color OliveSoft = Color.FromArgb(239, 242, 231);
        public static readonly Color Wine = Color.FromArgb(143, 57, 65);
        public static readonly Color Brass = Color.FromArgb(190, 145, 78);
        public static readonly Color Line = Color.FromArgb(226, 222, 210);

        public static void ApplyPrimaryButton(Button button, Color? color = null)
        {
            Color buttonColor = color ?? Olive;
            button.BackColor = buttonColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(buttonColor, 0.12f);
            button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(buttonColor, 0.08f);
            button.Cursor = Cursors.Hand;
            button.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            button.UseVisualStyleBackColor = false;
        }

        public static void ApplySecondaryButton(Button button)
        {
            button.BackColor = Surface;
            button.ForeColor = Ink;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Line;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.MouseOverBackColor = Canvas;
            button.Cursor = Cursors.Hand;
            button.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            button.UseVisualStyleBackColor = false;
        }
    }
}