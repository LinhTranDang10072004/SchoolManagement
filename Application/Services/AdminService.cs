// Application/Services/AdminService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using DemoAppQLTH.Domain;
using DemoAppQLTH.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Application.Services
{
    public class AdminService
    {
        private readonly SchoolDbContext _ctx;
        public AdminService(SchoolDbContext ctx) => _ctx = ctx;
        public List<HocKy> LookupHocKy(bool onlyOpenFirst = false)
        {
            var q = _ctx.HocKys.AsNoTracking()
                               .OrderByDescending(x => !x.DaKhoa)
                               .ThenBy(x => x.NamHoc).ThenBy(x => x.KyThu);
            return onlyOpenFirst ? q.Where(x => !x.DaKhoa).Take(1).ToList() : q.ToList();
        }

        public List<LopHoc> LookupLop() =>
            _ctx.LopHocs.AsNoTracking().OrderBy(x => x.Khoi).ThenBy(x => x.Ten).ToList();

        public List<MonHoc> LookupMon() =>
            _ctx.MonHocs.AsNoTracking().OrderBy(x => x.Ten).ToList();

        public List<GiaoVien> LookupGiaoVien() =>
            _ctx.GiaoViens.AsNoTracking().OrderBy(x => x.HoTen).ToList();
        public Guid CreateGiaoVien(string ma, string hoTen, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Thiếu thông tin");
            if (_ctx.Nguoi.Any(x => x.Ma == ma)) throw new InvalidOperationException("Mã đã tồn tại");

            var gv = new GiaoVien { Ma = ma.Trim(), HoTen = hoTen.Trim(), MatKhau = matKhau.Trim() };
            _ctx.GiaoViens.Add(gv);
            _ctx.SaveChanges();
            return gv.Id;
        }

        /// <summary>Tạo học sinh và ghi danh ngay vào (lopId, kyId)</summary>
        public Guid CreateHocSinh(string ma, string hoTen, string matKhau, Guid lopId, Guid kyId)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Thiếu thông tin");
            if (_ctx.Nguoi.Any(x => x.Ma == ma)) throw new InvalidOperationException("Mã đã tồn tại");
            if (!_ctx.LopHocs.Any(x => x.Id == lopId)) throw new KeyNotFoundException("Không tìm thấy lớp");
            if (!_ctx.HocKys.Any(x => x.Id == kyId)) throw new KeyNotFoundException("Không tìm thấy học kỳ");

            var hs = new HocSinh { Ma = ma.Trim(), HoTen = hoTen.Trim(), MatKhau = matKhau.Trim() };
            _ctx.HocSinhs.Add(hs);
            _ctx.SaveChanges();

            if (_ctx.GhiDanhs.Any(x => x.HocSinhId == hs.Id && x.HocKyId == kyId))
                throw new InvalidOperationException("Học sinh đã ghi danh kỳ này");

            _ctx.GhiDanhs.Add(new GhiDanh { HocSinhId = hs.Id, LopHocId = lopId, HocKyId = kyId });
            _ctx.SaveChanges();
            return hs.Id;
        }

        public void UpdateNguoiLienHe(Guid id, string? email, string? dienThoai)
        {
            var n = _ctx.Nguoi.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException();
            n.Email = string.IsNullOrWhiteSpace(email) ? null : email!.Trim();
            n.DienThoai = string.IsNullOrWhiteSpace(dienThoai) ? null : dienThoai!.Trim();
            _ctx.SaveChanges();
        }

        /// <summary>Xoá người dùng và toàn bộ dữ liệu liên quan (ghi danh/điểm/phan công…)</summary>
        public void DeleteNguoiForce(Guid id)
        {
            var n = _ctx.Nguoi.FirstOrDefault(x => x.Id == id)
                    ?? throw new KeyNotFoundException("Không tìm thấy người dùng");

            if (n is GiaoVien)
            {
                var pcs = _ctx.PhanCongs.Where(p => p.GiaoVienId == id);
                var dptp = _ctx.DiemThanhPhans.Where(d => d.GiaoVienId == id);
                _ctx.DiemThanhPhans.RemoveRange(dptp);
                _ctx.PhanCongs.RemoveRange(pcs);
            }
            else if (n is HocSinh)
            {
                var diems = _ctx.Diems.Where(d => d.HocSinhId == id);
                var dptp = _ctx.DiemThanhPhans.Where(d => d.HocSinhId == id);
                var gd = _ctx.GhiDanhs.Where(g => g.HocSinhId == id);
                _ctx.DiemThanhPhans.RemoveRange(dptp);
                _ctx.Diems.RemoveRange(diems);
                _ctx.GhiDanhs.RemoveRange(gd);
            }

            _ctx.Remove(n);
            _ctx.SaveChanges();
        }

        /// <summary>Danh sách người dùng kèm lớp hiện tại (nếu là HS) theo học kỳ chọn</summary>
        public List<UserRow> ListUsersWithClass(Guid kyId)
        {
            // EF Core không concat 3 IQueryable khác nguồn -> materialize trước
            var hsWithClass = (from hs in _ctx.HocSinhs
                               join gd in _ctx.GhiDanhs on hs.Id equals gd.HocSinhId
                               join l in _ctx.LopHocs on gd.LopHocId equals l.Id
                               where gd.HocKyId == kyId
                               select new { hs.Id, hs.Ma, hs.HoTen, Lop = l.Ten })
                              .AsNoTracking()
                              .ToList();

            var gvRows = _ctx.GiaoViens.AsNoTracking()
                .Select(g => new UserRow { Id = g.Id, Ma = g.Ma, HoTen = g.HoTen, Loai = "GiaoVien" })
                .ToList();

            var hsRows = hsWithClass
                .Select(h => new UserRow { Id = h.Id, Ma = h.Ma, HoTen = h.HoTen, Loai = "HocSinh", LopHienTai = h.Lop })
                .ToList();

            var adRows = _ctx.Admins.AsNoTracking()
                .Select(a => new UserRow { Id = a.Id, Ma = a.Ma, HoTen = a.HoTen, Loai = "Admin" })
                .ToList();

            return adRows.Concat(gvRows).Concat(hsRows)
                         .OrderBy(x => x.Loai).ThenBy(x => x.Ma).ToList();
        }

        public record UserRow
        {
            public Guid Id { get; init; }
            public string Ma { get; init; } = "";
            public string HoTen { get; init; } = "";
            public string Loai { get; init; } = "";   // Admin/GiaoVien/HocSinh
            public string? LopHienTai { get; init; }
        }

        public Guid CreateLop(string ten, int khoi)
        {
            if (khoi is not (10 or 11 or 12)) throw new ArgumentException("Khối phải là 10/11/12");
            if (string.IsNullOrWhiteSpace(ten)) throw new ArgumentException("Tên lớp trống");
            if (_ctx.LopHocs.Any(x => x.Ten == ten)) throw new InvalidOperationException("Tên lớp đã tồn tại");
            var l = new LopHoc { Ten = ten.Trim(), Khoi = khoi };
            _ctx.LopHocs.Add(l); _ctx.SaveChanges(); return l.Id;
        }
        public void UpdateLop(Guid id, string ten, int khoi, Guid? gvcnId = null)
        {
            var l = _ctx.LopHocs.Find(id) ?? throw new KeyNotFoundException("Không tìm thấy lớp");
            if (khoi is not (10 or 11 or 12)) throw new ArgumentException("Khối phải là 10/11/12");
            if (string.IsNullOrWhiteSpace(ten)) throw new ArgumentException("Tên lớp trống");
            if (_ctx.LopHocs.Any(x => x.Id != id && x.Ten == ten)) throw new InvalidOperationException("Tên lớp đã tồn tại");

            if (gvcnId.HasValue && !_ctx.GiaoViens.Any(x => x.Id == gvcnId)) throw new KeyNotFoundException("GVCN không tồn tại");
            l.Ten = ten.Trim(); l.Khoi = khoi; l.GVCNId = gvcnId;
            _ctx.SaveChanges();
        }
        public void DeleteLop(Guid id)
        {
            var l = _ctx.LopHocs.Find(id) ?? throw new KeyNotFoundException("Không tìm thấy lớp");
            if (_ctx.GhiDanhs.Any(g => g.LopHocId == id))
                throw new InvalidOperationException("Lớp đã có học sinh ghi danh");
            _ctx.LopHocs.Remove(l); _ctx.SaveChanges();
        }
        public List<LopHoc> ListLop() => _ctx.LopHocs.OrderBy(x => x.Khoi).ThenBy(x => x.Ten).ToList();

        // Môn theo khối (KhoiMon)
        public void AddMonToKhoi(int khoi, Guid monId)
        {
            if (khoi is not (10 or 11 or 12)) throw new ArgumentException("Khối phải là 10/11/12");
            if (!_ctx.MonHocs.Any(x => x.Id == monId)) throw new KeyNotFoundException("Không tìm thấy môn");
            if (_ctx.KhoiMons.Any(x => x.Khoi == khoi && x.MonHocId == monId)) return;
            _ctx.KhoiMons.Add(new KhoiMon { Khoi = khoi, MonHocId = monId }); _ctx.SaveChanges();
        }
        public void RemoveMonFromKhoi(int khoi, Guid monId)
        {
            var km = _ctx.KhoiMons.Find(khoi, monId);
            if (km == null) return; _ctx.KhoiMons.Remove(km); _ctx.SaveChanges();
        }
        public List<MonHoc> ListMonByKhoi(int khoi) =>
            _ctx.KhoiMons.Where(x => x.Khoi == khoi).Include(x => x.MonHoc).Select(x => x.MonHoc!)
                         .OrderBy(x => x.Ten).ToList();

        /// <summary>Lấy thông tin lớp theo ID (bao gồm khối)</summary>
        public (int Khoi, string Ten)? GetLopInfo(Guid lopId)
        {
            var lop = _ctx.LopHocs.AsNoTracking()
                .FirstOrDefault(x => x.Id == lopId);
            return lop != null ? (lop.Khoi, lop.Ten) : null;
        }

        // =========================
        // 3) Học kỳ
        // =========================
        public Guid CreateHocKy(string namHoc, int kyThu, bool daKhoa = false)
        {
            if (string.IsNullOrWhiteSpace(namHoc)) throw new ArgumentException("Năm học trống");
            if (kyThu is not (1 or 2)) throw new ArgumentException("Kỳ thứ phải là 1 hoặc 2");
            if (_ctx.HocKys.Any(x => x.NamHoc == namHoc && x.KyThu == kyThu))
                throw new InvalidOperationException("Học kỳ đã tồn tại");
            var k = new HocKy { NamHoc = namHoc.Trim(), KyThu = kyThu, DaKhoa = daKhoa };
            _ctx.HocKys.Add(k); _ctx.SaveChanges(); return k.Id;
        }
        public void UpdateHocKy(Guid id, string namHoc, int kyThu, bool daKhoa)
        {
            var k = _ctx.HocKys.Find(id) ?? throw new KeyNotFoundException("Không tìm thấy học kỳ");
            if (string.IsNullOrWhiteSpace(namHoc)) throw new ArgumentException("Năm học trống");
            if (kyThu is not (1 or 2)) throw new ArgumentException("Kỳ thứ phải là 1 hoặc 2");
            if (_ctx.HocKys.Any(x => x.Id != id && x.NamHoc == namHoc && x.KyThu == kyThu))
                throw new InvalidOperationException("Học kỳ đã tồn tại");
            k.NamHoc = namHoc.Trim(); k.KyThu = kyThu; k.DaKhoa = daKhoa; _ctx.SaveChanges();
        }
        public void DeleteHocKy(Guid id)
        {
            var k = _ctx.HocKys.Find(id) ?? throw new KeyNotFoundException("Không tìm thấy học kỳ");
            if (_ctx.GhiDanhs.Any(g => g.HocKyId == id) || _ctx.PhanCongs.Any(p => p.HocKyId == id))
                throw new InvalidOperationException("Học kỳ đã có dữ liệu");
            _ctx.HocKys.Remove(k); _ctx.SaveChanges();
        }
        public List<HocKy> ListHocKy() =>
            _ctx.HocKys.OrderByDescending(x => !x.DaKhoa).ThenBy(x => x.NamHoc).ThenBy(x => x.KyThu).ToList();

        // =========================
        // 4) Phân công GV–Môn–Lớp theo kỳ
        // =========================
        public Guid Assign(Guid gvId, Guid monId, Guid lopId, Guid kyId)
        {
            if (!_ctx.GiaoViens.Any(x => x.Id == gvId)) throw new KeyNotFoundException("GV không tồn tại");
            if (!_ctx.MonHocs.Any(x => x.Id == monId)) throw new KeyNotFoundException("Môn không tồn tại");
            var lop = _ctx.LopHocs.Find(lopId) ?? throw new KeyNotFoundException("Lớp không tồn tại");
            var ky = _ctx.HocKys.Find(kyId) ?? throw new KeyNotFoundException("Học kỳ không tồn tại");

            var thuocKhoi = _ctx.KhoiMons.Any(x => x.Khoi == lop.Khoi && x.MonHocId == monId);
            if (!thuocKhoi) throw new InvalidOperationException("Môn chưa được gán cho khối lớp này");

            if (_ctx.PhanCongs.Any(x => x.GiaoVienId == gvId && x.MonHocId == monId && x.LopHocId == lopId && x.HocKyId == kyId))
                throw new InvalidOperationException("Phân công đã tồn tại");

            var pc = new PhanCong { GiaoVienId = gvId, MonHocId = monId, LopHocId = lopId, HocKyId = kyId };
            _ctx.PhanCongs.Add(pc); _ctx.SaveChanges(); return pc.Id;
        }

        public void Unassign(Guid phanCongId)
        {
            var pc = _ctx.PhanCongs.Find(phanCongId) ?? throw new KeyNotFoundException("Không tìm thấy phân công");
            _ctx.PhanCongs.Remove(pc); _ctx.SaveChanges();
        }

        public List<AssignmentRow> ListAssignments(Guid kyId, Guid? lopId = null)
        {
            var q = from p in _ctx.PhanCongs
                    join gv in _ctx.GiaoViens on p.GiaoVienId equals gv.Id
                    join mh in _ctx.MonHocs on p.MonHocId equals mh.Id
                    join l in _ctx.LopHocs on p.LopHocId equals l.Id
                    where p.HocKyId == kyId && (!lopId.HasValue || p.LopHocId == lopId)
                    orderby l.Khoi, l.Ten, mh.Ten, gv.HoTen
                    select new AssignmentRow
                    {
                        PhanCongId = p.Id,
                        Lop = l.Ten,
                        Khoi = l.Khoi,
                        Mon = mh.Ten,
                        GiaoVien = gv.HoTen,
                        GiaoVienMa = gv.Ma
                    };
            return q.AsNoTracking().ToList();
        }

        public record AssignmentRow
        {
            public Guid PhanCongId { get; init; }
            public string Lop { get; init; } = "";
            public int Khoi { get; init; }
            public string Mon { get; init; } = "";
            public string GiaoVien { get; init; } = "";
            public string GiaoVienMa { get; init; } = "";
        }

        // =========================
        // 5) Môn học (CRUD)
        // =========================
        public Guid CreateMon(string ten, int heSo = 1)
        {
            if (string.IsNullOrWhiteSpace(ten)) throw new ArgumentException("Tên môn trống");
            if (_ctx.MonHocs.Any(x => x.Ten == ten)) throw new InvalidOperationException("Tên môn đã tồn tại");
            var m = new MonHoc { Ten = ten.Trim(), HeSo = Math.Clamp(heSo, 1, 10) };
            _ctx.MonHocs.Add(m); _ctx.SaveChanges(); return m.Id;
        }
        public void UpdateMon(Guid id, string ten, int heSo)
        {
            var m = _ctx.MonHocs.Find(id) ?? throw new KeyNotFoundException("Không tìm thấy môn");
            if (string.IsNullOrWhiteSpace(ten)) throw new ArgumentException("Tên môn trống");
            if (_ctx.MonHocs.Any(x => x.Id != id && x.Ten == ten)) throw new InvalidOperationException("Tên môn đã tồn tại");
            m.Ten = ten.Trim(); m.HeSo = Math.Clamp(heSo, 1, 10); _ctx.SaveChanges();
        }
        public void DeleteMon(Guid id)
        {
            var m = _ctx.MonHocs.Find(id) ?? throw new KeyNotFoundException("Không tìm thấy môn");
            if (_ctx.PhanCongs.Any(p => p.MonHocId == id) || _ctx.Diems.Any(d => d.MonHocId == id))
                throw new InvalidOperationException("Môn đã được sử dụng, không thể xoá");
            _ctx.MonHocs.Remove(m); _ctx.SaveChanges();
        }
        public List<MonHoc> ListMon() => _ctx.MonHocs.OrderBy(x => x.Ten).ToList();
    }
}
