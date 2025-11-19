using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>
    /// Cha chung cho người dùng (Admin / Giáo viên / Học sinh).
    /// Dùng TPH với discriminator "Loai" được mapping ở DbContext.
    /// </summary>
    [Index(nameof(Ma), IsUnique = true)]
    public abstract class Nguoi
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>Mã đăng nhập (vd: A01, GV01, HS01)</summary>
        [Required, MaxLength(32)]
        public string Ma { get; set; } = "";

        /// <summary>Họ và tên</summary>
        [Required, MaxLength(128)]
        public string HoTen { get; set; } = "";

        /// <summary>Email liên hệ</summary>
        [MaxLength(128)]
        public string? Email { get; set; }

        /// <summary>SĐT liên hệ</summary>
        [MaxLength(32)]
        public string? DienThoai { get; set; }

        /// <summary>Mật khẩu (demo: plain text; thực tế nên băm/hash)</summary>
        [Required, MaxLength(64)]
        public string MatKhau { get; set; } = "";
    }
}