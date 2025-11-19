// UI/Theme.cs
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTruongHocV1.UI
{
    public static class Theme
    {
        public static readonly Color PrimaryBlue = Color.FromArgb(13, 110, 253);   // #0D6EFD
        public static readonly Color PrimaryText = PrimaryBlue;
        public static readonly Color BgDark = Color.FromArgb(15, 23, 42);
        public static readonly Color BgLight = Color.FromArgb(30, 41, 59);
        public static readonly Color Card = Color.FromArgb(248, 250, 252);

        public static void StylePrimaryButton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = PrimaryBlue;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.Hand;
            b.Padding = new Padding(8, 6, 8, 6);
        }

        public static void StyleGhostButton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = PrimaryBlue;
            b.BackColor = Color.Transparent;
            b.ForeColor = PrimaryBlue;
            b.Cursor = Cursors.Hand;
            b.Padding = new Padding(8, 6, 8, 6);
        }

        public static void StyleTextBox(TextBox t)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.BackColor = Color.White;
        }

        public static void StyleHeader(Label l, int size = 20)
        {
            l.ForeColor = PrimaryText;
            l.Font = new Font("Segoe UI", size, FontStyle.Bold);
        }

        public static void StyleLabel(Label l)
        {
            l.ForeColor = Color.White;
            l.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }
    }
}
