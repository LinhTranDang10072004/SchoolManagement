// QuanLyTruongHocV1/UI/Forms/GiaoVienForm.Designer.cs
using System.Windows.Forms;

namespace QuanLyTruongHocV1.UI.Forms
{
    partial class GiaoVienForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabs;
        private TabPage tabPhanCong;
        private TabPage tabNhapDiem;

        // Tab 1
        private DataGridView dgvPhanCong;
        private ComboBox cboKy;          // lọc kỳ cho tab 1
        private Button btnReloadPC;

        // Tab 2
        private DataGridView dgvHocSinh;
        private ComboBox cboHocKy;       // chọn kỳ cho tab 2
        private ComboBox cboLop;         // lớp theo phân công
        private ComboBox cboMonHoc;      // môn theo phân công
        private TextBox txtDiem;
        private Button btnNhapDiem;
        private Button btnReloadHS;
        private Label lblTB;
        private Label lblQua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabs = new TabControl();
            tabPhanCong = new TabPage();
            btnReloadPC = new Button();
            cboKy = new ComboBox();
            dgvPhanCong = new DataGridView();
            tabNhapDiem = new TabPage();
            btnReloadHS = new Button();
            lblQua = new Label();
            lblTB = new Label();
            btnNhapDiem = new Button();
            txtDiem = new TextBox();
            cboMonHoc = new ComboBox();
            cboLop = new ComboBox();
            cboHocKy = new ComboBox();
            dgvHocSinh = new DataGridView();
            tabs.SuspendLayout();
            tabPhanCong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).BeginInit();
            tabNhapDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocSinh).BeginInit();
            SuspendLayout();
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPhanCong);
            tabs.Controls.Add(tabNhapDiem);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 0);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(980, 620);
            tabs.TabIndex = 0;
            // 
            // tabPhanCong
            // 
            tabPhanCong.Controls.Add(btnReloadPC);
            tabPhanCong.Controls.Add(cboKy);
            tabPhanCong.Controls.Add(dgvPhanCong);
            tabPhanCong.Location = new Point(4, 29);
            tabPhanCong.Name = "tabPhanCong";
            tabPhanCong.Padding = new Padding(8);
            tabPhanCong.Size = new Size(972, 587);
            tabPhanCong.TabIndex = 0;
            tabPhanCong.Text = "Phân công của tôi";
            tabPhanCong.UseVisualStyleBackColor = true;
            // 
            // btnReloadPC
            // 
            btnReloadPC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReloadPC.Location = new Point(860, 10);
            btnReloadPC.Name = "btnReloadPC";
            btnReloadPC.Size = new Size(96, 32);
            btnReloadPC.TabIndex = 0;
            btnReloadPC.Text = "Tải lại";
            btnReloadPC.UseVisualStyleBackColor = true;
            btnReloadPC.Click += btnReloadPC_Click;
            // 
            // cboKy
            // 
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKy.Location = new Point(12, 12);
            cboKy.Name = "cboKy";
            cboKy.Size = new Size(276, 28);
            cboKy.TabIndex = 1;
            cboKy.SelectedIndexChanged += cboKy_SelectedIndexChanged;
            // 
            // dgvPhanCong
            // 
            dgvPhanCong.AllowUserToAddRows = false;
            dgvPhanCong.AllowUserToDeleteRows = false;
            dgvPhanCong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhanCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhanCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhanCong.Location = new Point(12, 52);
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.Name = "dgvPhanCong";
            dgvPhanCong.ReadOnly = true;
            dgvPhanCong.RowHeadersVisible = false;
            dgvPhanCong.RowHeadersWidth = 51;
            dgvPhanCong.RowTemplate.Height = 28;
            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCong.Size = new Size(944, 523);
            dgvPhanCong.TabIndex = 2;
            dgvPhanCong.CellDoubleClick += dgvPhanCong_CellDoubleClick;
            // 
            // tabNhapDiem
            // 
            tabNhapDiem.Controls.Add(btnReloadHS);
            tabNhapDiem.Controls.Add(lblQua);
            tabNhapDiem.Controls.Add(lblTB);
            tabNhapDiem.Controls.Add(btnNhapDiem);
            tabNhapDiem.Controls.Add(txtDiem);
            tabNhapDiem.Controls.Add(cboMonHoc);
            tabNhapDiem.Controls.Add(cboLop);
            tabNhapDiem.Controls.Add(cboHocKy);
            tabNhapDiem.Controls.Add(dgvHocSinh);
            tabNhapDiem.Location = new Point(4, 29);
            tabNhapDiem.Name = "tabNhapDiem";
            tabNhapDiem.Padding = new Padding(8);
            tabNhapDiem.Size = new Size(972, 587);
            tabNhapDiem.TabIndex = 1;
            tabNhapDiem.Text = "Điểm & Danh sách HS";
            tabNhapDiem.UseVisualStyleBackColor = true;
            // 
            // btnReloadHS
            // 
            btnReloadHS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReloadHS.Location = new Point(860, 10);
            btnReloadHS.Name = "btnReloadHS";
            btnReloadHS.Size = new Size(96, 32);
            btnReloadHS.TabIndex = 0;
            btnReloadHS.Text = "Tải lại";
            btnReloadHS.UseVisualStyleBackColor = true;
            btnReloadHS.Click += btnReloadHS_Click;
            // 
            // lblQua
            // 
            lblQua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblQua.AutoSize = true;
            lblQua.Location = new Point(180, 548);
            lblQua.Name = "lblQua";
            lblQua.Size = new Size(113, 20);
            lblQua.TabIndex = 1;
            lblQua.Text = "Tỉ lệ qua môn: -";
            // 
            // lblTB
            // 
            lblTB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTB.AutoSize = true;
            lblTB.Location = new Point(12, 548);
            lblTB.Name = "lblTB";
            lblTB.Size = new Size(105, 20);
            lblTB.TabIndex = 2;
            lblTB.Text = "Điểm TB lớp: -";
            // 
            // btnNhapDiem
            // 
            btnNhapDiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNhapDiem.Location = new Point(860, 48);
            btnNhapDiem.Name = "btnNhapDiem";
            btnNhapDiem.Size = new Size(96, 32);
            btnNhapDiem.TabIndex = 3;
            btnNhapDiem.Text = "Lưu điểm";
            btnNhapDiem.UseVisualStyleBackColor = true;
            btnNhapDiem.Click += btnNhapDiem_Click;
            // 
            // txtDiem
            // 
            txtDiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDiem.Location = new Point(740, 50);
            txtDiem.Name = "txtDiem";
            txtDiem.PlaceholderText = "0..10";
            txtDiem.Size = new Size(112, 27);
            txtDiem.TabIndex = 4;
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.Location = new Point(496, 12);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(220, 28);
            cboMonHoc.TabIndex = 5;
            cboMonHoc.SelectedIndexChanged += cboMonHoc_SelectedIndexChanged;
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(260, 12);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(220, 28);
            cboLop.TabIndex = 6;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            // 
            // cboHocKy
            // 
            cboHocKy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHocKy.Location = new Point(12, 12);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(240, 28);
            cboHocKy.TabIndex = 7;
            cboHocKy.SelectedIndexChanged += cboHocKy_SelectedIndexChanged;
            // 
            // dgvHocSinh
            // 
            dgvHocSinh.AllowUserToAddRows = false;
            dgvHocSinh.AllowUserToDeleteRows = false;
            dgvHocSinh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHocSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHocSinh.Location = new Point(12, 88);
            dgvHocSinh.MultiSelect = false;
            dgvHocSinh.Name = "dgvHocSinh";
            dgvHocSinh.ReadOnly = true;
            dgvHocSinh.RowHeadersVisible = false;
            dgvHocSinh.RowHeadersWidth = 51;
            dgvHocSinh.RowTemplate.Height = 28;
            dgvHocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocSinh.Size = new Size(944, 448);
            dgvHocSinh.TabIndex = 8;
            // 
            // GiaoVienForm
            // 
            ClientSize = new Size(980, 620);
            Controls.Add(tabs);
            Name = "GiaoVienForm";
            Text = "Giáo viên";
            tabs.ResumeLayout(false);
            tabPhanCong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).EndInit();
            tabNhapDiem.ResumeLayout(false);
            tabNhapDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocSinh).EndInit();
            ResumeLayout(false);
        }
    }
}
