using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTruongHocV1.UI.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        // ===== Tabs =====
        private TabControl tabs;
        private TabPage tabUsers;
        private TabPage tabLop;
        private TabPage tabMon;
        private TabPage tabHocKy;
        private TabPage tabPhanCong;

        // ===== Tab 1: Users =====
        private GroupBox grpTaoGV, grpTaoHS, grpXemNguoiDung;
        private TextBox txtGV_Ma, txtGV_HoTen, txtGV_MatKhau;
        private Button btnGV_Them;
        private TextBox txtHS_Ma, txtHS_HoTen, txtHS_MatKhau;
        private ComboBox cboHS_Lop, cboHS_HocKy;
        private Button btnHS_Them;
        private ComboBox cboUsers_Ky;
        private DataGridView dgvUsers;
        private FlowLayoutPanel pnlUsersBtns;
        private Button btnUser_SuaLienHe, btnUser_Xoa, btnUsers_Refresh;

        // ===== Tab 2: Lớp =====
        private GroupBox grpLop;
        private DataGridView dgvLop;
        private Panel pnlLopRight;
        private TableLayoutPanel tlpLop;
        private TextBox txtLop_Ten;
        private ComboBox cboLop_Khoi;
        private Button btnLop_Them, btnLop_Sua, btnLop_Xoa;

        // ===== Tab 3: Môn =====
        private GroupBox grpMon;
        private DataGridView dgvMon;
        private Panel pnlMonRight;
        private TableLayoutPanel tlpMon;
        private TextBox txtMon_Ten;
        private Button btnMon_Them, btnMon_Sua, btnMon_Xoa;

        // ===== Tab 4: Học kỳ =====
        private DataGridView dgvHocKy;
        private Panel rightKy;
        private TableLayoutPanel tlpKy;
        private TextBox txtNamHoc;
        private ComboBox cboKyThu;
        private Button btnKy_Them, btnKy_Sua, btnKy_Xoa;

        // ===== Tab 5: Phân công =====
        private Panel topPC;
        private FlowLayoutPanel rowPC;
        private Panel actionsPC;
        private ComboBox cboPC_Ky, cboPC_Lop, cboPC_Mon, cboPC_GV;
        private Button btnPC_Them, btnPC_Xoa, btnPC_Refresh;
        private DataGridView dgvPhanCong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabs = new TabControl();
            tabUsers = new TabPage();
            grpXemNguoiDung = new GroupBox();
            dgvUsers = new DataGridView();
            pnlUsersBtns = new FlowLayoutPanel();
            btnUser_SuaLienHe = new Button();
            btnUser_Xoa = new Button();
            rowKy = new FlowLayoutPanel();
            lblXemKy = new Label();
            cboUsers_Ky = new ComboBox();
            btnUsers_Refresh = new Button();
            grpTaoHS = new GroupBox();
            tlpHS = new TableLayoutPanel();
            lblHS_Ma = new Label();
            txtHS_Ma = new TextBox();
            lblHS_Ten = new Label();
            txtHS_HoTen = new TextBox();
            lblHS_Mk = new Label();
            txtHS_MatKhau = new TextBox();
            lblHS_Lop = new Label();
            cboHS_Lop = new ComboBox();
            lblHS_Ky = new Label();
            cboHS_HocKy = new ComboBox();
            btnHS_Them = new Button();
            grpTaoGV = new GroupBox();
            tlpGV = new TableLayoutPanel();
            lblGV_Ma = new Label();
            txtGV_Ma = new TextBox();
            lblGV_Ten = new Label();
            txtGV_HoTen = new TextBox();
            lblGV_Mk = new Label();
            txtGV_MatKhau = new TextBox();
            btnGV_Them = new Button();
            tabLop = new TabPage();
            grpLop = new GroupBox();
            dgvLop = new DataGridView();
            pnlLopRight = new Panel();
            tlpLop = new TableLayoutPanel();
            lblTenLop = new Label();
            txtLop_Ten = new TextBox();
            lblKhoi = new Label();
            cboLop_Khoi = new ComboBox();
            btnLop_Them = new Button();
            btnLop_Sua = new Button();
            btnLop_Xoa = new Button();
            tabMon = new TabPage();
            grpMon = new GroupBox();
            dgvMon = new DataGridView();
            pnlMonRight = new Panel();
            tlpMon = new TableLayoutPanel();
            lblTenMon = new Label();
            txtMon_Ten = new TextBox();
            btnMon_Them = new Button();
            btnMon_Sua = new Button();
            btnMon_Xoa = new Button();
            tabHocKy = new TabPage();
            dgvHocKy = new DataGridView();
            rightKy = new Panel();
            tlpKy = new TableLayoutPanel();
            lblNamHoc = new Label();
            txtNamHoc = new TextBox();
            lblKyThu = new Label();
            cboKyThu = new ComboBox();
            btnKy_Them = new Button();
            btnKy_Sua = new Button();
            btnKy_Xoa = new Button();
            tabPhanCong = new TabPage();
            dgvPhanCong = new DataGridView();
            actionsPC = new Panel();
            stackBtns = new TableLayoutPanel();
            btnPC_Them = new Button();
            btnPC_Xoa = new Button();
            btnPC_Refresh = new Button();
            topPC = new Panel();
            rowPC = new FlowLayoutPanel();
            lblPCKy = new Label();
            cboPC_Ky = new ComboBox();
            lblPCLop = new Label();
            cboPC_Lop = new ComboBox();
            lblPCMon = new Label();
            cboPC_Mon = new ComboBox();
            lblPCGV = new Label();
            cboPC_GV = new ComboBox();
            tabs.SuspendLayout();
            tabUsers.SuspendLayout();
            grpXemNguoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlUsersBtns.SuspendLayout();
            rowKy.SuspendLayout();
            grpTaoHS.SuspendLayout();
            tlpHS.SuspendLayout();
            grpTaoGV.SuspendLayout();
            tlpGV.SuspendLayout();
            tabLop.SuspendLayout();
            grpLop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            pnlLopRight.SuspendLayout();
            tlpLop.SuspendLayout();
            tabMon.SuspendLayout();
            grpMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMon).BeginInit();
            pnlMonRight.SuspendLayout();
            tlpMon.SuspendLayout();
            tabHocKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).BeginInit();
            rightKy.SuspendLayout();
            tlpKy.SuspendLayout();
            tabPhanCong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).BeginInit();
            actionsPC.SuspendLayout();
            stackBtns.SuspendLayout();
            topPC.SuspendLayout();
            rowPC.SuspendLayout();
            SuspendLayout();
            // 
            // tabs
            // 
            tabs.Controls.Add(tabUsers);
            tabs.Controls.Add(tabLop);
            tabs.Controls.Add(tabMon);
            tabs.Controls.Add(tabHocKy);
            tabs.Controls.Add(tabPhanCong);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 0);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(1280, 820);
            tabs.TabIndex = 0;
            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(grpXemNguoiDung);
            tabUsers.Controls.Add(grpTaoHS);
            tabUsers.Controls.Add(grpTaoGV);
            tabUsers.Location = new Point(4, 32);
            tabUsers.Name = "tabUsers";
            tabUsers.Size = new Size(1272, 784);
            tabUsers.TabIndex = 0;
            tabUsers.Text = "Người dùng";
            // 
            // grpXemNguoiDung
            // 
            grpXemNguoiDung.Controls.Add(dgvUsers);
            grpXemNguoiDung.Controls.Add(pnlUsersBtns);
            grpXemNguoiDung.Controls.Add(rowKy);
            grpXemNguoiDung.Dock = DockStyle.Fill;
            grpXemNguoiDung.Location = new Point(0, 231);
            grpXemNguoiDung.Name = "grpXemNguoiDung";
            grpXemNguoiDung.Padding = new Padding(10);
            grpXemNguoiDung.Size = new Size(1272, 553);
            grpXemNguoiDung.TabIndex = 0;
            grpXemNguoiDung.TabStop = false;
            grpXemNguoiDung.Text = "Danh sách người dùng theo kỳ";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ColumnHeadersHeight = 36;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(10, 81);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1252, 416);
            dgvUsers.TabIndex = 0;
            // 
            // pnlUsersBtns
            // 
            pnlUsersBtns.Controls.Add(btnUser_SuaLienHe);
            pnlUsersBtns.Controls.Add(btnUser_Xoa);
            pnlUsersBtns.Dock = DockStyle.Bottom;
            pnlUsersBtns.FlowDirection = FlowDirection.RightToLeft;
            pnlUsersBtns.Location = new Point(10, 497);
            pnlUsersBtns.Name = "pnlUsersBtns";
            pnlUsersBtns.Padding = new Padding(0, 6, 0, 0);
            pnlUsersBtns.Size = new Size(1252, 46);
            pnlUsersBtns.TabIndex = 1;
            pnlUsersBtns.WrapContents = false;
            // 
            // btnUser_SuaLienHe
            // 
            btnUser_SuaLienHe.Location = new Point(1132, 10);
            btnUser_SuaLienHe.Margin = new Padding(8, 4, 0, 0);
            btnUser_SuaLienHe.Name = "btnUser_SuaLienHe";
            btnUser_SuaLienHe.Size = new Size(120, 36);
            btnUser_SuaLienHe.TabIndex = 0;
            btnUser_SuaLienHe.Text = "Sửa liên hệ";
            // 
            // btnUser_Xoa
            // 
            btnUser_Xoa.Location = new Point(1024, 10);
            btnUser_Xoa.Margin = new Padding(8, 4, 0, 0);
            btnUser_Xoa.Name = "btnUser_Xoa";
            btnUser_Xoa.Size = new Size(100, 36);
            btnUser_Xoa.TabIndex = 1;
            btnUser_Xoa.Text = "Xóa";
            // 
            // rowKy
            // 
            rowKy.Controls.Add(lblXemKy);
            rowKy.Controls.Add(cboUsers_Ky);
            rowKy.Controls.Add(btnUsers_Refresh);
            rowKy.Dock = DockStyle.Top;
            rowKy.Location = new Point(10, 33);
            rowKy.Name = "rowKy";
            rowKy.Size = new Size(1252, 48);
            rowKy.TabIndex = 2;
            rowKy.WrapContents = false;
            // 
            // lblXemKy
            // 
            lblXemKy.AutoSize = true;
            lblXemKy.Location = new Point(0, 10);
            lblXemKy.Margin = new Padding(0, 10, 8, 0);
            lblXemKy.Name = "lblXemKy";
            lblXemKy.Size = new Size(109, 23);
            lblXemKy.TabIndex = 0;
            lblXemKy.Text = "Xem theo kỳ:";
            // 
            // cboUsers_Ky
            // 
            cboUsers_Ky.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUsers_Ky.Location = new Point(117, 6);
            cboUsers_Ky.Margin = new Padding(0, 6, 8, 0);
            cboUsers_Ky.Name = "cboUsers_Ky";
            cboUsers_Ky.Size = new Size(260, 31);
            cboUsers_Ky.TabIndex = 1;
            // 
            // btnUsers_Refresh
            // 
            btnUsers_Refresh.Location = new Point(385, 4);
            btnUsers_Refresh.Margin = new Padding(0, 4, 0, 0);
            btnUsers_Refresh.Name = "btnUsers_Refresh";
            btnUsers_Refresh.Size = new Size(100, 36);
            btnUsers_Refresh.TabIndex = 2;
            btnUsers_Refresh.Text = "Tải lại";
            // 
            // grpTaoHS
            // 
            grpTaoHS.Controls.Add(tlpHS);
            grpTaoHS.Dock = DockStyle.Top;
            grpTaoHS.Location = new Point(0, 107);
            grpTaoHS.Margin = new Padding(0, 8, 0, 0);
            grpTaoHS.Name = "grpTaoHS";
            grpTaoHS.Padding = new Padding(10);
            grpTaoHS.Size = new Size(1272, 124);
            grpTaoHS.TabIndex = 1;
            grpTaoHS.TabStop = false;
            grpTaoHS.Text = "Tạo tài khoản Học sinh";
            // 
            // tlpHS
            // 
            tlpHS.ColumnCount = 8;
            tlpHS.ColumnStyles.Add(new ColumnStyle());
            tlpHS.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tlpHS.ColumnStyles.Add(new ColumnStyle());
            tlpHS.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tlpHS.ColumnStyles.Add(new ColumnStyle());
            tlpHS.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tlpHS.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpHS.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpHS.Controls.Add(lblHS_Ma, 0, 0);
            tlpHS.Controls.Add(txtHS_Ma, 1, 0);
            tlpHS.Controls.Add(lblHS_Ten, 2, 0);
            tlpHS.Controls.Add(txtHS_HoTen, 3, 0);
            tlpHS.Controls.Add(lblHS_Mk, 4, 0);
            tlpHS.Controls.Add(txtHS_MatKhau, 5, 0);
            tlpHS.Controls.Add(lblHS_Lop, 0, 1);
            tlpHS.Controls.Add(cboHS_Lop, 1, 1);
            tlpHS.Controls.Add(lblHS_Ky, 2, 1);
            tlpHS.Controls.Add(cboHS_HocKy, 3, 1);
            tlpHS.Controls.Add(btnHS_Them, 7, 1);
            tlpHS.Dock = DockStyle.Fill;
            tlpHS.Location = new Point(10, 33);
            tlpHS.Name = "tlpHS";
            tlpHS.RowCount = 2;
            tlpHS.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpHS.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpHS.Size = new Size(1252, 81);
            tlpHS.TabIndex = 0;
            // 
            // lblHS_Ma
            // 
            lblHS_Ma.Anchor = AnchorStyles.Left;
            lblHS_Ma.AutoSize = true;
            lblHS_Ma.Location = new Point(3, 4);
            lblHS_Ma.Name = "lblHS_Ma";
            lblHS_Ma.Size = new Size(38, 23);
            lblHS_Ma.TabIndex = 0;
            lblHS_Ma.Text = "Mã:";
            // 
            // txtHS_Ma
            // 
            txtHS_Ma.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtHS_Ma.Location = new Point(49, 3);
            txtHS_Ma.Name = "txtHS_Ma";
            txtHS_Ma.Size = new Size(154, 30);
            txtHS_Ma.TabIndex = 1;
            // 
            // lblHS_Ten
            // 
            lblHS_Ten.Anchor = AnchorStyles.Left;
            lblHS_Ten.AutoSize = true;
            lblHS_Ten.Location = new Point(216, 4);
            lblHS_Ten.Margin = new Padding(10, 0, 4, 0);
            lblHS_Ten.Name = "lblHS_Ten";
            lblHS_Ten.Size = new Size(66, 23);
            lblHS_Ten.TabIndex = 2;
            lblHS_Ten.Text = "Họ tên:";
            // 
            // txtHS_HoTen
            // 
            txtHS_HoTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtHS_HoTen.Location = new Point(289, 3);
            txtHS_HoTen.Name = "txtHS_HoTen";
            txtHS_HoTen.Size = new Size(214, 30);
            txtHS_HoTen.TabIndex = 3;
            // 
            // lblHS_Mk
            // 
            lblHS_Mk.Anchor = AnchorStyles.Left;
            lblHS_Mk.AutoSize = true;
            lblHS_Mk.Location = new Point(516, 4);
            lblHS_Mk.Margin = new Padding(10, 0, 4, 0);
            lblHS_Mk.Name = "lblHS_Mk";
            lblHS_Mk.Size = new Size(86, 23);
            lblHS_Mk.TabIndex = 4;
            lblHS_Mk.Text = "Mật khẩu:";
            // 
            // txtHS_MatKhau
            // 
            txtHS_MatKhau.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtHS_MatKhau.Location = new Point(609, 3);
            txtHS_MatKhau.Name = "txtHS_MatKhau";
            txtHS_MatKhau.Size = new Size(154, 30);
            txtHS_MatKhau.TabIndex = 5;
            // 
            // lblHS_Lop
            // 
            lblHS_Lop.Anchor = AnchorStyles.Left;
            lblHS_Lop.AutoSize = true;
            lblHS_Lop.Location = new Point(0, 47);
            lblHS_Lop.Margin = new Padding(0, 4, 4, 0);
            lblHS_Lop.Name = "lblHS_Lop";
            lblHS_Lop.Size = new Size(42, 23);
            lblHS_Lop.TabIndex = 6;
            lblHS_Lop.Text = "Lớp:";
            // 
            // cboHS_Lop
            // 
            cboHS_Lop.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboHS_Lop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHS_Lop.Location = new Point(49, 41);
            cboHS_Lop.Name = "cboHS_Lop";
            cboHS_Lop.Size = new Size(154, 31);
            cboHS_Lop.TabIndex = 7;
            // 
            // lblHS_Ky
            // 
            lblHS_Ky.Anchor = AnchorStyles.Left;
            lblHS_Ky.AutoSize = true;
            lblHS_Ky.Location = new Point(216, 47);
            lblHS_Ky.Margin = new Padding(10, 4, 4, 0);
            lblHS_Ky.Name = "lblHS_Ky";
            lblHS_Ky.Size = new Size(65, 23);
            lblHS_Ky.TabIndex = 8;
            lblHS_Ky.Text = "Học kỳ:";
            // 
            // cboHS_HocKy
            // 
            cboHS_HocKy.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboHS_HocKy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHS_HocKy.Location = new Point(289, 41);
            cboHS_HocKy.Name = "cboHS_HocKy";
            cboHS_HocKy.Size = new Size(214, 31);
            cboHS_HocKy.TabIndex = 9;
            // 
            // btnHS_Them
            // 
            btnHS_Them.Location = new Point(1135, 35);
            btnHS_Them.Name = "btnHS_Them";
            btnHS_Them.Size = new Size(114, 43);
            btnHS_Them.TabIndex = 10;
            btnHS_Them.Text = "Thêm HS";
            // 
            // grpTaoGV
            // 
            grpTaoGV.Controls.Add(tlpGV);
            grpTaoGV.Dock = DockStyle.Top;
            grpTaoGV.Location = new Point(0, 0);
            grpTaoGV.Name = "grpTaoGV";
            grpTaoGV.Padding = new Padding(10);
            grpTaoGV.Size = new Size(1272, 107);
            grpTaoGV.TabIndex = 2;
            grpTaoGV.TabStop = false;
            grpTaoGV.Text = "Tạo tài khoản Giáo viên";
            // 
            // tlpGV
            // 
            tlpGV.ColumnCount = 8;
            tlpGV.ColumnStyles.Add(new ColumnStyle());
            tlpGV.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tlpGV.ColumnStyles.Add(new ColumnStyle());
            tlpGV.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tlpGV.ColumnStyles.Add(new ColumnStyle());
            tlpGV.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tlpGV.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpGV.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpGV.Controls.Add(lblGV_Ma, 0, 0);
            tlpGV.Controls.Add(txtGV_Ma, 1, 0);
            tlpGV.Controls.Add(lblGV_Ten, 2, 0);
            tlpGV.Controls.Add(txtGV_HoTen, 3, 0);
            tlpGV.Controls.Add(lblGV_Mk, 4, 0);
            tlpGV.Controls.Add(txtGV_MatKhau, 5, 0);
            tlpGV.Controls.Add(btnGV_Them, 7, 0);
            tlpGV.Dock = DockStyle.Fill;
            tlpGV.Location = new Point(10, 33);
            tlpGV.Name = "tlpGV";
            tlpGV.RowCount = 1;
            tlpGV.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpGV.Size = new Size(1252, 64);
            tlpGV.TabIndex = 0;
            // 
            // lblGV_Ma
            // 
            lblGV_Ma.Anchor = AnchorStyles.Left;
            lblGV_Ma.AutoSize = true;
            lblGV_Ma.Location = new Point(3, 20);
            lblGV_Ma.Name = "lblGV_Ma";
            lblGV_Ma.Size = new Size(38, 23);
            lblGV_Ma.TabIndex = 0;
            lblGV_Ma.Text = "Mã:";
            // 
            // txtGV_Ma
            // 
            txtGV_Ma.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtGV_Ma.Location = new Point(47, 17);
            txtGV_Ma.Name = "txtGV_Ma";
            txtGV_Ma.Size = new Size(154, 30);
            txtGV_Ma.TabIndex = 1;
            // 
            // lblGV_Ten
            // 
            lblGV_Ten.Anchor = AnchorStyles.Left;
            lblGV_Ten.AutoSize = true;
            lblGV_Ten.Location = new Point(214, 20);
            lblGV_Ten.Margin = new Padding(10, 0, 4, 0);
            lblGV_Ten.Name = "lblGV_Ten";
            lblGV_Ten.Size = new Size(66, 23);
            lblGV_Ten.TabIndex = 2;
            lblGV_Ten.Text = "Họ tên:";
            // 
            // txtGV_HoTen
            // 
            txtGV_HoTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtGV_HoTen.Location = new Point(287, 17);
            txtGV_HoTen.Name = "txtGV_HoTen";
            txtGV_HoTen.Size = new Size(214, 30);
            txtGV_HoTen.TabIndex = 3;
            // 
            // lblGV_Mk
            // 
            lblGV_Mk.Anchor = AnchorStyles.Left;
            lblGV_Mk.AutoSize = true;
            lblGV_Mk.Location = new Point(514, 20);
            lblGV_Mk.Margin = new Padding(10, 0, 4, 0);
            lblGV_Mk.Name = "lblGV_Mk";
            lblGV_Mk.Size = new Size(86, 23);
            lblGV_Mk.TabIndex = 4;
            lblGV_Mk.Text = "Mật khẩu:";
            // 
            // txtGV_MatKhau
            // 
            txtGV_MatKhau.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtGV_MatKhau.Location = new Point(607, 17);
            txtGV_MatKhau.Name = "txtGV_MatKhau";
            txtGV_MatKhau.Size = new Size(154, 30);
            txtGV_MatKhau.TabIndex = 5;
            // 
            // btnGV_Them
            // 
            btnGV_Them.Location = new Point(1135, 3);
            btnGV_Them.Name = "btnGV_Them";
            btnGV_Them.Size = new Size(114, 58);
            btnGV_Them.TabIndex = 6;
            btnGV_Them.Text = "Thêm GV";
            btnGV_Them.Click += btnGV_Them_Click;
            // 
            // tabLop
            // 
            tabLop.Controls.Add(grpLop);
            tabLop.Location = new Point(4, 29);
            tabLop.Name = "tabLop";
            tabLop.Size = new Size(1272, 787);
            tabLop.TabIndex = 1;
            tabLop.Text = "Lớp";
            // 
            // grpLop
            // 
            grpLop.Controls.Add(dgvLop);
            grpLop.Controls.Add(pnlLopRight);
            grpLop.Dock = DockStyle.Fill;
            grpLop.Location = new Point(0, 0);
            grpLop.Name = "grpLop";
            grpLop.Padding = new Padding(10);
            grpLop.Size = new Size(1272, 787);
            grpLop.TabIndex = 0;
            grpLop.TabStop = false;
            grpLop.Text = "Lớp học";
            // 
            // dgvLop
            // 
            dgvLop.AllowUserToAddRows = false;
            dgvLop.ColumnHeadersHeight = 36;
            dgvLop.Dock = DockStyle.Fill;
            dgvLop.Location = new Point(10, 33);
            dgvLop.MultiSelect = false;
            dgvLop.Name = "dgvLop";
            dgvLop.ReadOnly = true;
            dgvLop.RowHeadersWidth = 51;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Size = new Size(952, 744);
            dgvLop.TabIndex = 0;
            // 
            // pnlLopRight
            // 
            pnlLopRight.Controls.Add(tlpLop);
            pnlLopRight.Dock = DockStyle.Right;
            pnlLopRight.Location = new Point(962, 33);
            pnlLopRight.Name = "pnlLopRight";
            pnlLopRight.Padding = new Padding(10);
            pnlLopRight.Size = new Size(300, 744);
            pnlLopRight.TabIndex = 1;
            // 
            // tlpLop
            // 
            tlpLop.ColumnCount = 1;
            tlpLop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpLop.Controls.Add(lblTenLop, 0, 0);
            tlpLop.Controls.Add(txtLop_Ten, 0, 1);
            tlpLop.Controls.Add(lblKhoi, 0, 2);
            tlpLop.Controls.Add(cboLop_Khoi, 0, 3);
            tlpLop.Controls.Add(btnLop_Them, 0, 4);
            tlpLop.Controls.Add(btnLop_Sua, 0, 5);
            tlpLop.Controls.Add(btnLop_Xoa, 0, 6);
            tlpLop.Dock = DockStyle.Fill;
            tlpLop.Location = new Point(10, 10);
            tlpLop.Name = "tlpLop";
            tlpLop.RowCount = 7;
            tlpLop.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlpLop.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpLop.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlpLop.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpLop.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpLop.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpLop.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpLop.Size = new Size(280, 724);
            tlpLop.TabIndex = 0;
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Dock = DockStyle.Fill;
            lblTenLop.Location = new Point(3, 0);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Size = new Size(274, 22);
            lblTenLop.TabIndex = 0;
            lblTenLop.Text = "Tên lớp";
            lblTenLop.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtLop_Ten
            // 
            txtLop_Ten.Dock = DockStyle.Top;
            txtLop_Ten.Location = new Point(3, 25);
            txtLop_Ten.Name = "txtLop_Ten";
            txtLop_Ten.Size = new Size(274, 30);
            txtLop_Ten.TabIndex = 1;
            // 
            // lblKhoi
            // 
            lblKhoi.AutoSize = true;
            lblKhoi.Dock = DockStyle.Fill;
            lblKhoi.Location = new Point(3, 56);
            lblKhoi.Name = "lblKhoi";
            lblKhoi.Size = new Size(274, 22);
            lblKhoi.TabIndex = 2;
            lblKhoi.Text = "Khối (10/11/12)";
            lblKhoi.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cboLop_Khoi
            // 
            cboLop_Khoi.Dock = DockStyle.Top;
            cboLop_Khoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop_Khoi.Location = new Point(3, 81);
            cboLop_Khoi.Name = "cboLop_Khoi";
            cboLop_Khoi.Size = new Size(274, 31);
            cboLop_Khoi.TabIndex = 3;
            // 
            // btnLop_Them
            // 
            btnLop_Them.Dock = DockStyle.Top;
            btnLop_Them.Location = new Point(3, 115);
            btnLop_Them.Name = "btnLop_Them";
            btnLop_Them.Size = new Size(274, 34);
            btnLop_Them.TabIndex = 4;
            btnLop_Them.Text = "Thêm lớp";
            // 
            // btnLop_Sua
            // 
            btnLop_Sua.Dock = DockStyle.Top;
            btnLop_Sua.Location = new Point(3, 155);
            btnLop_Sua.Name = "btnLop_Sua";
            btnLop_Sua.Size = new Size(274, 34);
            btnLop_Sua.TabIndex = 5;
            btnLop_Sua.Text = "Sửa lớp";
            // 
            // btnLop_Xoa
            // 
            btnLop_Xoa.Dock = DockStyle.Top;
            btnLop_Xoa.Location = new Point(3, 195);
            btnLop_Xoa.Name = "btnLop_Xoa";
            btnLop_Xoa.Size = new Size(274, 37);
            btnLop_Xoa.TabIndex = 6;
            btnLop_Xoa.Text = "Xóa lớp";
            // 
            // tabMon
            // 
            tabMon.Controls.Add(grpMon);
            tabMon.Location = new Point(4, 29);
            tabMon.Name = "tabMon";
            tabMon.Size = new Size(1272, 787);
            tabMon.TabIndex = 2;
            tabMon.Text = "Môn";
            // 
            // grpMon
            // 
            grpMon.Controls.Add(dgvMon);
            grpMon.Controls.Add(pnlMonRight);
            grpMon.Dock = DockStyle.Fill;
            grpMon.Location = new Point(0, 0);
            grpMon.Name = "grpMon";
            grpMon.Padding = new Padding(10);
            grpMon.Size = new Size(1272, 787);
            grpMon.TabIndex = 0;
            grpMon.TabStop = false;
            grpMon.Text = "Môn học";
            // 
            // dgvMon
            // 
            dgvMon.AllowUserToAddRows = false;
            dgvMon.ColumnHeadersHeight = 36;
            dgvMon.Dock = DockStyle.Fill;
            dgvMon.Location = new Point(10, 33);
            dgvMon.MultiSelect = false;
            dgvMon.Name = "dgvMon";
            dgvMon.ReadOnly = true;
            dgvMon.RowHeadersWidth = 51;
            dgvMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMon.Size = new Size(952, 744);
            dgvMon.TabIndex = 0;
            // 
            // pnlMonRight
            // 
            pnlMonRight.Controls.Add(tlpMon);
            pnlMonRight.Dock = DockStyle.Right;
            pnlMonRight.Location = new Point(962, 33);
            pnlMonRight.Name = "pnlMonRight";
            pnlMonRight.Padding = new Padding(10);
            pnlMonRight.Size = new Size(300, 744);
            pnlMonRight.TabIndex = 1;
            // 
            // tlpMon
            // 
            tlpMon.ColumnCount = 1;
            tlpMon.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMon.Controls.Add(lblTenMon, 0, 0);
            tlpMon.Controls.Add(txtMon_Ten, 0, 1);
            tlpMon.Controls.Add(btnMon_Them, 0, 3);
            tlpMon.Controls.Add(btnMon_Sua, 0, 4);
            tlpMon.Controls.Add(btnMon_Xoa, 0, 5);
            tlpMon.Dock = DockStyle.Fill;
            tlpMon.Location = new Point(10, 10);
            tlpMon.Name = "tlpMon";
            tlpMon.RowCount = 7;
            tlpMon.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlpMon.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpMon.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tlpMon.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpMon.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpMon.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpMon.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMon.Size = new Size(280, 724);
            tlpMon.TabIndex = 0;
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Dock = DockStyle.Fill;
            lblTenMon.Location = new Point(3, 0);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(274, 22);
            lblTenMon.TabIndex = 0;
            lblTenMon.Text = "Tên môn học";
            lblTenMon.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtMon_Ten
            // 
            txtMon_Ten.Dock = DockStyle.Top;
            txtMon_Ten.Location = new Point(3, 25);
            txtMon_Ten.Name = "txtMon_Ten";
            txtMon_Ten.Size = new Size(274, 30);
            txtMon_Ten.TabIndex = 1;
            // 
            // btnMon_Them
            // 
            btnMon_Them.Dock = DockStyle.Top;
            btnMon_Them.Location = new Point(3, 71);
            btnMon_Them.Name = "btnMon_Them";
            btnMon_Them.Size = new Size(274, 34);
            btnMon_Them.TabIndex = 2;
            btnMon_Them.Text = "Thêm môn";
            // 
            // btnMon_Sua
            // 
            btnMon_Sua.Dock = DockStyle.Top;
            btnMon_Sua.Location = new Point(3, 111);
            btnMon_Sua.Name = "btnMon_Sua";
            btnMon_Sua.Size = new Size(274, 34);
            btnMon_Sua.TabIndex = 3;
            btnMon_Sua.Text = "Sửa môn";
            // 
            // btnMon_Xoa
            // 
            btnMon_Xoa.Dock = DockStyle.Top;
            btnMon_Xoa.Location = new Point(3, 151);
            btnMon_Xoa.Name = "btnMon_Xoa";
            btnMon_Xoa.Size = new Size(274, 34);
            btnMon_Xoa.TabIndex = 4;
            btnMon_Xoa.Text = "Xóa môn";
            // 
            // tabHocKy
            // 
            tabHocKy.Controls.Add(dgvHocKy);
            tabHocKy.Controls.Add(rightKy);
            tabHocKy.Location = new Point(4, 29);
            tabHocKy.Name = "tabHocKy";
            tabHocKy.Size = new Size(1272, 787);
            tabHocKy.TabIndex = 3;
            tabHocKy.Text = "Học kỳ";
            // 
            // dgvHocKy
            // 
            dgvHocKy.AllowUserToAddRows = false;
            dgvHocKy.ColumnHeadersHeight = 36;
            dgvHocKy.Dock = DockStyle.Fill;
            dgvHocKy.Location = new Point(0, 0);
            dgvHocKy.MultiSelect = false;
            dgvHocKy.Name = "dgvHocKy";
            dgvHocKy.ReadOnly = true;
            dgvHocKy.RowHeadersWidth = 51;
            dgvHocKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocKy.Size = new Size(1012, 787);
            dgvHocKy.TabIndex = 0;
            // 
            // rightKy
            // 
            rightKy.Controls.Add(tlpKy);
            rightKy.Dock = DockStyle.Right;
            rightKy.Location = new Point(1012, 0);
            rightKy.Name = "rightKy";
            rightKy.Padding = new Padding(10);
            rightKy.Size = new Size(260, 787);
            rightKy.TabIndex = 1;
            // 
            // tlpKy
            // 
            tlpKy.ColumnCount = 1;
            tlpKy.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpKy.Controls.Add(lblNamHoc, 0, 0);
            tlpKy.Controls.Add(txtNamHoc, 0, 1);
            tlpKy.Controls.Add(lblKyThu, 0, 2);
            tlpKy.Controls.Add(cboKyThu, 0, 3);
            tlpKy.Controls.Add(btnKy_Them, 0, 4);
            tlpKy.Controls.Add(btnKy_Sua, 0, 5);
            tlpKy.Controls.Add(btnKy_Xoa, 0, 6);
            tlpKy.Dock = DockStyle.Fill;
            tlpKy.Location = new Point(10, 10);
            tlpKy.Name = "tlpKy";
            tlpKy.RowCount = 7;
            tlpKy.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlpKy.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpKy.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlpKy.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpKy.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpKy.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpKy.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpKy.Size = new Size(240, 767);
            tlpKy.TabIndex = 0;
            // 
            // lblNamHoc
            // 
            lblNamHoc.Dock = DockStyle.Fill;
            lblNamHoc.Location = new Point(3, 0);
            lblNamHoc.Name = "lblNamHoc";
            lblNamHoc.Size = new Size(234, 22);
            lblNamHoc.TabIndex = 0;
            lblNamHoc.Text = "Năm học";
            lblNamHoc.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtNamHoc
            // 
            txtNamHoc.Location = new Point(3, 25);
            txtNamHoc.Name = "txtNamHoc";
            txtNamHoc.Size = new Size(234, 30);
            txtNamHoc.TabIndex = 1;
            // 
            // lblKyThu
            // 
            lblKyThu.Dock = DockStyle.Fill;
            lblKyThu.Location = new Point(3, 56);
            lblKyThu.Name = "lblKyThu";
            lblKyThu.Size = new Size(234, 22);
            lblKyThu.TabIndex = 2;
            lblKyThu.Text = "Kỳ thứ (1/2)";
            lblKyThu.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cboKyThu
            // 
            cboKyThu.Dock = DockStyle.Top;
            cboKyThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKyThu.Location = new Point(3, 81);
            cboKyThu.Name = "cboKyThu";
            cboKyThu.Size = new Size(234, 31);
            cboKyThu.TabIndex = 3;
            // 
            // btnKy_Them
            // 
            btnKy_Them.Location = new Point(3, 115);
            btnKy_Them.Name = "btnKy_Them";
            btnKy_Them.Size = new Size(234, 34);
            btnKy_Them.TabIndex = 4;
            btnKy_Them.Text = "Thêm";
            // 
            // btnKy_Sua
            // 
            btnKy_Sua.Location = new Point(3, 155);
            btnKy_Sua.Name = "btnKy_Sua";
            btnKy_Sua.Size = new Size(234, 34);
            btnKy_Sua.TabIndex = 5;
            btnKy_Sua.Text = "Sửa";
            // 
            // btnKy_Xoa
            // 
            btnKy_Xoa.Location = new Point(3, 195);
            btnKy_Xoa.Name = "btnKy_Xoa";
            btnKy_Xoa.Size = new Size(234, 37);
            btnKy_Xoa.TabIndex = 6;
            btnKy_Xoa.Text = "Xóa";
            // 
            // tabPhanCong
            // 
            tabPhanCong.Controls.Add(dgvPhanCong);
            tabPhanCong.Controls.Add(actionsPC);
            tabPhanCong.Controls.Add(topPC);
            tabPhanCong.Location = new Point(4, 29);
            tabPhanCong.Name = "tabPhanCong";
            tabPhanCong.Size = new Size(1272, 787);
            tabPhanCong.TabIndex = 4;
            tabPhanCong.Text = "Phân công";
            // 
            // dgvPhanCong
            // 
            dgvPhanCong.AllowUserToAddRows = false;
            dgvPhanCong.ColumnHeadersHeight = 36;
            dgvPhanCong.Dock = DockStyle.Fill;
            dgvPhanCong.Location = new Point(0, 68);
            dgvPhanCong.MultiSelect = false;
            dgvPhanCong.Name = "dgvPhanCong";
            dgvPhanCong.ReadOnly = true;
            dgvPhanCong.RowHeadersWidth = 51;
            dgvPhanCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCong.Size = new Size(1072, 719);
            dgvPhanCong.TabIndex = 0;
            // 
            // actionsPC
            // 
            actionsPC.Controls.Add(stackBtns);
            actionsPC.Dock = DockStyle.Right;
            actionsPC.Location = new Point(1072, 68);
            actionsPC.Name = "actionsPC";
            actionsPC.Padding = new Padding(10);
            actionsPC.Size = new Size(200, 719);
            actionsPC.TabIndex = 1;
            // 
            // stackBtns
            // 
            stackBtns.ColumnCount = 1;
            stackBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            stackBtns.Controls.Add(btnPC_Them, 0, 0);
            stackBtns.Controls.Add(btnPC_Xoa, 0, 1);
            stackBtns.Controls.Add(btnPC_Refresh, 0, 2);
            stackBtns.Dock = DockStyle.Top;
            stackBtns.Location = new Point(10, 10);
            stackBtns.Name = "stackBtns";
            stackBtns.RowCount = 3;
            stackBtns.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            stackBtns.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            stackBtns.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            stackBtns.Size = new Size(180, 166);
            stackBtns.TabIndex = 0;
            // 
            // btnPC_Them
            // 
            btnPC_Them.Location = new Point(3, 3);
            btnPC_Them.Name = "btnPC_Them";
            btnPC_Them.Size = new Size(174, 42);
            btnPC_Them.TabIndex = 0;
            btnPC_Them.Text = "Thêm";
            // 
            // btnPC_Xoa
            // 
            btnPC_Xoa.Location = new Point(3, 51);
            btnPC_Xoa.Name = "btnPC_Xoa";
            btnPC_Xoa.Size = new Size(174, 42);
            btnPC_Xoa.TabIndex = 1;
            btnPC_Xoa.Text = "Thu hồi";
            // 
            // btnPC_Refresh
            // 
            btnPC_Refresh.Location = new Point(3, 99);
            btnPC_Refresh.Name = "btnPC_Refresh";
            btnPC_Refresh.Size = new Size(174, 64);
            btnPC_Refresh.TabIndex = 2;
            btnPC_Refresh.Text = "Tải lại";
            // 
            // topPC
            // 
            topPC.Controls.Add(rowPC);
            topPC.Dock = DockStyle.Top;
            topPC.Location = new Point(0, 0);
            topPC.Name = "topPC";
            topPC.Padding = new Padding(10, 8, 10, 6);
            topPC.Size = new Size(1272, 68);
            topPC.TabIndex = 2;
            // 
            // rowPC
            // 
            rowPC.Controls.Add(lblPCKy);
            rowPC.Controls.Add(cboPC_Ky);
            rowPC.Controls.Add(lblPCLop);
            rowPC.Controls.Add(cboPC_Lop);
            rowPC.Controls.Add(lblPCMon);
            rowPC.Controls.Add(cboPC_Mon);
            rowPC.Controls.Add(lblPCGV);
            rowPC.Controls.Add(cboPC_GV);
            rowPC.Dock = DockStyle.Fill;
            rowPC.Location = new Point(10, 8);
            rowPC.Name = "rowPC";
            rowPC.Size = new Size(1252, 54);
            rowPC.TabIndex = 0;
            // 
            // lblPCKy
            // 
            lblPCKy.AutoSize = true;
            lblPCKy.Location = new Point(0, 8);
            lblPCKy.Margin = new Padding(0, 8, 6, 0);
            lblPCKy.Name = "lblPCKy";
            lblPCKy.Size = new Size(31, 23);
            lblPCKy.TabIndex = 0;
            lblPCKy.Text = "Kỳ:";
            // 
            // cboPC_Ky
            // 
            cboPC_Ky.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPC_Ky.Location = new Point(37, 4);
            cboPC_Ky.Margin = new Padding(0, 4, 16, 0);
            cboPC_Ky.Name = "cboPC_Ky";
            cboPC_Ky.Size = new Size(220, 31);
            cboPC_Ky.TabIndex = 1;
            // 
            // lblPCLop
            // 
            lblPCLop.AutoSize = true;
            lblPCLop.Location = new Point(273, 8);
            lblPCLop.Margin = new Padding(0, 8, 6, 0);
            lblPCLop.Name = "lblPCLop";
            lblPCLop.Size = new Size(42, 23);
            lblPCLop.TabIndex = 2;
            lblPCLop.Text = "Lớp:";
            // 
            // cboPC_Lop
            // 
            cboPC_Lop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPC_Lop.Location = new Point(321, 4);
            cboPC_Lop.Margin = new Padding(0, 4, 16, 0);
            cboPC_Lop.Name = "cboPC_Lop";
            cboPC_Lop.Size = new Size(180, 31);
            cboPC_Lop.TabIndex = 3;
            // 
            // lblPCMon
            // 
            lblPCMon.AutoSize = true;
            lblPCMon.Location = new Point(517, 8);
            lblPCMon.Margin = new Padding(0, 8, 6, 0);
            lblPCMon.Name = "lblPCMon";
            lblPCMon.Size = new Size(49, 23);
            lblPCMon.TabIndex = 4;
            lblPCMon.Text = "Môn:";
            // 
            // cboPC_Mon
            // 
            cboPC_Mon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPC_Mon.Location = new Point(572, 4);
            cboPC_Mon.Margin = new Padding(0, 4, 16, 0);
            cboPC_Mon.Name = "cboPC_Mon";
            cboPC_Mon.Size = new Size(180, 31);
            cboPC_Mon.TabIndex = 5;
            // 
            // lblPCGV
            // 
            lblPCGV.AutoSize = true;
            lblPCGV.Location = new Point(768, 8);
            lblPCGV.Margin = new Padding(0, 8, 6, 0);
            lblPCGV.Name = "lblPCGV";
            lblPCGV.Size = new Size(85, 23);
            lblPCGV.TabIndex = 6;
            lblPCGV.Text = "Giáo viên:";
            // 
            // cboPC_GV
            // 
            cboPC_GV.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPC_GV.Location = new Point(859, 4);
            cboPC_GV.Margin = new Padding(0, 4, 16, 0);
            cboPC_GV.Name = "cboPC_GV";
            cboPC_GV.Size = new Size(240, 31);
            cboPC_GV.TabIndex = 7;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1280, 820);
            Controls.Add(tabs);
            Font = new Font("Segoe UI", 10F);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản trị – DemoAppQLTH";
            tabs.ResumeLayout(false);
            tabUsers.ResumeLayout(false);
            grpXemNguoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlUsersBtns.ResumeLayout(false);
            rowKy.ResumeLayout(false);
            rowKy.PerformLayout();
            grpTaoHS.ResumeLayout(false);
            tlpHS.ResumeLayout(false);
            tlpHS.PerformLayout();
            grpTaoGV.ResumeLayout(false);
            tlpGV.ResumeLayout(false);
            tlpGV.PerformLayout();
            tabLop.ResumeLayout(false);
            grpLop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            pnlLopRight.ResumeLayout(false);
            tlpLop.ResumeLayout(false);
            tlpLop.PerformLayout();
            tabMon.ResumeLayout(false);
            grpMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMon).EndInit();
            pnlMonRight.ResumeLayout(false);
            tlpMon.ResumeLayout(false);
            tlpMon.PerformLayout();
            tabHocKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).EndInit();
            rightKy.ResumeLayout(false);
            tlpKy.ResumeLayout(false);
            tlpKy.PerformLayout();
            tabPhanCong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhanCong).EndInit();
            actionsPC.ResumeLayout(false);
            stackBtns.ResumeLayout(false);
            topPC.ResumeLayout(false);
            rowPC.ResumeLayout(false);
            rowPC.PerformLayout();
            ResumeLayout(false);
        }

        // ====== extra fields used in InitializeComponent ======
        private FlowLayoutPanel rowKy;
        private Label lblXemKy;
        private TableLayoutPanel tlpHS;
        private Label lblHS_Ma;
        private Label lblHS_Ten;
        private Label lblHS_Mk;
        private Label lblHS_Lop;
        private Label lblHS_Ky;
        private TableLayoutPanel tlpGV;
        private Label lblGV_Ma;
        private Label lblGV_Ten;
        private Label lblGV_Mk;
        private Label lblTenLop;
        private Label lblKhoi;
        private Label lblTenMon;
        private Label lblNamHoc;
        private Label lblKyThu;
        private TableLayoutPanel stackBtns;
        private Label lblPCKy;
        private Label lblPCLop;
        private Label lblPCMon;
        private Label lblPCGV;
        

    }
}
