using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DemoAppQLTH.Application.Services;
using DemoAppQLTH.Infrastructure.EF;

namespace QuanLyTruongHocV1.UI.Forms
{
    public partial class AdminForm : Form
    {
        // ===== Theme colors =====
        private static readonly Color Accent = ColorTranslator.FromHtml("#4680ff");
        private static readonly Color AccentDark = Color.FromArgb(0x36, 0x66, 0xcc);
        private static readonly Color Back = Color.White;
        private static readonly Color TextMain = Color.FromArgb(33, 37, 41);

        private readonly AdminService _svc;

        public AdminForm()
        {
            InitializeComponent();

            FixLayout();
            ApplyTheme();

            // Tạo DbContext và Service - nên dùng Dependency Injection trong tương lai
            var ctx = new SchoolDbContextFactory().CreateDbContext(Array.Empty<string>());
            _svc = new AdminService(ctx);

            Load += (_, __) =>
            {

                // ===== Users =====
                BindLookupsUsers();
                BindUsersGrid();
                btnGV_Them.Click += (_, __) => GV_Them();
                btnHS_Them.Click += (_, __) => HS_Them();
                btnUsers_Refresh.Click += (_, __) => BindUsersGrid();
                btnUser_SuaLienHe.Click += (_, __) => User_SuaLienHe();
                btnUser_Xoa.Click += (_, __) => User_Xoa();
                cboUsers_Ky.SelectedIndexChanged += (_, __) => BindUsersGrid();

                // ===== Lớp =====
                BindLopLookups();
                BindLopGrid();
                dgvLop.SelectionChanged += (_, __) => Lop_LoadToEditor();
                btnLop_Them.Click += (_, __) => Lop_Them();
                btnLop_Sua.Click += (_, __) => Lop_Sua();
                btnLop_Xoa.Click += (_, __) => Lop_Xoa();

                // ===== Môn =====
                BindMonGrid();
                dgvMon.SelectionChanged += (_, __) => Mon_LoadToEditor();
                btnMon_Them.Click += (_, __) => Mon_Them();
                btnMon_Sua.Click += (_, __) => Mon_Sua();
                btnMon_Xoa.Click += (_, __) => Mon_Xoa();

                // ===== Học kỳ =====
                BindKyLookups();
                BindHocKyGrid();
                dgvHocKy.SelectionChanged += (_, __) => Ky_LoadToEditor();
                btnKy_Them.Click += (_, __) => Ky_Them();
                btnKy_Sua.Click += (_, __) => Ky_Sua();
                btnKy_Xoa.Click += (_, __) => Ky_Xoa();

                // ===== Phân công =====
                BindPC_Lookups();
                cboPC_Ky.SelectedIndexChanged += (_, __) => { BindPC_Lop(); BindPC_Grid(); };
                cboPC_Lop.SelectedIndexChanged += (_, __) => { BindPC_Mon(); BindPC_Grid(); };
                btnPC_Them.Click += (_, __) => PC_Them();
                btnPC_Xoa.Click += (_, __) => PC_Xoa();
                btnPC_Refresh.Click += (_, __) => BindPC_Grid();
            };

            // DbContext sẽ được dispose khi form đóng (nếu cần quản lý lifecycle)
        }

        // ============================== THEME & LAYOUT ==============================
        private void FixLayout()
        {
            Padding = Padding.Empty;
            DoubleBuffered = true;

            foreach (TabPage tp in tabs.TabPages)
            {
                tp.Padding = Padding.Empty;
                tp.BackColor = Back;
                tp.UseVisualStyleBackColor = false;
            }

            foreach (var dgv in Controls.OfType<Control>().SelectMany(DescDgv))
                dgv.Dock = DockStyle.Fill;

            static System.Collections.Generic.IEnumerable<DataGridView> DescDgv(Control c)
            {
                foreach (Control child in c.Controls)
                {
                    if (child is DataGridView dg) yield return dg;
                    foreach (var sub in DescDgv(child)) yield return sub;
                }
            }
        }

        private void ApplyTheme()
        {
            BackColor = Back;
            ForeColor = TextMain;

            foreach (var btn in Controls.OfType<Control>().SelectMany(DescBtn))
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Accent;
                btn.ForeColor = Color.White;
                btn.Height = Math.Max(btn.Height, 28);
                btn.Padding = new Padding(6, 3, 6, 3);
                btn.MouseEnter += (_, __) => btn.BackColor = AccentDark;
                btn.MouseLeave += (_, __) => btn.BackColor = Accent;
            }

            foreach (var gb in Controls.OfType<Control>().SelectMany(DescGb))
            {
                gb.ForeColor = TextMain;
                var bar = new Panel { Dock = DockStyle.Top, Height = 3, BackColor = Accent };
                if (!gb.Controls.OfType<Panel>().Any(p => p.Height == 3 && p.Dock == DockStyle.Top))
                {
                    gb.Controls.Add(bar);
                    gb.Controls.SetChildIndex(bar, 0);
                }
            }

            foreach (var dgv in Controls.OfType<Control>().SelectMany(DescDgv))
            {
                dgv.BackgroundColor = Back;
                dgv.EnableHeadersVisualStyles = false;
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.GridColor = Color.FromArgb(240, 240, 240);

                var header = dgv.ColumnHeadersDefaultCellStyle;
                header.BackColor = Accent;
                header.ForeColor = Color.White;
                header.SelectionBackColor = Accent;
                header.SelectionForeColor = Color.White;

                var cell = dgv.DefaultCellStyle;
                cell.BackColor = Color.White;
                cell.ForeColor = TextMain;
                cell.SelectionBackColor = Color.FromArgb(233, 240, 255);
                cell.SelectionForeColor = TextMain;

                dgv.RowHeadersVisible = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.ColumnHeadersHeight = 30;
            }

            foreach (var cbo in Controls.OfType<Control>().SelectMany(DescCbo))
            {
                cbo.BackColor = Color.White;
                cbo.ForeColor = TextMain;
                if (cbo is ComboBox combo) combo.FlatStyle = FlatStyle.Standard;
            }
            foreach (var lbl in Controls.OfType<Control>().SelectMany(DescLbl))
                lbl.ForeColor = TextMain;

            static System.Collections.Generic.IEnumerable<Button> DescBtn(Control c)
            {
                foreach (Control child in c.Controls)
                {
                    if (child is Button b) yield return b;
                    foreach (var sub in DescBtn(child)) yield return sub;
                }
            }
            static System.Collections.Generic.IEnumerable<GroupBox> DescGb(Control c)
            {
                foreach (Control child in c.Controls)
                {
                    if (child is GroupBox g) yield return g;
                    foreach (var sub in DescGb(child)) yield return sub;
                }
            }
            static System.Collections.Generic.IEnumerable<DataGridView> DescDgv(Control c)
            {
                foreach (Control child in c.Controls)
                {
                    if (child is DataGridView dg) yield return dg;
                    foreach (var sub in DescDgv(child)) yield return sub;
                }
            }
            static System.Collections.Generic.IEnumerable<Control> DescCbo(Control c)
            {
                foreach (Control child in c.Controls)
                {
                    if (child is ComboBox) yield return child;
                    foreach (var sub in DescCbo(child)) yield return sub;
                }
            }
            static System.Collections.Generic.IEnumerable<Label> DescLbl(Control c)
            {
                foreach (Control child in c.Controls)
                {
                    if (child is Label lb) yield return lb;
                    foreach (var sub in DescLbl(child)) yield return sub;
                }
            }
        }

        // ============================== HELPERS ==============================
        private static Guid? GetId(ComboBox cbo)
            => (cbo.SelectedItem is ComboItem it) ? it.Id : (Guid?)null;

        private static int ParseIntOr(string? s, int fallback)
            => int.TryParse(s, out var v) ? v : fallback;

        private sealed class ComboItem
        {
            public Guid Id { get; init; }
            public string Text { get; init; } = "";
            public override string ToString() => Text;
        }

        // ============================== TAB 1: NGƯỜI DÙNG ==============================
        private void BindLookupsUsers()
        {
            cboHS_Lop.Items.Clear();
            foreach (var l in _svc.LookupLop())
                cboHS_Lop.Items.Add(new ComboItem { Id = l.Id, Text = $"{l.Khoi}-{l.Ten}" });
            if (cboHS_Lop.Items.Count > 0) cboHS_Lop.SelectedIndex = 0;

            var kys = _svc.LookupHocKy();
            cboHS_HocKy.Items.Clear();
            cboUsers_Ky.Items.Clear();
            foreach (var k in kys)
            {
                var it = new ComboItem { Id = k.Id, Text = $"{k.NamHoc}-K{k.KyThu}" };
                cboHS_HocKy.Items.Add(it);
                cboUsers_Ky.Items.Add(it);
            }
            if (cboHS_HocKy.Items.Count > 0) cboHS_HocKy.SelectedIndex = 0;
            if (cboUsers_Ky.Items.Count > 0) cboUsers_Ky.SelectedIndex = 0;
        }

        private void BindUsersGrid()
        {
            var kyId = GetId(cboUsers_Ky);
            if (kyId == null) { dgvUsers.DataSource = null; return; }

            var rows = _svc.ListUsersWithClass(kyId.Value)
                           .Select(x => new { x.Id, x.Ma, x.HoTen, Loai = x.Loai, Lop = x.LopHienTai })
                           .ToList();
            dgvUsers.DataSource = rows;
            if (dgvUsers.Columns["Id"] != null) dgvUsers.Columns["Id"].Visible = false;
        }

        private void GV_Them()
        {
            try
            {
                _svc.CreateGiaoVien(txtGV_Ma.Text, txtGV_HoTen.Text, txtGV_MatKhau.Text);
                txtGV_Ma.Clear(); txtGV_HoTen.Clear(); txtGV_MatKhau.Clear();
                BindPC_Lookups();
                BindUsersGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thêm GV", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void HS_Them()
        {
            var lopId = GetId(cboHS_Lop);
            var kyId = GetId(cboHS_HocKy);
            if (lopId == null || kyId == null) { MessageBox.Show("Chọn lớp & học kỳ"); return; }

            try
            {
                _svc.CreateHocSinh(txtHS_Ma.Text, txtHS_HoTen.Text, txtHS_MatKhau.Text, lopId.Value, kyId.Value);
                txtHS_Ma.Clear(); txtHS_HoTen.Clear(); txtHS_MatKhau.Clear();
                BindUsersGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thêm HS", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private Guid? SelectedUserId()
        {
            if (dgvUsers.CurrentRow == null) return null;
            var v = dgvUsers.CurrentRow.Cells["Id"].Value?.ToString();
            return Guid.TryParse(v, out var id) ? id : null;
        }

        private void User_SuaLienHe()
        {
            var id = SelectedUserId();
            if (id == null) { MessageBox.Show("Chọn 1 dòng."); return; }

            // Nếu có API lấy liên hệ hiện tại thì điền sẵn, còn không thì để rỗng:
            string? email = null, sdt = null;
            try
            {
                // var info = _svc.GetLienHeNguoiDung(id.Value);
                // email = info.Email; sdt = info.DienThoai;
            }
            catch { }

            using var dlg = new EditContactDialog(email, sdt);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try { _svc.UpdateNguoiLienHe(id.Value, dlg.Email, dlg.DienThoai); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void User_Xoa()
        {
            var id = SelectedUserId();
            if (id == null) { MessageBox.Show("Chọn 1 dòng."); return; }
            if (MessageBox.Show("Xóa người dùng này? (sẽ xóa kèm dữ liệu liên quan)",
                                "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { _svc.DeleteNguoiForce(id.Value); BindUsersGrid(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ============================== TAB 2: LỚP ==============================
        private void BindLopLookups()
        {
            cboLop_Khoi.Items.Clear();
            cboLop_Khoi.Items.AddRange(new object[] { "10", "11", "12" });
            if (cboLop_Khoi.Items.Count > 0) cboLop_Khoi.SelectedIndex = 0;
        }

        private void BindLopGrid()
        {
            var rows = _svc.ListLop().Select(l => new { l.Id, l.Ten, l.Khoi }).ToList();
            dgvLop.DataSource = rows;
            if (dgvLop.Columns["Id"] != null) dgvLop.Columns["Id"].Visible = false;
        }

        private Guid? SelectedLopId()
        {
            if (dgvLop.CurrentRow == null) return null;
            var v = dgvLop.CurrentRow.Cells["Id"].Value?.ToString();
            return Guid.TryParse(v, out var id) ? id : null;
        }

        private void Lop_LoadToEditor()
        {
            if (dgvLop.CurrentRow == null) return;
            txtLop_Ten.Text = dgvLop.CurrentRow.Cells["Ten"]?.Value?.ToString() ?? "";
            var khoi = dgvLop.CurrentRow.Cells["Khoi"]?.Value?.ToString();
            cboLop_Khoi.SelectedItem = khoi ?? "10";
        }

        private void Lop_Them()
        {
            try
            {
                var ten = (txtLop_Ten.Text ?? "").Trim();
                var khoi = ParseIntOr(cboLop_Khoi.SelectedItem as string, 10);
                _svc.CreateLop(ten, khoi);
                BindLopGrid(); BindPC_Lookups(); BindLookupsUsers();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thêm lớp"); }
        }

        private void Lop_Sua()
        {
            var id = SelectedLopId();
            if (id == null) { MessageBox.Show("Chọn lớp"); return; }
            try
            {
                var ten = (txtLop_Ten.Text ?? "").Trim();
                var khoi = ParseIntOr(cboLop_Khoi.SelectedItem as string, 10);
                _svc.UpdateLop(id.Value, ten, khoi, null);
                BindLopGrid(); BindPC_Lookups(); BindLookupsUsers();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Sửa lớp"); }
        }

        private void Lop_Xoa()
        {
            var id = SelectedLopId();
            if (id == null) { MessageBox.Show("Chọn lớp"); return; }
            if (MessageBox.Show("Xóa lớp này?", "Xóa lớp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { _svc.DeleteLop(id.Value); BindLopGrid(); BindPC_Lookups(); BindLookupsUsers(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Xóa lớp"); }
        }

        // ============================== TAB 3: MÔN ==============================
        private void BindMonGrid()
        {
            var rows = _svc.LookupMon().Select(m => new { m.Id, m.Ten }).ToList();
            dgvMon.DataSource = rows;
            if (dgvMon.Columns["Id"] != null) dgvMon.Columns["Id"].Visible = false;
        }

        private Guid? SelectedMonId()
        {
            if (dgvMon.CurrentRow == null) return null;
            var v = dgvMon.CurrentRow.Cells["Id"].Value?.ToString();
            return Guid.TryParse(v, out var id) ? id : null;
        }

        private void Mon_LoadToEditor()
        {
            if (dgvMon.CurrentRow == null) return;
            txtMon_Ten.Text = dgvMon.CurrentRow.Cells["Ten"]?.Value?.ToString() ?? "";
        }

        private void Mon_Them()
        {
            try
            {
                var ten = (txtMon_Ten.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(ten)) { MessageBox.Show("Nhập tên môn."); return; }
                _svc.CreateMon(ten, heSo: 1);
                txtMon_Ten.Clear();
                BindMonGrid();
                BindPC_Mon();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thêm môn"); }
        }

        private void Mon_Sua()
        {
            var id = SelectedMonId();
            if (id == null) { MessageBox.Show("Chọn 1 môn"); return; }
            try
            {
                var ten = (txtMon_Ten.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(ten)) { MessageBox.Show("Nhập tên môn."); return; }
                _svc.UpdateMon(id.Value, ten, heSo: 1);
                BindMonGrid();
                BindPC_Mon();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Sửa môn"); }
        }

        private void Mon_Xoa()
        {
            var id = SelectedMonId();
            if (id == null) { MessageBox.Show("Chọn 1 môn"); return; }
            if (MessageBox.Show("Xóa môn này?", "Xóa môn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _svc.DeleteMon(id.Value);
                txtMon_Ten.Clear();
                BindMonGrid();
                BindPC_Mon();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Xóa môn"); }
        }

        // ============================== TAB 4: HỌC KỲ ==============================
        private void BindKyLookups()
        {
            cboKyThu.Items.Clear();
            cboKyThu.Items.AddRange(new object[] { "1", "2" });
            if (cboKyThu.Items.Count > 0) cboKyThu.SelectedIndex = 0;
        }

        private void BindHocKyGrid()
        {
            var rows = _svc.ListHocKy().Select(k => new { k.Id, k.NamHoc, k.KyThu }).ToList();
            dgvHocKy.DataSource = rows;
            if (dgvHocKy.Columns["Id"] != null) dgvHocKy.Columns["Id"].Visible = false;

            BindLookupsUsers();
            BindPC_Lookups();
        }

        private Guid? SelectedKyId()
        {
            if (dgvHocKy.CurrentRow == null) return null;
            var v = dgvHocKy.CurrentRow.Cells["Id"].Value?.ToString();
            return Guid.TryParse(v, out var id) ? id : null;
        }

        private void Ky_LoadToEditor()
        {
            if (dgvHocKy.CurrentRow == null) return;
            txtNamHoc.Text = dgvHocKy.CurrentRow.Cells["NamHoc"]?.Value?.ToString() ?? "";
            cboKyThu.SelectedItem = (dgvHocKy.CurrentRow.Cells["KyThu"]?.Value?.ToString() ?? "1");
        }

        private void Ky_Them()
        {
            try
            {
                var kyThu = ParseIntOr(cboKyThu.SelectedItem as string, 1);
                _svc.CreateHocKy(txtNamHoc.Text, kyThu, daKhoa: false);
                BindHocKyGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Ky_Sua()
        {
            var id = SelectedKyId();
            if (id == null) { MessageBox.Show("Chọn kỳ"); return; }
            try
            {
                var kyThu = ParseIntOr(cboKyThu.SelectedItem as string, 1);
                _svc.UpdateHocKy(id.Value, txtNamHoc.Text, kyThu, daKhoa: false);
                BindHocKyGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Ky_Xoa()
        {
            var id = SelectedKyId();
            if (id == null) { MessageBox.Show("Chọn kỳ"); return; }
            if (MessageBox.Show("Xóa học kỳ này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { _svc.DeleteHocKy(id.Value); BindHocKyGrid(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ============================== TAB 5: PHÂN CÔNG ==============================
        private void BindPC_Lookups()
        {
            // Kỳ
            cboPC_Ky.Items.Clear();
            foreach (var k in _svc.LookupHocKy())
                cboPC_Ky.Items.Add(new ComboItem { Id = k.Id, Text = $"{k.NamHoc}-K{k.KyThu}" });
            if (cboPC_Ky.Items.Count > 0) cboPC_Ky.SelectedIndex = 0;

            // GV
            cboPC_GV.Items.Clear();
            foreach (var gv in _svc.LookupGiaoVien())
                cboPC_GV.Items.Add(new ComboItem { Id = gv.Id, Text = $"{gv.Ma} - {gv.HoTen}" });
            if (cboPC_GV.Items.Count > 0) cboPC_GV.SelectedIndex = 0;

            // Lớp & Môn
            BindPC_Lop();
            BindPC_Mon();
            BindPC_Grid();
        }

        private void BindPC_Lop()
        {
            cboPC_Lop.Items.Clear();
            foreach (var l in _svc.LookupLop())
                cboPC_Lop.Items.Add(new ComboItem { Id = l.Id, Text = $"{l.Khoi}-{l.Ten}" });
            if (cboPC_Lop.Items.Count > 0) cboPC_Lop.SelectedIndex = 0;
        }

        private void BindPC_Mon()
        {
            // ưu tiên môn theo khối lớp; nếu không có thì lấy tất cả
            cboPC_Mon.Items.Clear();
            if (cboPC_Lop.SelectedItem is ComboItem lopIt)
            {
                var lopInfo = _svc.GetLopInfo(lopIt.Id);
                if (lopInfo.HasValue)
                {
                    var mons = _svc.ListMonByKhoi(lopInfo.Value.Khoi);
                    foreach (var m in mons) cboPC_Mon.Items.Add(new ComboItem { Id = m.Id, Text = m.Ten });
                }
            }
            if (cboPC_Mon.Items.Count == 0)
                foreach (var m in _svc.LookupMon())
                    cboPC_Mon.Items.Add(new ComboItem { Id = m.Id, Text = m.Ten });

            if (cboPC_Mon.Items.Count > 0) cboPC_Mon.SelectedIndex = 0;
        }

        private void BindPC_Grid()
        {
            var kyId = GetId(cboPC_Ky);
            if (kyId == null) { dgvPhanCong.DataSource = null; return; }

            var lopId = GetId(cboPC_Lop);
            var rows = _svc.ListAssignments(kyId.Value, lopId)
                           .Select(x => new { x.PhanCongId, x.Khoi, x.Lop, x.Mon, x.GiaoVien, x.GiaoVienMa })
                           .ToList();
            dgvPhanCong.DataSource = rows;
            if (dgvPhanCong.Columns["PhanCongId"] != null) dgvPhanCong.Columns["PhanCongId"].Visible = false;
        }

        private Guid? SelectedPhanCongId()
        {
            if (dgvPhanCong.CurrentRow == null) return null;
            var v = dgvPhanCong.CurrentRow.Cells["PhanCongId"].Value?.ToString();
            return Guid.TryParse(v, out var id) ? id : null;
        }

        private void PC_Them()
        {
            var kyId = GetId(cboPC_Ky);
            var lopId = GetId(cboPC_Lop);
            var monId = GetId(cboPC_Mon);
            var gvId = GetId(cboPC_GV);
            if (kyId == null || lopId == null || monId == null || gvId == null) { MessageBox.Show("Thiếu chọn"); return; }
            try { _svc.Assign(gvId.Value, monId.Value, lopId.Value, kyId.Value); BindPC_Grid(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PC_Xoa()
        {
            var id = SelectedPhanCongId();
            if (id == null) { MessageBox.Show("Chọn dòng"); return; }
            if (MessageBox.Show("Thu hồi phân công này?", "Thu hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { _svc.Unassign(id.Value); BindPC_Grid(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ============================== DIALOG SỬA LIÊN HỆ ==============================
        private sealed class EditContactDialog : Form
        {
            public string? Email => string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            public string? DienThoai => string.IsNullOrWhiteSpace(txtSdt.Text) ? null : txtSdt.Text.Trim();

            private readonly TextBox txtEmail = new TextBox();
            private readonly TextBox txtSdt = new TextBox();

            public EditContactDialog(string? email = null, string? dienThoai = null)
            {
                Text = "Cập nhật liên hệ";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                ClientSize = new Size(380, 160);

                var table = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 3,
                    Padding = new Padding(12)
                };
                table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                var lblEmail = new Label { Text = "Email:", Anchor = AnchorStyles.Left, AutoSize = true };
                var lblSdt = new Label { Text = "Điện thoại:", Anchor = AnchorStyles.Left, AutoSize = true };

                txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                txtSdt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                if (!string.IsNullOrWhiteSpace(email)) txtEmail.Text = email!;
                if (!string.IsNullOrWhiteSpace(dienThoai)) txtSdt.Text = dienThoai!;

                table.Controls.Add(lblEmail, 0, 0);
                table.Controls.Add(txtEmail, 1, 0);
                table.Controls.Add(lblSdt, 0, 1);
                table.Controls.Add(txtSdt, 1, 1);

                var pnlBtns = new FlowLayoutPanel
                {
                    Dock = DockStyle.Bottom,
                    Height = 48,
                    FlowDirection = FlowDirection.RightToLeft,
                    Padding = new Padding(12, 6, 12, 12)
                };

                var btnOK = new Button { Text = "Lưu", Width = 96, DialogResult = DialogResult.OK, BackColor = Accent, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnOK.FlatAppearance.BorderSize = 0;
                var btnCancel = new Button { Text = "Hủy", Width = 96, DialogResult = DialogResult.Cancel };

                AcceptButton = btnOK;
                CancelButton = btnCancel;

                pnlBtns.Controls.Add(btnOK);
                pnlBtns.Controls.Add(btnCancel);

                Controls.Add(table);
                Controls.Add(pnlBtns);
            }
        }

        private void btnGV_Them_Click(object sender, EventArgs e)
        {

        }
    }
}
