// Infrastructure/EF/Seeder.cs
using System.Linq;
using DemoAppQLTH.Domain;

namespace DemoAppQLTH.Infrastructure.EF
{
    public static class Seeder
    {
        public static void Seed(SchoolDbContext ctx)
        {
            // Admin mặc định
            if (!ctx.Admins.Any())
            {
                ctx.Admins.Add(new Admin { Ma = "A01", HoTen = "Quản trị", MatKhau = "admin" });
            }

            // Học kỳ mẫu
            if (!ctx.HocKys.Any())
            {
                ctx.HocKys.AddRange(
                    new HocKy { NamHoc = "2025-2026", KyThu = 1, DaKhoa = false },
                    new HocKy { NamHoc = "2024-2025", KyThu = 2, DaKhoa = true }
                );
            }

            // Lớp mẫu
            if (!ctx.LopHocs.Any())
            {
                ctx.LopHocs.AddRange(
                    new LopHoc { Ten = "10A1", Khoi = 10 },
                    new LopHoc { Ten = "10A2", Khoi = 10 }
                );
            }

            // Môn mẫu
            if (!ctx.MonHocs.Any())
            {
                ctx.MonHocs.AddRange(
                    new MonHoc { Ten = "Toán", HeSo = 3 },
                    new MonHoc { Ten = "Văn", HeSo = 2 },
                    new MonHoc { Ten = "Anh", HeSo = 3 }
                );
            }

            ctx.SaveChanges();

            // Môn theo khối: 10/11/12 đều có Toán, Văn, Anh
            var allMon = ctx.MonHocs.ToList();
            foreach (var khoi in new[] { 10, 11, 12 })
            {
                foreach (var m in allMon)
                {
                    if (!ctx.KhoiMons.Any(x => x.Khoi == khoi && x.MonHocId == m.Id))
                        ctx.KhoiMons.Add(new KhoiMon { Khoi = khoi, MonHocId = m.Id });
                }
            }

            // Giáo viên/HS mẫu (tùy chọn)
            if (!ctx.GiaoViens.Any())
            {
                ctx.GiaoViens.Add(new GiaoVien { Ma = "GV01", HoTen = "Thầy A", MatKhau = "1234" });
            }
            if (!ctx.HocSinhs.Any())
            {
                var hs = new HocSinh { Ma = "HS01", HoTen = "Bạn B", MatKhau = "1234" };
                ctx.HocSinhs.Add(hs);
                ctx.SaveChanges();

                // Ghi danh HS01 vào 10A1 @ kỳ đang mở (nếu có)
                var kyMo = ctx.HocKys.FirstOrDefault(k => !k.DaKhoa);
                var lop = ctx.LopHocs.First();
                if (kyMo != null)
                {
                    ctx.GhiDanhs.Add(new GhiDanh { HocSinhId = hs.Id, LopHocId = lop.Id, HocKyId = kyMo.Id });
                }
            }

            ctx.SaveChanges();
        }
    }
}
