// UI/Forms/HocSinhForm.Designer.cs
using System.Windows.Forms;

namespace QuanLyTruongHocV1.UI.Forms
{
    partial class HocSinhForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabs;
        private TabPage tabBangDiem;
        private TabPage tabThongTin;

        // Tab 1
        private ComboBox cboKy;
        private Label lblLop;
        private Button btnReload;
        private DataGridView dgvBangDiem;
        private Label lblGPA;
        private Label lblXepLoai;

        // Tab 2
        private Label labelMa;
        private Label labelHoTen;
        private Label labelEmail;
        private Label labelPhone;
        private Label lblMaValue;
        private Label lblHoTenValue;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Button btnLuu;
        private Button btnHoanTac;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabs = new TabControl();
            tabBangDiem = new TabPage();
            lblXepLoai = new Label();
            lblGPA = new Label();
            dgvBangDiem = new DataGridView();
            btnReload = new Button();
            lblLop = new Label();
            cboKy = new ComboBox();
            tabThongTin = new TabPage();
            btnHoanTac = new Button();
            btnLuu = new Button();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            lblHoTenValue = new Label();
            lblMaValue = new Label();
            labelPhone = new Label();
            labelEmail = new Label();
            labelHoTen = new Label();
            labelMa = new Label();
            tabs.SuspendLayout();
            tabBangDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).BeginInit();
            tabThongTin.SuspendLayout();
            SuspendLayout();
            // 
            // tabs
            // 
            tabs.Controls.Add(tabBangDiem);
            tabs.Controls.Add(tabThongTin);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 0);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(900, 560);
            tabs.TabIndex = 0;
            // 
            // tabBangDiem
            // 
            tabBangDiem.Controls.Add(lblXepLoai);
            tabBangDiem.Controls.Add(lblGPA);
            tabBangDiem.Controls.Add(dgvBangDiem);
            tabBangDiem.Controls.Add(btnReload);
            tabBangDiem.Controls.Add(lblLop);
            tabBangDiem.Controls.Add(cboKy);
            tabBangDiem.Location = new Point(4, 29);
            tabBangDiem.Name = "tabBangDiem";
            tabBangDiem.Padding = new Padding(8);
            tabBangDiem.Size = new Size(892, 527);
            tabBangDiem.TabIndex = 0;
            tabBangDiem.Text = "Bảng điểm";
            tabBangDiem.UseVisualStyleBackColor = true;
            // 
            // lblXepLoai
            // 
            lblXepLoai.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblXepLoai.AutoSize = true;
            lblXepLoai.Location = new Point(150, 485);
            lblXepLoai.Name = "lblXepLoai";
            lblXepLoai.Size = new Size(77, 20);
            lblXepLoai.TabIndex = 0;
            lblXepLoai.Text = "Xếp loại: -";
            // 
            // lblGPA
            // 
            lblGPA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblGPA.AutoSize = true;
            lblGPA.Location = new Point(12, 485);
            lblGPA.Name = "lblGPA";
            lblGPA.Size = new Size(49, 20);
            lblGPA.TabIndex = 1;
            lblGPA.Text = "GPA: -";
            // 
            // dgvBangDiem
            // 
            dgvBangDiem.AllowUserToAddRows = false;
            dgvBangDiem.AllowUserToDeleteRows = false;
            dgvBangDiem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBangDiem.Location = new Point(12, 52);
            dgvBangDiem.MultiSelect = false;
            dgvBangDiem.Name = "dgvBangDiem";
            dgvBangDiem.ReadOnly = true;
            dgvBangDiem.RowHeadersVisible = false;
            dgvBangDiem.RowHeadersWidth = 51;
            dgvBangDiem.RowTemplate.Height = 28;
            dgvBangDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangDiem.Size = new Size(864, 420);
            dgvBangDiem.TabIndex = 2;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReload.Location = new Point(780, 10);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(96, 32);
            btnReload.TabIndex = 3;
            btnReload.Text = "Tải lại";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(250, 16);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(83, 20);
            lblLop.TabIndex = 4;
            lblLop.Text = "Lớp: (chưa)";
            // 
            // cboKy
            // 
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKy.Location = new Point(12, 12);
            cboKy.Name = "cboKy";
            cboKy.Size = new Size(220, 28);
            cboKy.TabIndex = 5;
            cboKy.SelectedIndexChanged += cboKy_SelectedIndexChanged;
            // 
            // tabThongTin
            // 
            tabThongTin.Controls.Add(btnHoanTac);
            tabThongTin.Controls.Add(btnLuu);
            tabThongTin.Controls.Add(txtPhone);
            tabThongTin.Controls.Add(txtEmail);
            tabThongTin.Controls.Add(lblHoTenValue);
            tabThongTin.Controls.Add(lblMaValue);
            tabThongTin.Controls.Add(labelPhone);
            tabThongTin.Controls.Add(labelEmail);
            tabThongTin.Controls.Add(labelHoTen);
            tabThongTin.Controls.Add(labelMa);
            tabThongTin.Location = new Point(4, 29);
            tabThongTin.Name = "tabThongTin";
            tabThongTin.Padding = new Padding(12);
            tabThongTin.Size = new Size(892, 527);
            tabThongTin.TabIndex = 1;
            tabThongTin.Text = "Thông tin";
            tabThongTin.UseVisualStyleBackColor = true;
            // 
            // btnHoanTac
            // 
            btnHoanTac.Location = new Point(226, 196);
            btnHoanTac.Name = "btnHoanTac";
            btnHoanTac.Size = new Size(92, 32);
            btnHoanTac.TabIndex = 0;
            btnHoanTac.Text = "Hoàn tác";
            btnHoanTac.UseVisualStyleBackColor = true;
            btnHoanTac.Click += btnHoanTac_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(120, 196);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(92, 32);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(120, 146);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(360, 27);
            txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 106);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 27);
            txtEmail.TabIndex = 3;
            // 
            // lblHoTenValue
            // 
            lblHoTenValue.AutoSize = true;
            lblHoTenValue.Location = new Point(120, 60);
            lblHoTenValue.Name = "lblHoTenValue";
            lblHoTenValue.Size = new Size(15, 20);
            lblHoTenValue.TabIndex = 4;
            lblHoTenValue.Text = "-";
            // 
            // lblMaValue
            // 
            lblMaValue.AutoSize = true;
            lblMaValue.Location = new Point(120, 24);
            lblMaValue.Name = "lblMaValue";
            lblMaValue.Size = new Size(15, 20);
            lblMaValue.TabIndex = 5;
            lblMaValue.Text = "-";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(16, 150);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(81, 20);
            labelPhone.TabIndex = 6;
            labelPhone.Text = "Điện thoại:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(16, 110);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(49, 20);
            labelEmail.TabIndex = 7;
            labelEmail.Text = "Email:";
            // 
            // labelHoTen
            // 
            labelHoTen.AutoSize = true;
            labelHoTen.Location = new Point(16, 60);
            labelHoTen.Name = "labelHoTen";
            labelHoTen.Size = new Size(57, 20);
            labelHoTen.TabIndex = 8;
            labelHoTen.Text = "Họ tên:";
            // 
            // labelMa
            // 
            labelMa.AutoSize = true;
            labelMa.Location = new Point(16, 24);
            labelMa.Name = "labelMa";
            labelMa.Size = new Size(56, 20);
            labelMa.TabIndex = 9;
            labelMa.Text = "Mã HS:";
            // 
            // HocSinhForm
            // 
            ClientSize = new Size(900, 560);
            Controls.Add(tabs);
            Name = "HocSinhForm";
            Text = "Học sinh";
            tabs.ResumeLayout(false);
            tabBangDiem.ResumeLayout(false);
            tabBangDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).EndInit();
            tabThongTin.ResumeLayout(false);
            tabThongTin.PerformLayout();
            ResumeLayout(false);
        }
    }
}
