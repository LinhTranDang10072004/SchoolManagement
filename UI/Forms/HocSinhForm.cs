// UI/Forms/HocSinhForm.cs
using DemoAppQLTH.Application.Services;
using DemoAppQLTH.Infrastructure.EF;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyTruongHocV1.UI.Forms
{
    public partial class HocSinhForm : Form
    {
        private readonly Guid _hocSinhId;
        private readonly SchoolDbContext _ctx;
        private readonly HocSinhService _service;

        // cache kỳ & lớp theo kỳ để hiển thị nhãn lớp
        private class KyItem { public Guid KyId; public string KyTen = ""; public Guid LopId; public string LopTen = ""; public bool DaKhoa; }
        private KyItem[] _kyItems = Array.Empty<KyItem>();

        public HocSinhForm(Guid hocSinhId)
        {
            InitializeComponent();

            _hocSinhId = hocSinhId;
            var factory = new SchoolDbContextFactory();
            _ctx = factory.CreateDbContext(Array.Empty<string>());
            _service = new HocSinhService(_ctx);

            this.Load += HocSinhForm_Load;
            this.FormClosed += (_, __) => _ctx?.Dispose();

            // polish
            this.AcceptButton = btnReload;
        }

        private void HocSinhForm_Load(object? sender, EventArgs e)
        {
            BindThongTin();
            LoadKyCombo();
            ReloadBangDiem();
        }

        // ========== Tab 1: Bảng điểm ==========
        private void LoadKyCombo()
        {
            _kyItems = _service.GetKyCuaHocSinh(_hocSinhId)
                               .Select(o => new KyItem
                               {
                                   KyId = (Guid)o.GetType().GetProperty("KyId")!.GetValue(o)!,
                                   KyTen = (string)o.GetType().GetProperty("KyTen")!.GetValue(o)!,
                                   LopId = (Guid)o.GetType().GetProperty("LopId")!.GetValue(o)!,
                                   LopTen = (string)o.GetType().GetProperty("LopTen")!.GetValue(o)!,
                                   DaKhoa = (bool)o.GetType().GetProperty("DaKhoa")!.GetValue(o)!
                               })
                               .ToArray();

            cboKy.DataSource = _kyItems.Select(x => new { Id = x.KyId, Ten = x.KyTen }).ToList();
            cboKy.DisplayMember = "Ten";
            cboKy.ValueMember = "Id";
        }

        private void cboKy_SelectedIndexChanged(object? sender, EventArgs e) => ReloadBangDiem();

        private void btnReload_Click(object? sender, EventArgs e) => ReloadBangDiem();

        private void ReloadBangDiem()
        {
            lblGPA.Text = "GPA: -";
            lblXepLoai.Text = "Xếp loại: -";
            dgvBangDiem.DataSource = null;

            if (!(cboKy.SelectedValue is Guid kyId) || kyId == Guid.Empty) { lblLop.Text = "Lớp: (chưa)"; return; }

            var kyItem = _kyItems.FirstOrDefault(x => x.KyId == kyId);
            lblLop.Text = kyItem != null
                ? $"Lớp: {kyItem.LopTen}" + (kyItem.DaKhoa ? "  •  (Kỳ đã khoá)" : "")
                : "Lớp: (không có)";

            var rows = _service.GetBangDiemTheoKyDayDu(_hocSinhId, kyId)
                               .Select(o => new
                               {
                                   Mon = (string)o.GetType().GetProperty("Mon")!.GetValue(o)!,
                                   GiaoVien = (string)o.GetType().GetProperty("GiaoVien")!.GetValue(o)!,
                                   Diem = (double?)o.GetType().GetProperty("Diem")!.GetValue(o)!
                               })
                               .ToList();

            dgvBangDiem.DataSource = rows;
            // format điểm
            if (dgvBangDiem.Columns["Diem"] != null)
            {
                dgvBangDiem.Columns["Diem"].DefaultCellStyle.Format = "0.##";
                dgvBangDiem.Columns["Diem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // GPA & xếp loại
            var gpa = _service.TinhGPA(_hocSinhId, kyId);
            lblGPA.Text = $"GPA: {gpa:0.##}";
            lblXepLoai.Text = $"Xếp loại: {XepLoai(gpa)}";
        }

        private static string XepLoai(double gpa)
        {
            if (gpa >= 8.0) return "Giỏi";
            if (gpa >= 6.5) return "Khá";
            if (gpa >= 5.0) return "Trung bình";
            return "Yếu";
        }

        // ========== Tab 2: Thông tin ==========
        private void BindThongTin()
        {
            var info = _service.GetThongTinHocSinh(_hocSinhId);
            if (info == null) return;

            var t = info.GetType();
            lblMaValue.Text = (string)(t.GetProperty("Ma")!.GetValue(info) ?? "-");
            lblHoTenValue.Text = (string)(t.GetProperty("HoTen")!.GetValue(info) ?? "-");
            txtEmail.Text = (string?)(t.GetProperty("Email")!.GetValue(info) ?? "") ?? "";
            txtPhone.Text = (string?)(t.GetProperty("DienThoai")!.GetValue(info) ?? "") ?? "";
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _service.CapNhatThongTinLienHe(_hocSinhId, string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                                                       string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim());
            MessageBox.Show("Đã lưu thông tin liên hệ.", "Thành công");
        }

        private void btnHoanTac_Click(object? sender, EventArgs e) => BindThongTin();

        // đơn giản hoá validate (đủ dùng cho demo)
        private static bool IsValidEmail(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true; // cho phép để trống
            try { return Regex.IsMatch(s, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"); }
            catch { return false; }
        }
        private static bool IsValidPhone(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
            return Regex.IsMatch(s, @"^[0-9\-\+\s]{8,15}$");
        }
    }
}
