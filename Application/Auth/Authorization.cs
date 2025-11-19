// Application/Auth/Authorization.cs
using System;
using System.Linq;
using DemoAppQLTH.Domain;
using DemoAppQLTH.Infrastructure.EF;

namespace DemoAppQLTH.Application.Auth
{
    
    public static class Authorization
    {
        public static (bool ok, string msg, string loai, Guid id, string ma, string hoTen)
            TryLogin(string ma, string mk, SchoolDbContext ctx)
        {
            var admin = ctx.Admins.FirstOrDefault(x => x.Ma == ma && x.MatKhau == mk);
            if (admin != null) return (true, "OK", "Admin", admin.Id, admin.Ma, admin.HoTen);

            var gv = ctx.GiaoViens.FirstOrDefault(x => x.Ma == ma && x.MatKhau == mk);
            if (gv != null) return (true, "OK", "GiaoVien", gv.Id, gv.Ma, gv.HoTen);

            var hs = ctx.HocSinhs.FirstOrDefault(x => x.Ma == ma && x.MatKhau == mk);
            if (hs != null) return (true, "OK", "HocSinh", hs.Id, hs.Ma, hs.HoTen);

            return (false, "Sai mã hoặc mật khẩu", "", Guid.Empty, "", "");
        }
    }
}
