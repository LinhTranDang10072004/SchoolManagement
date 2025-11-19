// QuanLyTruongHocV1/UI/Forms/GiaoVienForm.cs
using DemoAppQLTH.Application.Services;
using DemoAppQLTH.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyTruongHocV1.UI.Forms
{
    public partial class GiaoVienForm : Form
    {
        private readonly GiaoVienService _service;
        private readonly SchoolDbContext _ctx;
        private readonly Guid _giaoVienId;

        // cache phân công để bind combobox/tab
        private List<PhanCongView> _assignments = new();

        public GiaoVienForm(Guid giaoVienId)
        {
            InitializeComponent();

            _giaoVienId = giaoVienId;
            var factory = new SchoolDbContextFactory();
            _ctx = factory.CreateDbContext(Array.Empty<string>());
            _service = new GiaoVienService(_ctx);

            this.Load += GiaoVienForm_Load;
            this.FormClosed += (_, __) => _ctx?.Dispose();
        }

        private void GiaoVienForm_Load(object? sender, EventArgs e)
        {
            LoadAssignments();
            BindKyCombo_Tab1();
            BindCombos_Tab2();
            BindPhanCongGrid();
        }

        #region ===== Models & helpers =====
        private sealed class PhanCongView
        {
            public Guid Id { get; set; }
            public string Mon { get; set; } = "";
            public string Lop { get; set; } = "";
            public string Ky { get; set; } = "";
            public Guid LopId { get; set; }
            public Guid MonId { get; set; }
            public Guid KyId { get; set; }
        }

        private static T Prop<T>(object obj, string name)
        {
            var v = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance)?.GetValue(obj);
            if (v == null) return default!;
            return (T)v;
        }
        #endregion

        #region ===== Tab 1: Phân công của tôi =====
        private void LoadAssignments()
        {
            var raw = _service.LayPhanCongCuaGV(_giaoVienId);
            _assignments = raw
                .Select(o => new PhanCongView
                {
                    Id = Prop<Guid>(o, "Id"),
                    Mon = Prop<string>(o, "Mon"),
                    Lop = Prop<string>(o, "Lop"),
                    Ky = Prop<string>(o, "Ky"),
                    LopId = Prop<Guid>(o, "LopId"),
                    MonId = Prop<Guid>(o, "MonId"),
                    KyId = Prop<Guid>(o, "KyId"),
                })
                .OrderBy(x => x.Ky).ThenBy(x => x.Lop).ThenBy(x => x.Mon)
                .ToList();
        }

        private void BindKyCombo_Tab1()
        {
            var kyList = _assignments
                .GroupBy(x => new { x.KyId, x.Ky })
                .Select(g => new { Id = g.Key.KyId, Ten = g.Key.Ky })
                .OrderBy(x => x.Ten)
                .ToList();

            cboKy.DataSource = kyList;
            cboKy.DisplayMember = "Ten";
            cboKy.ValueMember = "Id";
        }

        private void BindPhanCongGrid()
        {
            IEnumerable<PhanCongView> view = _assignments;
            if (cboKy.SelectedValue is Guid kyId && kyId != Guid.Empty)
                view = view.Where(x => x.KyId == kyId);

            dgvPhanCong.DataSource = view
                .Select(x => new { x.Lop, x.Mon, Ky = x.Ky, x.LopId, x.MonId, x.KyId })
                .ToList();

            // Ẩn IDs kỹ thuật
            if (dgvPhanCong.Columns["LopId"] != null) dgvPhanCong.Columns["LopId"].Visible = false;
            if (dgvPhanCong.Columns["MonId"] != null) dgvPhanCong.Columns["MonId"].Visible = false;
            if (dgvPhanCong.Columns["KyId"] != null) dgvPhanCong.Columns["KyId"].Visible = false;
        }

        private void cboKy_SelectedIndexChanged(object? sender, EventArgs e) => BindPhanCongGrid();

        private void btnReloadPC_Click(object? sender, EventArgs e)
        {
            LoadAssignments();
            BindKyCombo_Tab1();
            BindPhanCongGrid();
        }

        private void dgvPhanCong_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvPhanCong.Rows[e.RowIndex];
            var kyId = (Guid)row.Cells["KyId"].Value;
            var lopId = (Guid)row.Cells["LopId"].Value;
            var monId = (Guid)row.Cells["MonId"].Value;

            tabs.SelectedTab = tabNhapDiem;

            // set comboboxes ở Tab 2 tương ứng
            SelectComboValue(cboHocKy, kyId);
            BindLopByKy();
            SelectComboValue(cboLop, lopId);
            BindMonByKyLop();
            SelectComboValue(cboMonHoc, monId);

            ReloadHocSinhGrid();
        }
        #endregion

        #region ===== Tab 2: Điểm & Danh sách HS =====
        private void BindCombos_Tab2()
        {
            // HocKy
            var kyList = _assignments
                .GroupBy(x => new { x.KyId, x.Ky })
                .Select(g => new { Id = g.Key.KyId, Ten = g.Key.Ky })
                .OrderBy(x => x.Ten)
                .ToList();
            cboHocKy.DataSource = kyList;
            cboHocKy.DisplayMember = "Ten";
            cboHocKy.ValueMember = "Id";

            BindLopByKy();
            BindMonByKyLop();
        }

        private void BindLopByKy()
        {
            var kyId = SelectedGuid(cboHocKy);
            var lopList = _assignments
                .Where(x => x.KyId == kyId)
                .GroupBy(x => new { x.LopId, x.Lop })
                .Select(g => new { Id = g.Key.LopId, Ten = g.Key.Lop })
                .OrderBy(x => x.Ten)
                .ToList();

            cboLop.DataSource = lopList;
            cboLop.DisplayMember = "Ten";
            cboLop.ValueMember = "Id";
        }

        private void BindMonByKyLop()
        {
            var kyId = SelectedGuid(cboHocKy);
            var lopId = SelectedGuid(cboLop);
            var monList = _assignments
                .Where(x => x.KyId == kyId && x.LopId == lopId)
                .GroupBy(x => new { x.MonId, x.Mon })
                .Select(g => new { Id = g.Key.MonId, Ten = g.Key.Mon })
                .OrderBy(x => x.Ten)
                .ToList();

            cboMonHoc.DataSource = monList;
            cboMonHoc.DisplayMember = "Ten";
            cboMonHoc.ValueMember = "Id";
        }

        private void cboHocKy_SelectedIndexChanged(object? sender, EventArgs e)
        {
            BindLopByKy();
            BindMonByKyLop();
            ReloadHocSinhGrid();
        }

        private void cboLop_SelectedIndexChanged(object? sender, EventArgs e)
        {
            BindMonByKyLop();
            ReloadHocSinhGrid();
        }

        private void cboMonHoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ReloadHocSinhGrid();
        }

        private void btnReloadHS_Click(object? sender, EventArgs e) => ReloadHocSinhGrid();

        private void ReloadHocSinhGrid()
        {
            var kyId = SelectedGuid(cboHocKy);
            var lopId = SelectedGuid(cboLop);
            var monId = SelectedGuid(cboMonHoc);
            if (kyId == Guid.Empty || lopId == Guid.Empty || monId == Guid.Empty)
            {
                dgvHocSinh.DataSource = null;
                lblTB.Text = "Điểm TB lớp: -";
                lblQua.Text = "Tỉ lệ qua môn: -";
                return;
            }

            // HS theo lớp+kỳ + LEFT JOIN điểm theo môn+kỳ
            var hs = from gd in _ctx.GhiDanhs
                     join s in _ctx.HocSinhs on gd.HocSinhId equals s.Id
                     where gd.LopHocId == lopId && gd.HocKyId == kyId
                     orderby s.HoTen
                     select new { s.Id, s.Ma, s.HoTen };

            var diemDict = _ctx.Diems
                .Where(d => d.MonHocId == monId && d.HocKyId == kyId)
                .Select(d => new { d.HocSinhId, d.GiaTri })
                .ToList()
                .ToDictionary(x => x.HocSinhId, x => (double?)x.GiaTri);

            var view = hs.AsEnumerable()
                         .Select(x => new
                         {
                             Id = x.Id,
                             MaHS = x.Ma,
                             HoTen = x.HoTen,
                             Diem = diemDict.TryGetValue(x.Id, out var v) ? v : null
                         })
                         .ToList();

            dgvHocSinh.DataSource = view;
            if (dgvHocSinh.Columns["Id"] != null) dgvHocSinh.Columns["Id"].Visible = false;

            UpdateStats(lopId, monId, kyId);
        }

        private void UpdateStats(Guid lopId, Guid monId, Guid kyId)
        {
            var (tb, qua) = _service.ThongKeLop(lopId, monId, kyId);
            lblTB.Text = $"Điểm TB lớp: {tb:0.##}";
            lblQua.Text = $"Tỉ lệ qua môn: {qua:0.##}%";
        }

        private void btnNhapDiem_Click(object? sender, EventArgs e)
        {
            if (dgvHocSinh.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn 1 học sinh.", "Thông báo");
                return;
            }

            if (!double.TryParse(txtDiem.Text.Replace(",", "."), System.Globalization.NumberStyles.Any,
                                 System.Globalization.CultureInfo.InvariantCulture, out var diem))
            {
                MessageBox.Show("Điểm không hợp lệ. Vui lòng nhập số từ 0 đến 10.", "Lỗi");
                return;
            }

            if (diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10.", "Lỗi");
                return;
            }

            var kyId = SelectedGuid(cboHocKy);
            var lopId = SelectedGuid(cboLop);
            var monId = SelectedGuid(cboMonHoc);
            var hsId = (Guid)dgvHocSinh.CurrentRow.Cells["Id"].Value;

            // Gọi service theo đúng thứ tự tham số: gvId, hsId, lopId, monId, kyId, giaTri
            var (ok, msg) = _service.NhapDiem(_giaoVienId, hsId, lopId, monId, kyId, diem);
            if (!ok)
            {
                MessageBox.Show(msg, "Không thể lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật tại chỗ + thống kê
            dgvHocSinh.CurrentRow.Cells["Diem"].Value = diem;
            UpdateStats(lopId, monId, kyId);
            MessageBox.Show("Đã lưu điểm.", "Thành công");
        }
        #endregion

        #region ===== Utils =====
        private static Guid SelectedGuid(ComboBox cbo)
        {
            return (cbo?.SelectedValue is Guid g) ? g : Guid.Empty;
        }

        private static void SelectComboValue(ComboBox cbo, Guid value)
        {
            if (cbo?.DataSource == null) return;
            cbo.SelectedValue = value;
        }
        #endregion

        
    }
}
