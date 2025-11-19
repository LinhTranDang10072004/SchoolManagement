// Forms/LoginForm.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using DemoAppQLTH.Application.Auth;
using DemoAppQLTH.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHocV1.UI;

namespace QuanLyTruongHocV1.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // ===== Styling =====
            Theme.StyleHeader(lblTitle, 28);
            lblSubtitle.ForeColor = Theme.PrimaryText;
            lblSubtitle.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            Theme.StyleLabel(lblMa);
            Theme.StyleLabel(lblMk);
            Theme.StyleTextBox(txtMa);
            Theme.StyleTextBox(txtMk);

            // Buttons
            StylePrimary(btnLogin);
            StyleGhost(btnExit);

            // Accept/Cancel
            AcceptButton = btnLogin;
            CancelButton = btnExit;

            // Bảo đảm title nổi trên cùng
            lblTitle.BringToFront();
            lblSubtitle.BringToFront();

            // Căn giữa + căng textbox theo card
            CenterCard();
            FitTextBoxWidth();

            // Events
            bg.Paint += DrawBackground;
            bg.Resize += (s, _) => { CenterCard(); FitTextBoxWidth(); Invalidate(); };
            chkShow.CheckedChanged += (s, _) => txtMk.UseSystemPasswordChar = !chkShow.Checked;
            btnExit.Click += (s, _) => Close();
            btnLogin.Click += BtnLogin_Click;
            txtMk.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) BtnLogin_Click(s, ev); };
        }

        private void FitTextBoxWidth()
        {
            int innerW = card.ClientSize.Width - 56; // padding 28*2
            txtMa.Width = innerW;
            txtMk.Width = innerW;
        }

        private void CenterCard()
        {
            card.Left = Math.Max(24, (bg.Width - card.Width) / 2);
            card.Top = Math.Max(24, (bg.Height - card.Height) / 2);
        }

        // Nền gradient + blobs mờ cartoon
        private void DrawBackground(object? sender, PaintEventArgs e)
        {
            using var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                bg.ClientRectangle, Theme.BgDark, Theme.BgLight, 90f);
            e.Graphics.FillRectangle(lg, bg.ClientRectangle);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using var b1 = new SolidBrush(Color.FromArgb(55, 13, 110, 253));
            using var b2 = new SolidBrush(Color.FromArgb(40, Color.White));
            using var b3 = new SolidBrush(Color.FromArgb(36, 36, 99, 170));

            e.Graphics.FillEllipse(b1, -220, bg.Height - 360, 560, 560);
            e.Graphics.FillEllipse(b2, bg.Width - 420, -140, 500, 500);
            e.Graphics.FillRoundedRectangle(b3, new Rectangle(120, 120, 380, 280), 18);
        }

        private void StylePrimary(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Theme.PrimaryBlue;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 230, 255);
        }

        private void StyleGhost(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = Theme.PrimaryBlue;
            b.BackColor = Color.White;
            b.ForeColor = Theme.PrimaryBlue;
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 248, 255);
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(235, 242, 255);
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            using var ctx = new SchoolDbContextFactory().CreateDbContext(Array.Empty<string>());
            try { ctx.Database.Migrate(); } catch { /* ignore */ }

            var (ok, msg, loai, id, ma, hoTen) =
                Authorization.TryLogin(txtMa.Text.Trim(), txtMk.Text, ctx);

            if (!ok)
            {
                MessageBox.Show(msg, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMk.SelectAll(); txtMk.Focus();
                return;
            }

            AppSession.Set(loai, id, ma, hoTen);

            // Mở form theo vai trò
            Form next;
            switch (loai)
            {
                case "Admin":
                    next = new AdminForm();   // Forms/AdminForm.cs
                    break;
                case "GiaoVien":
                    next = new GiaoVienForm(id); // Forms/GiaoVienForm.cs
                    break;
                case "HocSinh":
                    next = new HocSinhForm(id);  // Forms/HocSinhForm.cs
                    break;
                default:
                    MessageBox.Show("Không xác định vai trò đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // chuyển màn hình
            Hide();
            next.StartPosition = FormStartPosition.CenterScreen;
            next.FormClosed += (s2, e2) => Close(); // đóng app khi form sau đóng
            next.Show();
        }


        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}
