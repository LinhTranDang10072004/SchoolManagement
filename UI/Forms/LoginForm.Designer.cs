// Forms/LoginForm.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTruongHocV1.UI.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // ==== Controls (Designer quản) ====
        private Panel bg;
        private RoundedCard card;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblMa;
        private TextBox txtMa;
        private Label lblMk;
        private TextBox txtMk;
        private CheckBox chkShow;
        private FlowLayoutPanel pButtons;
        private Button btnLogin;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            bg = new Panel();
            card = new RoundedCard();
            pButtons = new FlowLayoutPanel();
            btnLogin = new Button();
            btnExit = new Button();
            chkShow = new CheckBox();
            txtMk = new TextBox();
            lblMk = new Label();
            txtMa = new TextBox();
            lblMa = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            bg.SuspendLayout();
            card.SuspendLayout();
            pButtons.SuspendLayout();
            SuspendLayout();
            // 
            // bg
            // 
            bg.BackColor = Color.FromArgb(30, 41, 59);
            bg.Controls.Add(card);
            bg.Dock = DockStyle.Fill;
            bg.Location = new Point(0, 0);
            bg.Name = "bg";
            bg.Size = new Size(1000, 640);
            bg.TabIndex = 0;
            // 
            // card
            // 
            card.BackColor = Color.FromArgb(248, 250, 252);
            card.Controls.Add(pButtons);
            card.Controls.Add(chkShow);
            card.Controls.Add(txtMk);
            card.Controls.Add(lblMk);
            card.Controls.Add(txtMa);
            card.Controls.Add(lblMa);
            card.Controls.Add(lblSubtitle);
            card.Controls.Add(lblTitle);
            card.Location = new Point(230, 110);
            card.Name = "card";
            card.Padding = new Padding(28, 36, 28, 28);
            card.Radius = 16;
            card.Size = new Size(540, 420);
            card.TabIndex = 0;
            // 
            // pButtons
            // 
            pButtons.Controls.Add(btnLogin);
            pButtons.Controls.Add(btnExit);
            pButtons.Dock = DockStyle.Bottom;
            pButtons.FlowDirection = FlowDirection.RightToLeft;
            pButtons.Location = new Point(28, 318);
            pButtons.Name = "pButtons";
            pButtons.Padding = new Padding(0, 14, 14, 14);
            pButtons.Size = new Size(484, 74);
            pButtons.TabIndex = 0;
            pButtons.WrapContents = false;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(300, 22);
            btnLogin.Margin = new Padding(10, 8, 0, 8);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(170, 48);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Đăng nhập";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(150, 22);
            btnExit.Margin = new Padding(10, 8, 0, 8);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(140, 48);
            btnExit.TabIndex = 1;
            btnExit.Text = "Thoát";
            // 
            // chkShow
            // 
            chkShow.AutoSize = true;
            chkShow.Location = new Point(28, 270);
            chkShow.Name = "chkShow";
            chkShow.Size = new Size(127, 24);
            chkShow.TabIndex = 1;
            chkShow.Text = "Hiện mật khẩu";
            // 
            // txtMk
            // 
            txtMk.Location = new Point(28, 226);
            txtMk.Name = "txtMk";
            txtMk.PlaceholderText = "••••••••";
            txtMk.Size = new Size(484, 27);
            txtMk.TabIndex = 2;
            txtMk.UseSystemPasswordChar = true;
            // 
            // lblMk
            // 
            lblMk.AutoSize = true;
            lblMk.Location = new Point(28, 200);
            lblMk.Name = "lblMk";
            lblMk.Size = new Size(70, 20);
            lblMk.TabIndex = 3;
            lblMk.Text = "Mật khẩu";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(28, 156);
            txtMa.Name = "txtMa";
            txtMa.PlaceholderText = "VD: A01, GV01, HS01";
            txtMa.Size = new Size(484, 27);
            txtMa.TabIndex = 4;
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Location = new Point(28, 130);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(105, 20);
            lblMa.TabIndex = 5;
            lblMa.Text = "Mã đăng nhập";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(28, 84);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(246, 20);
            lblSubtitle.TabIndex = 6;
            lblSubtitle.Text = "HỆ THỐNG QUẢN LÝ TRƯỜNG HỌC";
            lblSubtitle.Click += lblSubtitle_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(28, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(95, 20);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 640);
            Controls.Add(bg);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập – DemoAppQLTH";
            Load += LoginForm_Load;
            bg.ResumeLayout(false);
            card.ResumeLayout(false);
            card.PerformLayout();
            pButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        /// <summary>Panel bo góc + đổ bóng nhẹ (vẽ trong OnPaint)</summary>
        private class RoundedCard : Panel
        {
            public int Radius { get; set; } = 16;
            public RoundedCard()
            {
                DoubleBuffered = true;
                BackColor = Color.FromArgb(248, 250, 252);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var rect = ClientRectangle; rect.Width -= 1; rect.Height -= 1;

                using (var shadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                    e.Graphics.FillRoundedRectangle(shadow, new Rectangle(rect.X + 3, rect.Y + 5, rect.Width, rect.Height), Radius + 6);

                using (var body = new SolidBrush(BackColor))
                    e.Graphics.FillRoundedRectangle(body, rect, Radius);

                using (var pen = new Pen(Color.FromArgb(220, 225, 230)))
                    e.Graphics.DrawRoundedRectangle(pen, rect, Radius);
            }
        }
    }

    // Helpers vẽ rounded rect
    internal static class GraphicsExt
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle rect, int radius)
            => g.FillPath(brush, RoundedPath(rect, radius));
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle rect, int radius)
            => g.DrawPath(pen, RoundedPath(rect, radius));

        private static System.Drawing.Drawing2D.GraphicsPath RoundedPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.StartFigure();
            gp.AddArc(rect.X, rect.Y, d, d, 180, 90);
            gp.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            gp.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            gp.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            gp.CloseFigure();
            return gp;
        }
    }
}
