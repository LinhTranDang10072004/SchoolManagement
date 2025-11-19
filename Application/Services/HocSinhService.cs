// Application/Services/HocSinhService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using DemoAppQLTH.Infrastructure.EF;

namespace DemoAppQLTH.Application.Services
{
    /// <summary>Nghiệp vụ cho Học sinh: bảng điểm, GPA, cập nhật liên hệ</summary>
    public class HocSinhService
    {
        private readonly SchoolDbContext _ctx;
        public HocSinhService(SchoolDbContext ctx) { _ctx = ctx; }

        /// <summary>
        /// Bảng điểm theo Diem (chỉ trả về môn đã có điểm).
        /// Giữ nguyên chữ ký bạn đưa ra để tương thích nơi khác nếu dùng.
        /// </summary>
        public IEnumerable<object> GetBangDiem(Guid hsId, Guid? kyId = null)
        {
            var q = from d in _ctx.Diems
                    join m in _ctx.MonHocs on d.MonHocId equals m.Id
                    join k in _ctx.HocKys on d.HocKyId equals k.Id
                    where d.HocSinhId == hsId && (kyId == null || d.HocKyId == kyId)
                    orderby k.NamHoc descending, k.KyThu descending, m.Ten
                    select new { Mon = m.Ten, Diem = d.GiaTri, Ky = $"{k.NamHoc}-K{k.KyThu}" };
            return q.ToList();
        }

        /// <summary>
        /// GPA có trọng số theo MonHoc.HeSo (nếu kyId = null thì tính toàn bộ).
        /// </summary>
        public double TinhGPA(Guid hsId, Guid? kyId = null)
        {
            var q = from d in _ctx.Diems
                    join m in _ctx.MonHocs on d.MonHocId equals m.Id
                    where d.HocSinhId == hsId && (kyId == null || d.HocKyId == kyId)
                    select new { d.GiaTri, m.HeSo };
            var list = q.ToList();
            if (list.Count == 0) return 0;
            double num = list.Sum(x => x.GiaTri * x.HeSo);
            double den = Math.Max(1, list.Sum(x => x.HeSo));
            return Math.Round(num / den, 2);
        }

        /// <summary>Cập nhật Email/SĐT cho chính học sinh.</summary>
        public void CapNhatThongTinLienHe(Guid hsId, string? email, string? sdt)
        {
            var hs = _ctx.HocSinhs.First(x => x.Id == hsId);
            hs.Email = email;
            hs.DienThoai = sdt;
            _ctx.SaveChanges();
        }

        // ===================== Mở rộng cho UI =====================

        /// <summary>Các kỳ mà HS có ghi danh, kèm LopId/LopTen để hiển thị.</summary>
        public IEnumerable<object> GetKyCuaHocSinh(Guid hsId)
        {
            var q = from gd in _ctx.GhiDanhs
                    join k in _ctx.HocKys on gd.HocKyId equals k.Id
                    join l in _ctx.LopHocs on gd.LopHocId equals l.Id
                    where gd.HocSinhId == hsId
                    orderby k.NamHoc descending, k.KyThu descending
                    select new
                    {
                        KyId = k.Id,
                        KyTen = $"{k.NamHoc}-K{k.KyThu}",
                        LopId = l.Id,
                        LopTen = l.Ten,
                        Khoi = l.Khoi,
                        DaKhoa = k.DaKhoa
                    };
            return q.ToList();
        }

        /// <summary>
        /// Bảng điểm đầy đủ cho 1 kỳ: lấy MÔN theo PHÂN CÔNG của LỚP trong kỳ, LEFT JOIN với DIEM của HS.
        /// Hiển thị được cả môn chưa có điểm.
        /// </summary>
        public IEnumerable<object> GetBangDiemTheoKyDayDu(Guid hsId, Guid kyId)
        {
            // Lấy lớp của HS trong kỳ
            var lopId = _ctx.GhiDanhs
                            .Where(g => g.HocSinhId == hsId && g.HocKyId == kyId)
                            .Select(g => g.LopHocId)
                            .SingleOrDefault();

            if (lopId == Guid.Empty) return Array.Empty<object>();

            var monTheoLopKy = from pc in _ctx.PhanCongs
                               join m in _ctx.MonHocs on pc.MonHocId equals m.Id
                               join gv in _ctx.GiaoViens on pc.GiaoVienId equals gv.Id
                               where pc.LopHocId == lopId && pc.HocKyId == kyId
                               select new { m.Id, Mon = m.Ten, HeSo = m.HeSo, GiaoVien = gv.HoTen };

            var diemHs = from d in _ctx.Diems
                         where d.HocSinhId == hsId && d.HocKyId == kyId
                         select new { d.MonHocId, d.GiaTri };

            var q = from m in monTheoLopKy
                    join d in diemHs on m.Id equals d.MonHocId into gj
                    from d in gj.DefaultIfEmpty()
                    orderby m.Mon
                    select new
                    {
                        Mon = m.Mon,
                        GiaoVien = m.GiaoVien,
                        HeSo = m.HeSo,
                        Diem = (double?)d.GiaTri
                    };

            return q.ToList();
        }

        /// <summary>Thông tin cơ bản của học sinh.</summary>
        public object? GetThongTinHocSinh(Guid hsId)
        {
            return _ctx.HocSinhs
                       .Where(x => x.Id == hsId)
                       .Select(x => new { x.Ma, x.HoTen, x.Email, x.DienThoai })
                       .FirstOrDefault();
        }
    }
}
