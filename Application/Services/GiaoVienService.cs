// Application/Services/GiaoVienService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using DemoAppQLTH.Domain;
using DemoAppQLTH.Infrastructure.EF;

namespace DemoAppQLTH.Application.Services
{
    /// <summary>Nghiệp vụ cho Giáo viên: xem phân công, nhập điểm, thống kê</summary>
    public class GiaoVienService
    {
        private readonly SchoolDbContext _ctx;
        public GiaoVienService(SchoolDbContext ctx) { _ctx = ctx; }

        public IEnumerable<object> LayPhanCongCuaGV(Guid gvId)
        {
            var q = from p in _ctx.PhanCongs
                    join m in _ctx.MonHocs on p.MonHocId equals m.Id
                    join l in _ctx.LopHocs on p.LopHocId equals l.Id
                    join k in _ctx.HocKys on p.HocKyId equals k.Id
                    where p.GiaoVienId == gvId
                    select new
                    {
                        p.Id,
                        Mon = m.Ten,
                        Lop = l.Ten,
                        Ky = $"{k.NamHoc}-K{k.KyThu}",
                        LopId = l.Id,
                        MonId = m.Id,
                        KyId = k.Id
                    };
            return q.ToList();
        }

        public IEnumerable<object> DanhSachHocSinhTheoLopKy(Guid lopId, Guid kyId)
        {
            var q = from gd in _ctx.GhiDanhs
                    join hs in _ctx.HocSinhs on gd.HocSinhId equals hs.Id
                    where gd.LopHocId == lopId && gd.HocKyId == kyId
                    orderby hs.HoTen
                    select new { hs.Id, hs.Ma, hs.HoTen };
            return q.ToList();
        }

        public (bool ok, string msg) NhapDiem(Guid gvId, Guid hsId, Guid lopId, Guid monId, Guid kyId, double giaTri)
        {
            if (giaTri < 0 || giaTri > 10) return (false, "Điểm phải từ 0 đến 10");

            var hk = _ctx.HocKys.First(x => x.Id == kyId);
            if (hk.DaKhoa) return (false, "Học kỳ đã khoá");

            var pc = _ctx.PhanCongs.FirstOrDefault(p =>
                p.GiaoVienId == gvId && p.LopHocId == lopId && p.MonHocId == monId && p.HocKyId == kyId);
            if (pc == null) return (false, "Không có phân công hợp lệ");

            var diem = _ctx.Diems.FirstOrDefault(d =>
                d.HocSinhId == hsId && d.MonHocId == monId && d.HocKyId == kyId);

            if (diem == null)
                _ctx.Diems.Add(new Diem { HocSinhId = hsId, MonHocId = monId, HocKyId = kyId, GiaTri = giaTri });
            else
            {
                diem.GiaTri = giaTri;
                _ctx.Diems.Update(diem);
            }

            _ctx.SaveChanges();
            return (true, "Đã lưu điểm");
        }

        public (double tbLop, double tiLeQuaMon) ThongKeLop(Guid lopId, Guid monId, Guid kyId)
        {
            var hsIds = _ctx.GhiDanhs
                            .Where(g => g.LopHocId == lopId && g.HocKyId == kyId)
                            .Select(g => g.HocSinhId)
                            .ToList();
            var ds = _ctx.Diems
                         .Where(d => d.MonHocId == monId && d.HocKyId == kyId && hsIds.Contains(d.HocSinhId))
                         .Select(d => d.GiaTri)
                         .ToList();

            if (ds.Count == 0) return (0, 0);
            var tb = Math.Round(ds.Average(), 2);
            var qua = Math.Round(ds.Count(x => x >= 5.0) * 100.0 / ds.Count, 2);
            return (tb, qua);
        }
    }
}
